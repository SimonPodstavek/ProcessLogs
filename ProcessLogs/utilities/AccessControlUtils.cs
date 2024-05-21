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
                MessageBox.Show("Chyba 101: Pre adresár " + dirPath + " nemáte dostatočné povolenia, adresár bude preskočený.", "Nedostatočné povolenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch(DirectoryNotFoundException)
            {
                MessageBox.Show("Chyba 100: Adresár " + dirPath + " neexistuje.", "Neplatná cesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch(Exception err)
            {
                MessageBox.Show("Chyba: Pri overení prístupu k adresáru " + dirPath + " sa vyskytla neočakávaná chyba " + err + " .", "Neočakávaná chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Chyba 101: Pre súbor " + filepath + " nemáte dostatočné povolenia, súbor bude preskočený.", "Nedostatočné povolenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Chyba 102: Súbor " + filepath + "neexistuje.", "Neplatná cesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception err)
            {
                MessageBox.Show("Chyba: Pri overení prístupu k súboru " + filepath + " sa vyskytla neočakávaná chyba " + err + " ." , "Neočakávaná chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

    }

    internal static class IntegrityVerification
    {
        //Checks that structure of leaf directories matches expected form
        internal static bool VerifyLeafDirectoriesIntegrity(string[] Leafdirectories)
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
            string stringOutput = String.Empty;
            byte[] output = new byte[20];

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


            if (subdirectories.Length == 0)
            {
                return new string[] { dirPath };
            }

            foreach (string subdir in subdirectories)
            {
                if (AccessControlUtils.VerifyDirReadPermission(subdir))
                {
                    Leafdirectories.AddRange(GetLeafDirectories(subdir));
                }
                Leafdirectories = new List<string>();
                break;
            }
            return Leafdirectories.ToArray();
        }

        //Get path for log files from leaf directories
        private static List<string> GetLogPathsFromRootDirectory(string dirPath)
        {
            List<string> LogPaths = new List<string>();
            //Iterate over all files in root directory
            IEnumerable<string> NumerableLogPaths = Directory.EnumerateFiles(dirPath, "*.log", SearchOption.AllDirectories);
            LogPaths = NumerableLogPaths.ToList();
            return LogPaths;

        }


        //This method finds paths to all paths in leaf directories. It is later used to verify that all files in the directory are of .log type
        private static List<string> GetAllFilesFromRootDirectory(string dirPath)
        {
            List<string> AllLogPaths = new List<string>();

            //Iterate over all files in root directory
            IEnumerable<string> NumerableLogPaths = Directory.EnumerateFiles(dirPath, "*.*", SearchOption.AllDirectories);
            AllLogPaths = NumerableLogPaths.ToList();
            return AllLogPaths;

        }


        internal static void GetLogPathsFromRoot(string dirPath)
        {

            //Read permission not granted for root directory
            if (!AccessControlUtils.VerifyDirReadPermission(dirPath))
            {
                Configuration.LogPaths = new List<string>();
                return;
            }

            string[] LeafDirectories = GetLeafDirectories(dirPath);




            if (!IntegrityVerification.VerifyLeafDirectoriesIntegrity(LeafDirectories))
            {
                Configuration.LogPaths = new List<string>();
                return;
            }

            Configuration.LogPaths = GetLogPathsFromRootDirectory(Configuration.rootDirectory);
            Configuration.AllPaths = GetAllFilesFromRootDirectory(Configuration.rootDirectory);
        }

    }
}

