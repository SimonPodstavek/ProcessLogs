using ProcessLogs.logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
namespace ProcessLogs.utilities
{
    //Singleton process class is used to store globally required variables.
    //It also provides data from logging and statistics
    internal static class Configuration
    {

        internal static List<logs.LogClass> globalLogs;

        internal static class Settings
        {
            internal static bool isVerbose = true;
        }

        internal static class ByteSequences
        {
            //Sequences utilized to identify offset and end of XML byte stream
            internal static byte[] logXMLOpeningSequence = Encoding.UTF8.GetBytes("<?xml version=\"1.0\" encoding=\"UTF-8\"?><LogEntry>");
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

        }


        internal static int CountAndRemoveAllPaths()
        {
            int count = AllPaths.Count();
            AllPaths = Enumerable.Empty<string>();
            return count;
        }


        internal static void iniProcess(Button initiateButton)
        {
            NewMethod();
            initiateButton.Text = "Spracovať";
        }

        private static void NewMethod()
        {
            IsRunning = false;
        }

        internal static void stopProcess(Button initiateButton)
        {
            IsRunning = true;
            initiateButton.Text = "Zastaviť";
        }

        internal static int CountLogPaths()
        {
            return LogPaths.Count();
        }

        //Path of an aggregate XML file
        internal static string originalfilePathXML = string.Empty;
        internal static string duplicatefilePathXML = string.Empty;

        internal static string XMLDirectoryPath = string.Empty;
        //Path to a directory with LeafDirectories cotaining logs
        internal static string rootDirectory = string.Empty;
        internal static IEnumerable<string> LogPaths;
        internal static IEnumerable<string> AllPaths;
        internal static volatile bool IsRunning = false;

        //Total length of appended XML contnet
        internal static long addedLength = 0;





    }

}
