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
                throw new Exception("Chyba 101: Pre adresár " + dirPath + " nemáte dostatočné povolenia.");
            }
            catch(DirectoryNotFoundException)
            {
                throw new Exception("Chyba 100: Adresár " + dirPath + " neexistuje.");
            }
            catch(Exception err)
            {
                throw new Exception("Chyba: Pri overení prístupu k adresáru " + dirPath + " sa vyskytla neočakávaná chyba " + err + " .");
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
                throw new Exception("Chyba 101: Pre súbor nemáte dostatočné povolenia, súbor bude preskočený.");
            }
            catch (FileNotFoundException)
            {
                throw new Exception("Chyba 102: Súbor neexistuje.");
            }
            catch (Exception err)
            {
                throw new Exception("Chyba: Pri overení prístupu k súboru sa vyskytla neočakávaná chyba: " + err);
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
                else
                {
                    //Raise exception !!!!
                    Console.WriteLine("NOT FINISHED YET!");
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

            //Read permission not granted for root directory
            if (!AccessControlUtils.VerifyDirReadPermission(dirPath))
            {
                Configuration.LogPaths = Enumerable.Empty<string>();
                return;
            }

            string[] LeafDirectories = GetLeafDirectories(dirPath);




            if (!IntegrityVerification.VerifyLeafDirectoriesIntegrity(LeafDirectories))
            {
                Configuration.LogPaths = Enumerable.Empty<string>();
                return;
            }

            Configuration.LogPaths = GetLogPathsFromRootDirectory(Configuration.rootDirectory);
            Configuration.AllPaths = GetAllFilesFromRootDirectory(Configuration.rootDirectory);
        }

    }
}

