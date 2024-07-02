using ProcessLogs.logs;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProcessLogs.utilities
{
    internal class SaveLogs
    {


        internal static void RemoveDuplicateAggregateFile()
        {
            string duplicateFilePathXML = Configuration.AggregateFile.duplicatefilePathXML;

            if (duplicateFilePathXML == String.Empty)
            {
                Program.LogEvent("Duplikát agregátneho súboru neexistuje, nebol odstránený.", onlyVerbose:true);
                return;
            }

            try
            {
                File.Delete(duplicateFilePathXML);
            Program.LogEvent("Duplikát agregátneho súboru bol úspešne odstránený.", onlyVerbose: true);
            }
            catch(Exception ex)
            {
                Program.LogEvent($"Odstraňovanie duplikátu agregátneho súboru zlyhalo, odstráňte ho prosím manuálne. Cesta: {duplicateFilePathXML}");
                Program.LogEvent(ex.Message);
            }
        }

        internal static void DupplicateAggregateFile()
        {
            string originalFile = Configuration.AggregateFile.filePath;
            string originalDirectory = Path.GetDirectoryName(originalFile);
            string originalFileWithoutExt = Path.GetFileName(originalFile);
            int len = originalFileWithoutExt.Length -4 ;

            string originalFileName = originalFileWithoutExt.Substring(0, len);
            string duplicateFile = originalDirectory + "\\" + originalFileName + ".tmp";



            AccessControlUtils.VerifyFileReadPermission(originalFile);

            Program.LogEvent("Vytváranie dočasného agregátného súboru", onlyVerbose: true);


            // Create a FileStream to read the source file
            using (FileStream sourceStream = new FileStream(Configuration.AggregateFile.filePath, FileMode.Open, FileAccess.Read))
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
                Configuration.AggregateFile.duplicatefilePathXML = duplicateFile;
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
            string filePath = Configuration.AggregateFile.duplicatefilePathXML;
            int aggregateXMLClosingSequenceLength = Configuration.ByteSequences.aggregateXMLClosingSequence.Length;

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                long fileLength = fileStream.Length;
                long truncatedFileLength = fileStream.Length - aggregateXMLClosingSequenceLength;
                fileStream.SetLength(truncatedFileLength);
            }
        }


        internal static void AppendLogToDuplicateAggregateFile(LogClass logObject, FileStream fileStream)
        {
            string filePath = Configuration.AggregateFile.duplicatefilePathXML;
            foreach((int recordIndex, LogClass.record logRecord) in logObject.logRecords.Enumerate())
            {
                //Copy only XML path excluding the XML definition (<?xml version="1.0" encoding="UTF-8"?>)
                int InitialByteXMLSequenceLength = logRecord.byteXMLSequence.Length;

                int XMLDefinitionLength = Configuration.ByteSequences.logRecordOpeningSequence.Length;
                int SavedByteXMLSequenceLength = InitialByteXMLSequenceLength - XMLDefinitionLength;

                byte[] savedSequence = new byte[SavedByteXMLSequenceLength];
                //Create array that is about to be saved from the array with XML definition
                Array.Copy(logRecord.byteXMLSequence,XMLDefinitionLength, savedSequence,0 ,SavedByteXMLSequenceLength);

                //Save the shortened array
                Configuration.instanceDependent.addedLength += SavedByteXMLSequenceLength;  
                fileStream.Write(savedSequence, 0, SavedByteXMLSequenceLength);
            }

        }



        //Append closing sequence to aggregate file without having to load it into memory
        internal static void AppendClosingSequence()
        {
            string filePath = Configuration.AggregateFile.duplicatefilePathXML;
            int aggregateXMLClosingSequenceLength = Configuration.ByteSequences.aggregateXMLClosingSequence.Length;

            using (var fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                fileStream.Write(Configuration.ByteSequences.aggregateXMLClosingSequence, 0, aggregateXMLClosingSequenceLength);
            }
        }


        internal static void SaveTempFile()
        {

           
            
            string originalFile = Configuration.AggregateFile.filePath;
            long originalFileLength = new FileInfo(originalFile).Length;

            string duplicateFile = Configuration.AggregateFile.duplicatefilePathXML;
            long duplicateFileLength = new FileInfo(duplicateFile).Length;
            long expectedLength = originalFileLength + Configuration.instanceDependent.addedLength;

            //Verify that all bytes have been written to the duplicate file 
            if(expectedLength == duplicateFileLength)
            {
                Program.LogEvent("Duplikát agregátneho súboru má správnu dĺžku.");
            }
            else
            {
                RemoveDuplicateAggregateFile();
                throw new Exception("Do agregátneho súboru neboli zapísané všetky bajty. Zopakujte proces znovu.");
            }



            //Verify the structure of duplicate aggregate XML file before rewriting the original (optional)
            if (Configuration.Settings.verifyAggregateXMLStructureOnClose)
            {
                //HasCorrectXMLStructure returns false if the structure is not valid
                if (!StructureVerification.XMLValidator.ValidateXMLStructure(duplicateFile, "Štruktúra agregátneho XML po zápise logov je poškodená, spracované logy sa nezapíšu!", checkAggregateFileStructure: true))
                {
                    RemoveDuplicateAggregateFile();
                    return;
                }
                Program.LogEvent("Štruktúra agregátneho XML po zápise logov je platná.");

            }



            //Before deleting the file, make sure that the file is not opened and is movable
            string duplicateFileSecondPath = duplicateFile + "a";

            File.Move(duplicateFile, duplicateFileSecondPath);

            //if there is not an error moving duplicate file to second location, proceed with removing the original file 
            File.Delete(originalFile);

            File.Move(duplicateFileSecondPath, originalFile);

            Program.LogEvent("Súbory boli spracované a zmeny v agregátnom súbore uložené.");

            return;

            
            

        }

    }
}
