using ProcessLogs.logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ProcessLogs.utilities
{
    //Singleton process class is used to store globally required variables.
    //It also provides data from logging and statistics
    internal static class Configuration
    {

        internal static IEnumerable<Logs> globalLogs = new List<Logs>();

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



        }


        internal static int CountAndRemoveAllPaths()
        {
            int count = Configuration.AllPaths.Count;
            Configuration.AllPaths = new List<string>();
            return count;
        }


        internal static void iniProcess(Button initiateButton)
        {
            Configuration.IsRunning = false;
            initiateButton.Text = "Spracovať";
        }

        internal static void stopProcess(Button initiateButton)
        {
            Configuration.IsRunning = true;
            initiateButton.Text = "Zastaviť";
        }

        internal static int CountLogPaths()
        {
            return Configuration.LogPaths.Count;
        }

        //Path of an aggregate XML file
        internal static string filePathXML = string.Empty;
        //Path to a directory with LeafDirectories cotaining logs
        internal static string rootDirectory = string.Empty;
        internal static List<string> LogPaths = new List<string>();
        internal static List<string> AllPaths = new List<string>();
        internal static volatile bool IsRunning = false;

        
        
    
    }

}
