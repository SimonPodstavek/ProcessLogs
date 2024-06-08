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
using System.Reflection.Emit;
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using System.Diagnostics;





namespace ProcessLogs
{

    public partial class Form1 : Form
    {
        internal string delimeter = new string('-', 80);

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
                Program.LogEvent(delimeter);
                Program.LogEvent("Spracovanie je ukončené.");
                Configuration.IsRunning = false;
                initiateButton.Text = "Spracovať";

            }
        }


        //This function is called when user clicks initiation button.
        //It takes setting and other information from the form, creates log object and calls Log handler.
        private void ProcessLogs()
        {
            

            //Update global path variables to match the user's choice
            Configuration.filePathXML = filePathXMLTextBox.Text;
            Configuration.rootDirectory = sourceDirectoryTextBox.Text;
            Configuration.Settings.isVerbose = verboseLogCheckBox.Checked;

            SaveLogs.DupplicateAggregateFile();

            //Notify user about the missing parameters
            if (Configuration.rootDirectory == String.Empty)
            {
                MessageBox.Show("Chyba 105: Zadajte prosím zdrojový adresár obsahujúci predpísanú štruktúru a súbory .log", "Chýbajúca cesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Configuration.filePathXML == String.Empty)
            {
                MessageBox.Show("Chyba 106: Zadajte prosím cestu k agregátnemu XML súboru.", "Chýbajúca cesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
    


            Program.LogEvent("Inicializácia spracovania");


            //Get Paths for log files from root directory
            Iterator.GetPathsFromRoot(Configuration.rootDirectory);

            Program.LogEvent(delimeter);

            Program.LogEvent("Nájdených všetkých dokumentov: " + Configuration.CountAndRemoveAllPaths());
            Program.LogEvent("Nájdených dokumentov typu .log: " + Configuration.CountLogPaths());

            Program.LogEvent(delimeter);





            //Notify user if the root directory doesn't contain any logs
            if (Configuration.LogPaths.Count() == 0)
            {
                Program.LogEvent("Chyba 104: V zadanom zdrojovom adresári neboli nájdené žiadne súbory. Ukončujem spracovanie.");
                return;
            }

            //Generate log object for every log path and add it to globalLogs IEnumerable.
            Configuration.globalLogs = Configuration.LogPaths.Select(path => new Logs(filePath: path, fileName: Path.GetFileName(path)));
            foreach ((int index, Logs logObject) in Configuration.globalLogs.Enumerate())
            {
                if (!Configuration.IsRunning)
                {
                    return;
                }


                //If the log processing failed, output the reason into rich text box.
                try
                {
                    LogHandler.ProcessLog(logObject);
                }catch(Exception ex)
                {
                    Program.LogEvent("Vyskytla sa chyba pri spracovaní záynamu: " + logObject.filePath);
                    Program.LogEvent($"Popis: {ex}");
                    return;
                }

            }


            //SaveLogs.DupplicateAggregateFile();

            return;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

