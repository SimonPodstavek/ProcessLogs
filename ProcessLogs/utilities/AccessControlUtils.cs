using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using System.Security.Policy;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;


namespace ProcessLogs.utilities
{
    internal static class AccessControlUtils
    {
        // Check if the user has access to the directory
        internal static bool VerifyDirReadPermission(string dirPath)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
                Directory.GetDirectories(dirPath);
                return true;

            }
            catch(UnauthorizedAccessException)
            {
                Program.LogEvent("Chyba 101: Pre adresár " + dirPath + " nemáte dostatočné povolenia.");
                return false;
            }
            catch(DirectoryNotFoundException)
            {
                Program.LogEvent("Chyba 100: Adresár " + dirPath + " neexistuje.");
                return false;
            }
            catch(Exception err)
            {
                Program.LogEvent("Chyba: Pri overení prístupu k adresáru " + dirPath + " sa vyskytla neočakávaná chyba " + err + " .");
                return false;
            }
        }


        // Check if the user has access to the file
        internal static bool VerifyFileReadPermission(string filepath)
        {
            try
            {
                //Open a file and read a first character to verify read permissions.
                FileStream fileStream = File.OpenRead(filepath);
                int firstChar = fileStream.ReadByte();
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                Program.LogEvent($"Chyba 101: Pre súbor {filepath} nemáte dostatočné povolenia.");
                return false;
            }
            catch (FileNotFoundException)
            {
                Program.LogEvent($"Chyba 102: Súbor {filepath} neexistuje.");
                return false;
            }
            catch (Exception err)
            {
                Program.LogEvent($"Chyba: Pri overení prístupu k súboru {filepath} sa vyskytla neočakávaná chyba: " + err);
                return false;
            }

        }

    }

    internal static class IntegrityVerification
    {
        //Checks that structure of leaf directories matches expected form
        internal static bool VerifyLeafDirectoriesStructure(string[] Leafdirectories)
        {
            string directoryStructureRegex = @".*\\20\d{2}\\\d{2}$";
            Regex regex = new Regex(directoryStructureRegex);

            foreach(string leafDirectory in Leafdirectories)
            {
                MatchCollection matches = regex.Matches(leafDirectory);
                if(matches.Count == 0)
                {
                    DialogResult continueProcessing = MessageBox.Show("Chyba 103: Koreňový adresár "+ Configuration.rootDirectory+ " nespĺňa požadovanú štruktúru. Identifikovaný adresár: " +
                        leafDirectory + ". Prajete si chybu ignorovať a pokračovať?", "Nesprávna štruktúra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(continueProcessing == DialogResult.No)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

            }
            return true;
        }
        //This method computes SHA1 integrity hash for the given data section of XML bytes
        internal static byte[] ComputeSha1Hash(byte[] input)
        {
            byte[] output;

            SHA1 sha1 = SHA1.Create();
            output = sha1.ComputeHash(input);
            return output;

        }

    }




    internal static class Iterator
    {
        //Get subdirectories(leaf directories) for given root directory
        private static string[] GetLeafDirectories(string dirPath)
        {

            List<string> Leafdirectories = new List<string>();

            string[] subdirectories = Directory.GetDirectories(dirPath);


            //Exit recursion for the given branch
            if (subdirectories.Length == 0)
            {
                return new string[] { dirPath };
            }

            //If a branch has further subdirectories,iterate over them 
            foreach (string subdir in subdirectories)
            {
                if (AccessControlUtils.VerifyDirReadPermission(subdir))
                {
                    Leafdirectories.AddRange(GetLeafDirectories(subdir));
                }
                else
                {
                    throw new Exception($"Na čítanie obsahu adresára {subdir} nemáte dostatočné povolenia");
                }
                
            }
            return Leafdirectories.ToArray();
        }

        //Get path for log files from leaf directories
        private static IEnumerable<string> GetLogPathsFromRootDirectory(string dirPath)
        {
            //Iterate over all files in root directory
            IEnumerable<string> NumerableLogPaths = Directory.EnumerateFiles(dirPath, "*.log", SearchOption.AllDirectories);
            return NumerableLogPaths;
        }


        //This method finds paths to all paths in leaf directories. It is later used to verify that all files in the directory are of .log type
        private static IEnumerable<string> GetAllFilesFromRootDirectory(string dirPath)
        {
            //Iterate over all files in root directory
            IEnumerable<string> NumerableLogPaths = Directory.EnumerateFiles(dirPath, "*.*", SearchOption.AllDirectories);
            return NumerableLogPaths;

        }


        internal static void GetPathsFromRoot(string dirPath)
        {

            void fetchingDirectoriesFailed()
            {
                Configuration.instanceDependent.LogPaths = Enumerable.Empty<string>();
                Configuration.instanceDependent.AllPaths = Enumerable.Empty<string>();
                return;
            }


            //If read permission is not granted for root directory, put all further processing on halt
            if (!AccessControlUtils.VerifyDirReadPermission(dirPath)) { fetchingDirectoriesFailed(); }

            string[] LeafDirectories = GetLeafDirectories(dirPath);


            if (!IntegrityVerification.VerifyLeafDirectoriesStructure(LeafDirectories)) { fetchingDirectoriesFailed(); }


            Configuration.instanceDependent.LogPaths = GetLogPathsFromRootDirectory(Configuration.rootDirectory);
            Configuration.instanceDependent.AllPaths = GetAllFilesFromRootDirectory(Configuration.rootDirectory);
        }

    }
}

