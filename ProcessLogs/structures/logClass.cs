using ProcessLogs.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProcessLogs.logs
{
    internal class LogClass
    {

        internal string filePath, fileName;
        internal byte[][] XMLSequences;
        internal byte[] LogContent;
        internal record[] logRecords;
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
            //internal string logContent;
            internal bool isValid = true;

        }
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
                    throw new Exception($"Chyba 108: Pri čítaní hash integrity XML súboru { logObject.filePath } sa vyskytla chyba.");
                }

                //Convert hash(hex) from byte to UTF-8 string.
                hashString = Encoding.UTF8.GetString(byteXMLHashes[0]);
                hashString = hashString.Substring(6, 40);

                //Split string and turn it into hash.
                try
                {
                    logRecord.XMLHash = LogHandler.HexStringToByteArray(hashString);
                }catch(Exception ex)
                {
                    throw new Exception($"Chyba 110: Konverzia hash z reťazca na byte zlyhala. pri zázname č. { index + 1 }.", ex);
                }
            }

            return;
        }

        public static record[] RemoveSectionsFromRecord(record[] originalArray, HashSet<int> removeList)
        {
            int len = originalArray.Length - removeList.Count();
            record[] res = new record[len];
            int pos =0;   
            foreach((int index, record item) in originalArray.Enumerate())
            {
                if (!removeList.Contains(index)) 
                {
                    res[pos] = item;
                }
            }
            return res;

        }

        internal static void VerifySequencesIntegrity(LogClass logObject)
        {   
            record[] logRecords = logObject.logRecords;
            HashSet<int> removeIndexes = new HashSet<int>();

            foreach ((int index, record logRecord) in logRecords.Enumerate())
            {

                byte[][] dataBytesSequence = LogHandler.GetEnclosedSequences(logRecord.byteXMLSequence, Configuration.ByteSequences.logXMLDataOpeningSequence, Configuration.ByteSequences.logXMLDataClosingSequence);


                //Return an error if there are multiple sequences of the same file 
                if (dataBytesSequence.Length != 1)
                {
                    throw new Exception($"Chyba 107: V súbore {logObject.fileName} v XML log-u č. { index + 1 } sa nenachádza element <Data> alebo sa v ňom nachádza viac ako 1-krát.");
                }

                //Select the only available byte sequence
                logRecord.computedHash = IntegrityVerification.ComputeSha1Hash(dataBytesSequence[0]);

                //Veify integrity and resolve potential issues.
                if (!logRecord.computedHash.SequenceEqual(logRecord.XMLHash))
                {
                    bool keepRecord = LogHandler.BrokenIntegrityResolve(logRecord, logObject);
                    if (!keepRecord)
                    {
                        //Remove the record !!!
                        removeIndexes.Add(index);
                        continue;
                    }
                    Program.LogEvent($"Záznam č. { index + 1 }. súboru { logObject.filePath } s poškodenou integritou {LogHandler.HexByteToString(logRecord.computedHash)} != {LogHandler.HexByteToString(logRecord.XMLHash)} bude uložený.");
                }
            }
            
            logObject.logRecords = RemoveSectionsFromRecord(logRecords, removeIndexes); 
            return;
        }


        //This method verifies whether the sequences in a log file have the right XML structure  UNFINISHED
        internal static void VerifyXMLSequencesStructure(LogClass logObject)
        {
            record[] logRecords = logObject.logRecords;
            HashSet<int> removeIndexes = new HashSet<int>();

            foreach ((int index, record logRecord) in logRecords.Enumerate())
            {

                byte[][] dataBytesSequence = LogHandler.GetEnclosedSequences(logRecord.byteXMLSequence, Configuration.ByteSequences.logXMLDataOpeningSequence, Configuration.ByteSequences.logXMLDataClosingSequence);

                //Select the only available byte sequence
                //Verify structure and resolve potential issues.
                try
                {
                    StructureVerification.VerifyXMLStructure(dataBytesSequence[0]);
                }
                catch (Exception ex)
                {
                    bool keepRecord = LogHandler.BrokenIntegrityResolve(logRecord, logObject);
                    if (!keepRecord)
                    {
                        //Remove the record !!!
                        removeIndexes.Add(index);
                        continue;
                    }
                    Program.LogEvent($"Záznam č. {index + 1}. súboru {logObject.filePath} s poškodenou integritou {LogHandler.HexByteToString(logRecord.computedHash)} != {LogHandler.HexByteToString(logRecord.XMLHash)} bude uložený.");
                }

            }
            return;
        }



        //internal static void ConvertRecordsToUtf8String (LogClass logObject)
        //{
        //    record[] LogRecords = logObject.logRecords;

        //    foreach((int index, record record) in LogRecords.Enumerate())
        //    {
        //        record.logContent = Encoding.UTF8.GetString(record.byteXMLSequence);
        //    }
        //}

    }
}
