using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;


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
                MessageBox.Show("Chyba 101: Pre adrsár " + dirPath + " nemáte dostatočné povolenia", "Nedostatočné povolenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch(DirectoryNotFoundException)
            {
                MessageBox.Show("Chyba 100: Adresár " + dirPath + " neexistuje", "Neplatná cesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch(Exception e)
            {
                MessageBox.Show("Chyba: Pri overení prístupu k adresáru " + dirPath + " sa vyskytla neočakávaná chyba "+e, "Neočakávaná chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Chyba 101: Pre súbor " + filepath + " nemáte dostatočné povolenia", "Nedostatočné povolenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Chyba 102: Súbor" + filepath + "neexistuje", "Neplatná cesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Chyba: Pri overení prístupu k súboru " + filepath + " sa vyskytla neočakávaná chyba " + e, "Neočakávaná chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

    }

    internal static class IntegrityVerification
    {
        internal static bool VerifyLeafDirectoriesIntegrity(List<string> Leafdirectories)
        {
            //Checks that structure of leaf directories matches expected form
            string directoryStructureRegex = @".*\\20\d{2}\\\d{2}$";
            Regex regex = new Regex(directoryStructureRegex);

            bool allMatch = true;

            foreach(string leafDirectory in Leafdirectories)
            {
                MatchCollection matches = regex.Matches(leafDirectory);
                if(matches.Count == 0)
                {
                    allMatch = false;
                    MessageBox.Show("Chyba 103: Adresár" + leafDirectory+ " nespĺňa požadoovanú štruktúra", "Nesprávna štruktúra", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            return allMatch;
        }

    }




    internal static class Iterator
    {

        private static List<string> GetSubdirectories(string dirPath)
        {

            List<string> Leafdirectories = new List<string>();

            string[] subdirectories = Directory.GetDirectories(dirPath);


            if (subdirectories.Length == 0)
            {
                return new List<string> { dirPath };
            }

            foreach (string subdir in subdirectories)
            {
                if (AccessControlUtils.VerifyDirReadPermission(subdir))
                {
                    Leafdirectories.AddRange(GetSubdirectories(subdir));
                }
            }
            return Leafdirectories;
        }

        private static List<string> GetLogPathsFromLeafDirectories(List<string> Leafdirectories)
        {
            List<string> LogPaths = new List<string>();

            foreach (string leafDirectory in Leafdirectories)
            {
                //Iterate over all files in each leaf directory
                IEnumerable leafLogPaths = Directory.EnumerateFiles(leafDirectory, "*.txt;*.log", SearchOption.TopDirectoryOnly);
                foreach (string leafLogPath in leafLogPaths)
                {
                    if (AccessControlUtils.VerifyFileReadPermission(leafLogPath))
                    {
                        LogPaths.Add(leafLogPath);
                    }
                }
            }
            return LogPaths;

        }

        internal static List<string> GetLogPathsFromRoot(string dirPath)
        {
            List<string> Leafdirectories = GetSubdirectories(dirPath);

            if (IntegrityVerification.VerifyLeafDirectoriesIntegrity(Leafdirectories))
            {
                return new List<string>();
            }

            List<string> LogPaths = GetLogPathsFromLeafDirectories(Leafdirectories);
            return LogPaths;
        }

    }
}

