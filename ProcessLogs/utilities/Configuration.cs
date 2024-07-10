using ProcessLogs.logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
namespace ProcessLogs.utilities
{
    //Configuration class is used to store globally required variables.
    //It also provides data from logging and statistics
    internal static class Configuration
    {

        internal static InstanceDependent instanceDependent;

        //Data dependent on instance (on repeated processing run)
        public class InstanceDependent
        {
            internal HashSet<string> registeredHashes = new HashSet<string>();

            internal List<LogClass> globalLogs;

            //Total length of appended XML contnet for the purposes of verifying whether a correct amount of bytes has been written to an aggregate file
            internal long addedLength = 0;

            internal List<string> LogPaths;
            internal List<string> AllPaths;

        }

        //Paths to the aggregate XML file
        internal static class AggregateFile
        {
            internal static string filePath = String.Empty;
            internal static string duplicatefilePathXML = String.Empty;
        }



        //Path to a directory with LeafDirectories cotaining logs
        internal static string rootDirectory = String.Empty;

        //Reflects the state of user's selection.
        internal static volatile bool isRunning = false;

        //This regex defines the structure of selected root directory
        internal static string directoryStructureRegex = @".*\\20\d{2}\\\d{2}$";

        //This regex defines the exected structure of relative log file path
        internal static string logRelativePathRegex = @".*\\(20\d{2}\\\d{2}\\.*\.log)$";




        internal static class Settings
        {
            internal static bool isVerbose = false;
            internal static bool verifyHash = false;
            internal static bool verifyLogXMLStructure = false;
            internal static bool verifyAggregateXMLStructureOnLoad = false;
            internal static bool verifyAggregateXMLStructureOnClose = false;

            internal static int minimumRecordSize = 0;
            internal static int maximumRecordSize = 0;

            internal static bool verifyMinimumRecordSize = false;
            internal static bool verifyMaximumRecordSize = false;

            internal static bool preventHashDuplicity = false;

        }

        internal static class ByteSequences
        {

            //Whitespace identifier
            internal static byte[] whiteSpace = { 0x20 };

            //Sequences utilized to identify offset and end of XML byte stream
            internal static byte[] logXMLOpeningSequence = Encoding.UTF8.GetBytes("<LogEntry>");
            internal static byte[] logXMLClosingSequence = Encoding.UTF8.GetBytes("</LogEntry>");


            //Sequences utilized to identify offset and end of XML data byte stream
            internal static byte[] logXMLDataOpeningSequence = Encoding.UTF8.GetBytes("<Data>");
            internal static byte[] logXMLDataClosingSequence = Encoding.UTF8.GetBytes("</Data>");

            //Sequences utilized to identify offset and end of XML hash byte stream
            internal static byte[] logXMLHashOpeningSequence = Encoding.UTF8.GetBytes("<Hash>");
            internal static byte[] logXMLHashClosingSequence = Encoding.UTF8.GetBytes("</Hash>");

            //Sequences utilized to identify start and end of an XML aggregate file
            internal static byte[] aggregateXMLOpeningSequence = Encoding.UTF8.GetBytes("<AGGREGATEXML>");
            internal static byte[] aggregateXMLClosingSequence = Encoding.UTF8.GetBytes("</AGGREGATEXML>");

            //Sequences utilized to identify beginning of entire XML record
            internal static byte[] logRecordOpeningSequence = Encoding.UTF8.GetBytes("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");

            //Sequences utilized to indicate that the user has altered contents of XML while parsing the file.
            internal static byte[] hashModifiedOnParse = Encoding.UTF8.GetBytes("<ModifiedOnParse>Broken hash permitted</ModifiedOnParse>");
            internal static byte[] XMLModifiedOnParse = Encoding.UTF8.GetBytes("<ModifiedOnParse>XML structure outside Data element modified</ModifiedOnParse>");



        }


        //Make more efficient
        internal static int CountAndRemoveAllPaths()
        {
            int count = instanceDependent.AllPaths.Count();
            instanceDependent.AllPaths = null;
            return count;
        }


        internal static void iniProcess(Button initiateButton)
        {
            isRunning = true;
            initiateButton.Text = "Zastaviť";
        }

        internal static void stopProcess(Button initiateButton)
        {
            isRunning = false;
            initiateButton.Text = "Spracovať";
        }

        internal static int CountLogPaths()
        {
            return instanceDependent.LogPaths.Count();
        }


    }

}
