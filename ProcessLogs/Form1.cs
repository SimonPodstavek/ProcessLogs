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
using System.Threading;
using System.Windows.Forms;
using Ookii.Dialogs.WinForms;
using ProcessLogs.utilities;
using System.Security.Cryptography;
using ProcessLogs.logs;





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
                Configuration.rootDirectory = dialog.SelectedPath;
                Configuration.rootDirectory = Configuration.rootDirectory.Trim();
                sourceDirectoryTextBox.Text = Configuration.rootDirectory;
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
                Configuration.filePathXML = dialog.FileName;
                Configuration.filePathXML = Configuration.filePathXML.Trim();
                filePathXMLTextBox.Text = Configuration.filePathXML;
            }

        }

        


        private async void initiateButton_Click(object sender, EventArgs e)
        {



            if (Configuration.IsRunning == true)
            {
                Configuration.iniProcess(initiateButton);
            }
            else
            {
                Configuration.stopProcess(initiateButton);
            }


            try
            {    
                if( Configuration.IsRunning == true )
                {
                    await Task.Run(() => ProcessLogs());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Chyba: Pri spracovaní sa vyskytla chyba" + err + " . Odstráňte závadu a skúste to opäť", "Neočakávaná chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Configuration.IsRunning = false;
                initiateButton.Text = "Spracovať";

            }




        }

        private void ProcessLogs()
        {

            //Update global path variables to match the user's choice
            Configuration.filePathXML = filePathXMLTextBox.Text;
            Configuration.rootDirectory = sourceDirectoryTextBox.Text;

            //Notify user about the missing parameters
            if (Configuration.rootDirectory == String.Empty)
            {
                MessageBox.Show("Chyba 105: Zadajte prosím zdrojový adresár obsahujúci predpísanú štruktúru a súbory .log", "Chýbajúca cesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Uncomment in prod!!!
            //if (Proces.filePathXML == String.Empty)
            //{
            //    MessageBox.Show("Chyba 106: Zadajte prosím cestu k agregátnemu XML súboru.", "Chýbajúca cesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}





            statusBox.SafeInvoke(() => statusBox.AppendTextWithNewLine("Inicializácia spracovania"));

            //Get Paths for .log files
            Iterator.GetLogPathsFromRoot(Configuration.rootDirectory);


            statusBox.SafeInvoke(() => statusBox.AppendTextWithNewLine("Nájdených všetkých dokumentov: " + Configuration.CountAndRemoveAllPaths()));
            statusBox.SafeInvoke(() => statusBox.AppendTextWithNewLine("Nájdených dokumentov typu .log: " + Configuration.CountLogPaths()));




            List<Logs> tmpLogs = new List<Logs>();


            foreach ((int logIndex, string path) in Configuration.LogPaths.Enumerate())
            {
                string fileName = Path.GetFileName(path);
                tmpLogs.Add(new Logs(filePath: path,fileName: fileName));
            }

            Configuration.globalLogs = tmpLogs;
            tmpLogs = new List<Logs>();

            foreach ((int index, Logs logObject) in Configuration.globalLogs.Enumerate())
            {
                if (!Configuration.IsRunning)
                {
                    return;
                }

                //string logContent = File.ReadAllText(path);
                logObject.byteLogContent = File.ReadAllBytes(logObject.filePath);
                statusBox.SafeInvoke(() => statusBox.AppendTextWithNewLine("XML sekcia pre dokument " + index + " " + logObject.XMLByteSequences.Count()));
                //statusBox.AppendTextWithNewLine(ComputeSha1Hash(logContent.Replace("\r", String.Empty)));

            }

            return;



            //Remove unused file paths from memory
            Configuration.AllPaths = new List<string>();

            if (Configuration.LogPaths.Count == 0)
            {
                statusBox.SafeInvoke(() => statusBox.AppendTextWithNewLine("Chyba 104: V zadanom adresári neboli nájdené žiadne súbory. Ukončujem spracovanie."));
                return;
            }
        
        }

    }
}

