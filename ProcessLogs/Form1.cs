using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ookii.Dialogs.WinForms;
using ProcessLogs.utilities;
using System.Security.Cryptography;





namespace ProcessLogs
{

    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Get path to directory with logs
        private void sourceDirectoryButton_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                Process.rootDirectory = dialog.SelectedPath;
                Process.rootDirectory = Process.rootDirectory.Trim();
                sourceDirectoryTextBox.Text = Process.rootDirectory;
            }
        }
        //Get path to aggregate XML file
        private void XMLDirectoryButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.RestoreDirectory = true;
            dialog.Filter = "XML files (*.xml)|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Process.filePathXML = dialog.FileName;
                Process.filePathXML = Process.filePathXML.Trim();
                filePathXMLTextBox.Text = Process.filePathXML;
            }

        }



        private void initiateButton_Click(object sender, EventArgs e)
        {

            ProcessLogs();

        }


        static string ComputeSha1Hash(string input)
        {
            // Convert the input string to a byte array and compute the hash.
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha1.ComputeHash(inputBytes);

                string hexHash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                return hexHash.ToUpper();
            }
        }


        private void ProcessLogs()
        {
            //Update global path variables to match the user's choice
            Process.filePathXML = filePathXMLTextBox.Text;
            Process.rootDirectory = sourceDirectoryTextBox.Text;
 

            statusBox.AppendTextWithNewLine("Inicializácia spracovania");

            //Get Paths for .log files
            Iterator.GetLogPathsFromRoot(Process.rootDirectory);

            statusBox.AppendTextWithNewLine("Nájdených všetkých dokumentov: " + Process.AllPaths.Count);


            statusBox.AppendTextWithNewLine("Nájdených dokumentov typu .log: " + Process.LogPaths.Count);
            

            foreach (string path in Process.LogPaths)
            {
                string logContent = File.ReadAllText(path);
                statusBox.AppendTextWithNewLine(ComputeSha1Hash(logContent.Replace("\r", String.Empty)));
            }


            //Remove unused file paths from memory
            Process.AllPaths = new List<string>();

            if (Process.LogPaths.Count == 0)
            {
                statusBox.AppendTextWithNewLine("Chyba 104: V zadanom adresári neboli nájdené žiadne súbory. Ukončujem spracovanie.");
                return;
            }







        }

    }
}

