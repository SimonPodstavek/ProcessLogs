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

        static internal class Settings
        {
            static bool verboseLog = true;
        }

        static internal class ByteSequences
        {
            //Sequence utilized to identify offset of XML byte stream
            internal static byte[] logXMLOpeningSequence = Encoding.UTF8.GetBytes("<?xml version=\"1.0\" encoding=\"UTF-8\"?><LogEntry>");

            //Sequence utilized to identify end of XML byte stream
            internal static byte[] logXMLClosingSequence = Encoding.UTF8.GetBytes("</LogEntry>");

        }


        static internal int CountAndRemoveAllPaths()
        {
            int count = Configuration.AllPaths.Count;
            Configuration.AllPaths = new List<string>();
            return count;
        }

        
        static internal void iniProcess(Button initiateButton)
        {
            Configuration.IsRunning = false;
            initiateButton.Text = "Spracovať";
        }

        static internal void stopProcess(Button initiateButton)
        {
            Configuration.IsRunning = true;
            initiateButton.Text = "Zastaviť";
        }

        static internal int CountLogPaths()
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
