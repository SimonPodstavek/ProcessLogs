using ProcessLogs.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace ProcessLogs.logs
{
    internal class LogClass
    {

        internal string filePath, fileName;
        internal byte[][] XMLSequences;
        internal byte[] LogContent;
        internal record[] logRecords;

        internal int CountRecords()
        {
            if (this.logRecords == null)
            {
                return 0;
            }

            return this.logRecords.Length;
        }


        internal LogClass(string filePath, string fileName)
        {
            this.filePath = filePath;
            this.fileName = fileName;
        }


        internal class record
        {
            internal byte[] XMLHash;
            internal byte[] computedHash;
            internal byte[] byteXMLSequence;
            internal byte[] byteLogContent;
            internal bool isValid = true;


        }

        /// <summary>
        /// This module appends Addition element after first occurance of Lookup element
        /// <param name="originalBytes">Original sequence that will be extended with additionElement</param>
        /// <param name="additionElement">The element with value (optional) to be inserted</param>
        /// <param name="lookupElement">The element to insert addition element after</param>
        /// </summary>

        internal static byte[] InsertElementAfterLookup(byte[] originalBytes, byte[] additionElement, byte[] lookupElement)
        {

            int additionLen = additionElement.Length;
            int lookupLen = lookupElement.Length;
            int originalLen = originalBytes.Length;



            int insertBytePosition = LogHandler.FindSequence(0, originalBytes, lookupElement) + lookupLen;


            if (insertBytePosition == -1)
            {
                throw new XMLElementNotFound($"Chyba 112: XML element {Encoding.UTF8.GetString(lookupElement)} neexistuje.");
            }


            byte[] resultBytes = new byte[originalLen + additionLen];

            Array.Copy(originalBytes, resultBytes, originalLen);

            string xyz = Encoding.UTF8.GetString(resultBytes);

            Array.Copy(additionElement, 0, resultBytes, insertBytePosition, additionLen);
            xyz = Encoding.UTF8.GetString(resultBytes);
            Array.Copy(originalBytes, insertBytePosition, resultBytes, insertBytePosition + additionLen, originalLen - insertBytePosition);
            xyz = Encoding.UTF8.GetString(resultBytes);


            return resultBytes;
        }


        /// <summary>
        /// This module removes whitespaces from hash string
        /// </summary>
        internal static string FormatHash(string hashString)
        {
            return hashString.Replace(Encoding.UTF8.GetString(Configuration.ByteSequences.whiteSpace), String.Empty);
        }

        //This method locates Hash sequence in each record by sequences defined in Configuration.ByteSequences
        internal static void FindXMLHash(LogClass logObject)
        {


            record[] logRecords = logObject.logRecords;

            foreach ((int index, record logRecord) in logRecords.Enumerate())
            {

                string hashString;
                byte[] byteXMLContent = logRecord.byteXMLSequence;
                byte[][] byteXMLHashes = LogHandler.GetEnclosedSequences(byteXMLContent,
                    Configuration.ByteSequences.logXMLHashOpeningSequence,
                    Configuration.ByteSequences.logXMLHashClosingSequence);

                if (byteXMLHashes.Length != 1)
                {
                    throw new Exception($"Chyba 108: Pri čítaní hash integrity XML súboru {logObject.filePath} sa vyskytla chyba.");
                }

                //Convert hash(hex) from byte to UTF-8 string
                hashString = Encoding.UTF8.GetString(byteXMLHashes[0]);

                //Remove whitespace characters from hash for the purposes of comparison against logs in aggregate file and the XML content itself
                hashString = FormatHash(hashString);

                //Strip the pure hash content cleared of <Hash> element
                hashString = hashString.Substring(6, 40);

                //Split string and turn it into hash.
                try
                {
                    logRecord.XMLHash = LogHandler.HexStringToByteArray(hashString);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Chyba 110: Konverzia hash z reťazca na byte zlyhala. pri zázname č. {index + 1}.", ex);
                }
            }

            return;
        }

        //This method removes records with IDs in removeList from an array
        public static record[] RemoveRecordsFromLog(record[] originalArray, HashSet<int> removeList)
        {
            int len = originalArray.Length - removeList.Count();
            record[] res = new record[len];
            int pos = 0;
            foreach ((int index, record item) in originalArray.Enumerate())
            {
                if (!removeList.Contains(index))
                {
                    res[pos] = item;
                    pos += 1;
                }
            }
            return res;

        }


        public static record[] RemoveAllRecordsFromLog()
        {
            return new record[0];
        }


        //This method verifies whether the sequences in a log file has a right hash 
        internal static void VerifyRecordsIntegrity(LogClass logObject)
        {
            record[] logRecords = logObject.logRecords;
            HashSet<int> removeIndexes = new HashSet<int>();

            foreach ((int index, record logRecord) in logRecords.Enumerate())
            {

                byte[][] dataBytesSequence = LogHandler.GetEnclosedSequences(logRecord.byteXMLSequence, Configuration.ByteSequences.logXMLDataOpeningSequence, Configuration.ByteSequences.logXMLDataClosingSequence);

                //Throw an error if there are multiple data elements in the same record
                if (dataBytesSequence.Length != 1)
                {
                    Program.LogEvent($"Chyba 107: V súbore {logObject.fileName} v XML log-u č. {index + 1} sa nenachádza element <Data> alebo sa v ňom nachádza viac ako 1-krát.");
                    removeIndexes.Add(index);
                    continue;
                }

                //Select the only available byte sequence
                logRecord.computedHash = IntegrityVerification.ComputeSha1Hash(dataBytesSequence[0]);

                //Veify integrity and resolve potential issues.
                if (!logRecord.computedHash.SequenceEqual(logRecord.XMLHash))
                {
                    bool keepRecord = LogHandler.BrokenIntegrityResolve(logRecord, logObject);
                    if (!keepRecord)
                    {
                        Program.LogEvent($"Záznam č. {index + 1}. súboru {logObject.filePath} s poškodenou integritou nebude uložený.");
                        removeIndexes.Add(index);
                        continue;
                    }
                    Program.LogEvent($"Záznam č. {index + 1}. súboru {logObject.filePath} s poškodenou integritou {LogHandler.HexByteToString(logRecord.computedHash)} != {LogHandler.HexByteToString(logRecord.XMLHash)} bude uložený.");
                }
            }

            //If there are any records to be removed, remove them
            if (removeIndexes.Count() != 0)
            {
                logObject.logRecords = RemoveRecordsFromLog(logRecords, removeIndexes);
            }
            return;
        }


        //This method verifies whether the sequences in a log file has a valid XML structure 
        internal static void VerifyXMLRecordsStructure(LogClass logObject)
        {
            record[] logRecords = logObject.logRecords;
            HashSet<int> removeIndexes = new HashSet<int>();

            foreach ((int index, record logRecord) in logRecords.Enumerate())
            {

                byte[][] dataBytesSequence = LogHandler.GetEnclosedSequences(logRecord.byteXMLSequence, Configuration.ByteSequences.logRecordOpeningSequence, Configuration.ByteSequences.logXMLClosingSequence);

                //Select the only available byte sequence
                //Return an error if there are multiple sequences of the same file 
                if (dataBytesSequence.Length != 1)
                {
                    Program.LogEvent($"Chyba 107: V súbore {logObject.fileName} v XML log-u č. {index + 1} sa nenachádza element <Data> alebo sa v ňom nachádza viac ako 1-krát.");
                    removeIndexes.Add(index);
                    continue;
                }

                //Verify structure, if it is valid go to the following record
                bool isValid = StructureVerification.XMLValidator.ValidateXMLStructure(dataBytesSequence[0], errorMessage: $"Štruktúra záznamu {index + 1} je poškodená");

                if (isValid)
                {
                    continue;
                }

                //if the structure is not valid, ask the user to validate
                bool keepRecord = LogHandler.BrokenXMLStructureResolve(logRecord, logObject);
                if (!keepRecord)
                {
                    Program.LogEvent($"Záznam č. {index + 1}. súboru {logObject.filePath} s poškodenou XML štruktúrov nebude uložený");
                    removeIndexes.Add(index);
                    continue;
                }
                Program.LogEvent($"Záznam č. {index + 1}. súboru {logObject.filePath} s poškodenou XML štruktúrov bude uložený.");

            }

            //If there are any records with broken XML structure to be removed, remove them
            if (removeIndexes.Count() != 0)
            {
                logObject.logRecords = RemoveRecordsFromLog(logRecords, removeIndexes);
            }

            return;
        }

        internal static void VerifyXMLRecordsSizing(LogClass logObject)
        {
            record[] logRecords = logObject.logRecords;
            bool checkMin = Configuration.Settings.verifyMinimumRecordSize;
            bool checkMax = Configuration.Settings.verifyMaximumRecordSize;

            int minSize = Configuration.Settings.minimumRecordSize;
            int maxSize = Configuration.Settings.maximumRecordSize;




            try
            {
                foreach ((int index, record logRecord) in logRecords.Enumerate())
                {
                    int recordLen = logRecord.byteXMLSequence.Length;

                    if (checkMin && recordLen < minSize)
                    {
                        throw new SizeInvalid($"Záznam č. {index + 1} súboru {logObject.filePath} má {recordLen} znakov čo je menej ako minimálna dĺžka {minSize} znakov");
                    }

                    if (checkMax && recordLen > maxSize)
                    {
                        throw new SizeInvalid($"Záznam č. {index + 1} súboru {logObject.filePath} má {recordLen} znakov čo je viac ako maximálna dĺžka {maxSize} znakov");
                    }
                }
            }catch(SizeInvalid ex)
            {
                Program.LogEvent(ex.Message);
                Program.LogEvent($"Záznamy súboru {logObject.filePath} nebudú uložené ");
                logObject.logRecords = RemoveAllRecordsFromLog();
            }



        }

        internal static void VerifyXMLRecordUniqueness(LogClass logObject)
        {
            record[] logRecords = logObject.logRecords;
            HashSet<int> removeIndexes = new HashSet<int>();

            foreach ((int index, record logRecord) in logRecords.Enumerate())
            {
                string recordHash = LogHandler.HexByteToString(logRecord.XMLHash);
                if (Configuration.instanceDependent.registeredHashes.Contains(recordHash))
                {
                    removeIndexes.Add(index);
                    Program.LogEvent($"Hash záznamu č. {index + 1} súboru {logObject.filePath} bol už registrovaný.", onlyVerbose:true);
                }
                Configuration.instanceDependent.registeredHashes.Add(recordHash);
            }

            //If there are any records with broken XML structure to be removed, remove them
            if (removeIndexes.Count() != 0)
            {
                logObject.logRecords = RemoveRecordsFromLog(logRecords, removeIndexes);
            }

        }


    }

}
