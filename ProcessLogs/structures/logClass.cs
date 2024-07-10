using Microsoft.SqlServer.Server;
using ProcessLogs.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
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
        internal byte[] LogContent, XMLFilePath;
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
            this.XMLFilePath = GetRelativeLogPath(filePath);
        }


        internal static byte[] GetRelativeLogPath(string filePath)
        {

         
            Match match = Regex.Match(filePath, Configuration.logRelativePathRegex);
            
            if(match.Success)
            {
                return Encoding.UTF8.GetBytes($"<FilePath>{match.Groups[1]}</FilePath>");
            }
  
            return Encoding.UTF8.GetBytes("<FilePath>Incorrect root directory structure</FilePath>");
            


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
        /// This module appends Addition element after the first occurance of the Lookup element
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
            Array.Copy(additionElement, 0, resultBytes, insertBytePosition, additionLen);
            Array.Copy(originalBytes, insertBytePosition, resultBytes, insertBytePosition + additionLen, originalLen - insertBytePosition);


            return resultBytes;
        }


        /// <summary>
        /// This module removes whitespaces from hash string
        /// </summary>
        internal static string FormatHash(string hashString)
        {
            return hashString.Replace(Encoding.UTF8.GetString(Configuration.ByteSequences.whiteSpace), String.Empty);
        }


        //This method removes records with IDs in removeList from an array
        public static record[] StripRecordsFromArray(record[] originalArray, HashSet<int> removeList)
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




        private interface IVerification
        {
            bool isActive();

            bool onExceptionRemoveAll();

            int? VerificationMethod(int index, record logRecord, LogClass logObject);
        }



        private class MetaDataAdder : IVerification
        {
            public bool onExceptionRemoveAll()
            {
                return true;
            }
            public bool isActive()
            {
                return true;
            }

            public int? VerificationMethod(int index, record logRecord, LogClass logObject)
            {

                try
                {
                    byte[] XMLByteRepresentation = logRecord.byteXMLSequence;

                    logRecord.byteXMLSequence =  LogClass.InsertElementAfterLookup(XMLByteRepresentation, logObject.XMLFilePath, Configuration.ByteSequences.logXMLOpeningSequence);
                    return null;
                }
                catch(Exception)
                {
                    return 0;

                }


            }


        }

        //This method verifies whether the records in a log file has a valid XML structure  (optional)
        private class VerifyXMLRecordStructure : IVerification
        {
            public bool onExceptionRemoveAll()
            {
                return false;
            }

            public bool isActive()
            {
                return Configuration.Settings.verifyLogXMLStructure;
            }

            public int? VerificationMethod(int index, record logRecord, LogClass logObject)
            {
                byte[][] dataBytesSequence = LogHandler.GetEnclosedSequences(logRecord.byteXMLSequence, Configuration.ByteSequences.logRecordOpeningSequence, Configuration.ByteSequences.logXMLClosingSequence);

                //Select the only available byte sequence
                //Return an error if there are multiple sequences of the same file 
                if (dataBytesSequence.Length != 1)
                {
                    Program.LogEvent($"Chyba 107: V súbore {logObject.fileName} v XML log-u č. {index + 1} sa nenachádza element <Data> alebo sa v ňom nachádza viac ako 1-krát.");
                    return index;
                }

                //Verify structure, if it is valid go to the next record
                bool isValid = StructureVerification.XMLValidator.ValidateXMLStructure(dataBytesSequence[0], errorMessage: $"Štruktúra záznamu {index + 1} je poškodená");

                if (isValid)
                {
                    return null;
                }

                //if the structure is not valid, ask the user to validate
                bool keepRecord = LogHandler.BrokenXMLStructureResolve(logRecord, logObject);
                if (!keepRecord)
                {
                    Program.LogEvent($"Záznam č. {index + 1}. súboru {logObject.filePath} s poškodenou XML štruktúrov nebude uložený");
                    return index;
                }
                Program.LogEvent($"Záznam č. {index + 1}. súboru {logObject.filePath} s poškodenou XML štruktúrov bude uložený.");
                return null;

            }

        }



        //This method locates Hash sequence in each record by sequences defined in Configuration.ByteSequences
        private class FindXMLRecordHash : IVerification
        {

            public bool onExceptionRemoveAll()
            {
                return true;
            }

            public bool isActive()
            {
                return Configuration.Settings.verifyHash;
            }

            public int? VerificationMethod(int index, record logRecord, LogClass logObject)
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
                return null;
            }
        }


        //This method verifies whether the records in a log file have a right hash  (optional)
        private class VerifyRecordIntegrity: IVerification
        {

            public bool onExceptionRemoveAll()
            {
                return false;
            }

            public bool isActive()
            {
                return Configuration.Settings.verifyHash;
            }

            public int? VerificationMethod(int index, record logRecord, LogClass logObject)
            {

                byte[][] dataBytesSequence = LogHandler.GetEnclosedSequences(logRecord.byteXMLSequence, Configuration.ByteSequences.logXMLDataOpeningSequence, Configuration.ByteSequences.logXMLDataClosingSequence);

                //Throw an error if there are multiple data elements in the same record
                if (dataBytesSequence.Length != 1)
                {
                    Program.LogEvent($"Chyba 107: V súbore {logObject.fileName} v XML log-u č. {index + 1} sa nenachádza element <Data> alebo sa v ňom nachádza viac ako 1-krát.");;
                    return index;
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
                        return index;
                    }
                    Program.LogEvent($"Záznam č. {index + 1}. súboru {logObject.filePath} s poškodenou integritou {LogHandler.HexByteToString(logRecord.computedHash)} != {LogHandler.HexByteToString(logRecord.XMLHash)} bude uložený.");
                }

                return null;
            }

        }


        //This method verifies that the record in a log file has at least the minimum size defined by user (optional)

        private class VerifyXMLRecordMinimumSize : IVerification
        {
            public bool onExceptionRemoveAll()
            {
                return true;
            }

            public bool isActive()
            {
                return Configuration.Settings.verifyMinimumRecordSize;
            }

            public int? VerificationMethod(int index, record logRecord, LogClass logObject)
            {
                int minSize = Configuration.Settings.minimumRecordSize;
                int recordLen = logRecord.byteXMLSequence.Length;

                if (recordLen < minSize)
                {
                    Program.LogEvent($"Chyba 116: Záznam č. {index + 1} súboru {logObject.filePath} má {recordLen} znakov čo je menej ako minimálna dĺžka {minSize} znakov");
                    return index;
                }
                return null;

            }
        }


        private class VerifyXMLRecordMaximumSize : IVerification
        {
            public bool onExceptionRemoveAll()
            {
                return true;
            }

            public bool isActive()
            {
                return Configuration.Settings.verifyMaximumRecordSize;
            }

            public int? VerificationMethod(int index, record logRecord, LogClass logObject)
            {
                int maxSize = Configuration.Settings.maximumRecordSize;
                int recordLen = logRecord.byteXMLSequence.Length;

                if (recordLen > maxSize)
                {
                    Program.LogEvent($"Chyba 116: Záznam č. {index + 1} súboru {logObject.filePath} má {recordLen} znakov čo je viac ako maximálna dĺžka {maxSize} znakov");
                    return index;
                }
                return null;

            }
        }


        private class VerifyXMLRecordUniqueness : IVerification
        {
            public bool isActive()
            {
                return Configuration.Settings.preventHashDuplicity;
            }

            public bool onExceptionRemoveAll()
            {
                return false;
            }


            public int? VerificationMethod(int index, record logRecord, LogClass logObject)
            {
                string recordHash = LogHandler.HexByteToString(logRecord.XMLHash);
                if (Configuration.instanceDependent.registeredHashes.Contains(recordHash))
                {
                    Program.LogEvent($"Chyba 114: Hash záznamu č. {index + 1} súboru {logObject.filePath} bol už registrovaný.", onlyVerbose: true);
                    return index;
                }
                Configuration.instanceDependent.registeredHashes.Add(recordHash);
                return null;
            }

        }



        internal static void LogIterator(LogClass logObject)
        {
            record[] logRecords = logObject.logRecords;
            HashSet<int> removeIndexes = new HashSet<int>();

            //Define verifications
            List<IVerification> verifications = new List<IVerification> 
            { new MetaDataAdder(), new VerifyXMLRecordStructure(), new FindXMLRecordHash(),
              new VerifyRecordIntegrity(), new VerifyXMLRecordMinimumSize(),
              new VerifyXMLRecordMaximumSize(), new VerifyXMLRecordUniqueness() };

            //Iterate over Verificators and run only those that are required
            foreach (IVerification verification in verifications)
            {
                //Skip the iteration of a verificator if it's not required
                if (!(verification.isActive())) { continue; }

                //Iterate over every record and make necessary checks
                foreach ((int index, record logRecord) in logRecords.Enumerate())
                {
                    if(verification.VerificationMethod(index, logRecord, logObject) != null)
                    {
                        removeIndexes.Add(index);

                        if (verification.onExceptionRemoveAll())
                        {
                            removeIndexes = new HashSet<int>(Enumerable.Range(0, logRecords.Length)); ;
                            break;
                        }

                    }
                }
                //If there are any records that need to be removed, remove them
                //In case the verifiation method forces removal of all records in case of exception, the records will be removed and logObject will not be processed further
                if(removeIndexes.Count != 0)
                {
                    logObject.logRecords = StripRecordsFromArray(logRecords, removeIndexes);
                }


                }
            }



    }

}
