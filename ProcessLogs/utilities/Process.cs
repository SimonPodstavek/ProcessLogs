using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessLogs.utilities
{
    //Singleton process class is used to store globally required variables.
    //It also provides data from logging and statistics
    internal static class Process
    {

        static internal class settings
        {
            static bool verboseLog = true;

        }

        internal static string filePathXML = string.Empty;
        internal static string rootDirectory = String.Empty;
        internal static List<string> LeafDirectories = new List<string>();
        internal static List<string> LogPaths = new List<string>();
        internal static List<string> AllPaths = new List<string>();
    }

}
