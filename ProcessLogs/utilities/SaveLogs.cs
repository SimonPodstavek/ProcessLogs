using System;
using System.Collections.Generic;
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
            string sourceFile = Configuration.filePathXML;
            string sourceDirectory = Path.GetDirectoryName(sourceFile);
            string sourceFileWithoutExt = Path.GetFileName(sourceFile);
            int len = sourceFileWithoutExt.Length -4 ;

            string sourceFileName = sourceFileWithoutExt.Substring(0, len);
            string destinationFile = sourceDirectory + "\\" + sourceFileName + "_tmp.xml";



            Configuration.XMLDirectoryPath = Path.GetDirectoryName(Configuration.filePathXML);


            // Create a FileStream to read the source file
            using (FileStream sourceStream = new FileStream(Configuration.filePathXML, FileMode.Open, FileAccess.Read))
            {
                // Create a FileStream to write to the destination file
                using (FileStream destinationStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
                {
                    // Copy the contents of the source file to the destination file
                    sourceStream.CopyTo(destinationStream);
                }
            }
        }





    }
}
