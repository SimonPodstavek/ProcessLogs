using ProcessLogs.logs;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessLogs.utilities
{
    internal class SaveLogs
    {
        internal static void DupplicateAggregateFile()
        {
            string originalFile = Configuration.originalfilePathXML;
            string originalDirectory = Path.GetDirectoryName(originalFile);
            string originalFileWithoutExt = Path.GetFileName(originalFile);
            int len = originalFileWithoutExt.Length -4 ;

            string originalFileName = originalFileWithoutExt.Substring(0, len);
            string duplicateFile = originalDirectory + "\\" + originalFileName + ".tmp";

            AccessControlUtils.VerifyFileReadPermission(originalFile);

            Program.LogEvent("Vytváranie dočasného agregátného súboru");

            Configuration.XMLDirectoryPath = Path.GetDirectoryName(Configuration.originalfilePathXML);


            // Create a FileStream to read the source file
            using (FileStream sourceStream = new FileStream(Configuration.originalfilePathXML, FileMode.Open, FileAccess.Read))
            {
                // Create a FileStream to write to the destination file
                using (FileStream destinationStream = new FileStream(duplicateFile, FileMode.Create, FileAccess.Write))
                {
                    // Copy the contents of the source file to the destination file
                    sourceStream.CopyTo(destinationStream);
                }
            }

            long originalFileSize = new FileInfo(originalFile).Length;
            long duplicateFileSize = new FileInfo(duplicateFile).Length;

            if (originalFileSize == duplicateFileSize)
            {
                Program.LogEvent("Vytváranie dočasného agregátného súboru: úspech");
                Configuration.duplicatefilePathXML = duplicateFile;
            }
            else
            {
                throw new Exception("Chyba 113: Zdrojový a dočasný agregátny súbor nemajú rovnakú veľkosť.");
            }


            return;

        }

        internal static void truncateAggregateXML()
        {

            //Shorten the length of an aggregate XML file by the length of the closing sequence
            string filePath = Configuration.duplicatefilePathXML;
            int aggregateXMLClosingSequenceLength = Configuration.ByteSequences.aggregateXMLClosingSequence.Length;

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                long fileLength = fileStream.Length;
                long truncatedFileLength = fileStream.Length - aggregateXMLClosingSequenceLength;
                fileStream.SetLength(truncatedFileLength);
            }
        }


        internal static void AppendLogToTempAggregateFile(LogClass logObject, FileStream fileStream)
        {
            string filePath = Configuration.duplicatefilePathXML;
            foreach((int recordIndex, LogClass.record logRecord) in logObject.logRecords.Enumerate())
            {
                int byteXMLSequenceLength = logRecord.byteXMLSequence.Length;
                Configuration.addedLength += byteXMLSequenceLength;  
                fileStream.Write(logRecord.byteXMLSequence, 0, byteXMLSequenceLength);
            }

        }



            //fileStream.Write(Configuration.ByteSequences.aggregateXMLClosingSequence, 0, aggregateXMLClosingSequenceLength);

        internal static void AppendClosingSequence()
        {
            string filePath = Configuration.duplicatefilePathXML;
            int aggregateXMLClosingSequenceLength = Configuration.ByteSequences.aggregateXMLClosingSequence.Length;

            using (var fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                fileStream.Write(Configuration.ByteSequences.aggregateXMLClosingSequence, 0, aggregateXMLClosingSequenceLength);
            }
        }


        internal static void SaveTempFile()
        {
            Program.LogEvent("Verifikácia zapísaných dát");
            
            string originalFile = Configuration.originalfilePathXML;
            long originalFileLength = new FileInfo(originalFile).Length;

            string duplicateFile = Configuration.duplicatefilePathXML;
            long duplicateFileLength = new FileInfo(duplicateFile).Length;



            long expectedLength = originalFileLength + Configuration.addedLength;


            if(expectedLength == duplicateFileLength)
            {
                File.Delete(originalFile);
                File.Move(duplicateFile, originalFile);
            }
            else
            {
                File.Delete(duplicateFile);
                throw new Exception("Do agregátneho súboru neboli zapísané všetky bajty. Zopakujte proces znovu");
            }
            return;

            
            

        }

    }
}
