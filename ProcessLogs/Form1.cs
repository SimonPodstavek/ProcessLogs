using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Ookii.Dialogs.WinForms;
using ProcessLogs.utilities;
using ProcessLogs.logs;
using System.Reflection;
using System.Xml;
using ProcessLogs.structures;
using System.Web.UI.Design.WebControls;
using System.IO.Pipes;




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
                Configuration.AggregateFile.filePath = dialog.FileName;
                Configuration.AggregateFile.filePath = Configuration.AggregateFile.filePath.Trim();
                filePathXMLTextBox.Text = Configuration.AggregateFile.filePath;
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
            catch (Exception ex)
            {
                MessageBox.Show("Chyba: Pri spracovaní sa vyskytla chyba" + ex + " . Odstráňte závadu a skúste to opäť", "Neočakávaná chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.LogEvent(delimeter);
                Program.LogEvent("Spracovanie je ukončené.");
                Program.LogEvent(delimeter);
                Configuration.IsRunning = false;
                initiateButton.Text = "Spracovať";

            }
        }




        //This function is called when user clicks initiation button.
        //It takes setting and other information from the form, creates log object and calls Log handler.
        private void ProcessLogs()
        {

            Configuration.addedLength = 0;

            //Update global path variables to match the user's choice
            Configuration.AggregateFile.filePath = filePathXMLTextBox.Text;
            Configuration.rootDirectory = sourceDirectoryTextBox.Text;
            //Settings
                //Should the report be verbose
                Configuration.Settings.isVerbose = verboseLogCheckBox.Checked;
                //Aggregate file verification settings
                Configuration.Settings.verifyAggregateXMLStructureOnLoad = verifyAggregateXMLStructureOnLoadCheck.Checked;
                Configuration.Settings.verifyAggregateXMLStructureOnClose = verifyAggregateXMLStructureOnCloseCheck.Checked;
                //Record verification settings
                Configuration.Settings.verifyHash = VerifyLogHashCheck.Checked;
                Configuration.Settings.verifyLogXMLStructure = verifyLogXMLStructureCheck.Checked;
                //Check record sizes
                Configuration.Settings.minimumRecordSize = (int) minimumRecordSizeNumeric.Value;
                Configuration.Settings.maximumRecordSize= (int) maximumRecordSizeNumeric.Value;
                Configuration.Settings.verifyMinimumRecordSize = minimumRecordSizeCheckBox.Checked;
                Configuration.Settings.verifyMaximumRecordSize = maximumRecordSizeCheckBox.Checked;




            //Notify user about the missing parameters
            if (Configuration.rootDirectory == String.Empty)
            {
                MessageBox.Show("Chyba 105: Zadajte prosím zdrojový adresár obsahujúci predpísanú štruktúru a súbory .log", "Chýbajúca cesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Configuration.AggregateFile.filePath == String.Empty)
            {
                MessageBox.Show("Chyba 106: Zadajte prosím cestu k agregátnemu XML súboru.", "Chýbajúca cesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }





            //Verify the structure of aggregate XML file on read (optional)
            if (Configuration.Settings.verifyAggregateXMLStructureOnLoad)
            {
                //HasCorrectXMLStructure returns false if the structure is not valid
                if (!StructureVerification.XMLValidator.ValidateXMLStructure(Configuration.AggregateFile.filePath, "Agregátny Log súbor nemá správnu XML štruktúru.", checkAggregateFileStructure:true))
                {
                    return;
                }
            }




            Program.LogEvent("Inicializácia spracovania");

            //Get Paths for log files from root directory
            Iterator.GetPathsFromRoot(Configuration.rootDirectory);
            Program.LogEvent(delimeter);
            Program.LogEvent("Nájdených všetkých súborov: " + Configuration.CountAndRemoveAllPaths());
            Program.LogEvent("Nájdených dokumentov typu .log na spracovanie: " + Configuration.CountLogPaths());
            Program.LogEvent(delimeter);





            //Notify user if the root directory doesn't contain any logs
            if (Configuration.LogPaths.Count() == 0)
            {
                Program.LogEvent("Chyba 104: V zadanom zdrojovom adresári neboli nájdené žiadne platné súbory. Ukončujem spracovanie.");
                return;
            }


            //Create duplicate of an aggregate XML file that will be later appended to.
            try
            {
                SaveLogs.DupplicateAggregateFile();
            }
            catch (Exception ex)
            {
                Program.LogEvent($"Pri vytváraní kópie agregátneho súboru sa vyskytla chyba: {ex}");
                return;
            }

            //Remove the ending XML tag form duplicate
            SaveLogs.truncateAggregateXML();

            //Get file name for each log 
            Configuration.globalLogs = Configuration.LogPaths.Select(path => new LogClass(filePath: path, fileName: Path.GetFileName(path))).ToList();

            //Store information about total nmber of processed records
            int processedRecords = 0;

            //Initiate file stream to write to the aggregate file
            using (FileStream fileStream = new FileStream(Configuration.AggregateFile.duplicatefilePathXML, FileMode.Append, FileAccess.Write))
            {

                //Generate log object for every log path and add it to globalLogs IEnumerable.
                for (int index = 0; index < Configuration.globalLogs.Count(); index++)
                {

                    //Inform the user about every 5th processed log, if the verbose setting is on
                    if (Configuration.Settings.isVerbose && (index + 1) % 5 == 0)
                    {
                        Program.LogEvent($"Spracované záznamy: {index - 3} - {index + 1}");
                    }



                    //If the log processing failed, output the reason into status box.
                    LogClass logObject = Configuration.globalLogs[index];

                    try
                    {
                        if (!Configuration.IsRunning)
                        {
                            return;
                        }
                        LogHandler.ProcessLog(logObject, fileStream);
                        processedRecords += logObject.CountRecords();

                    }
                    catch (Exception ex)
                    {
                        Program.LogEvent("Vyskytla sa chyba pri spracovaní záznamu: " + logObject.filePath);
                        Program.LogEvent("NIE JE MOŽNÉ POKRAČOVAŤ - ZÁZNAMY NEBUDÚ ULOŽENÉ");
                        Program.LogEvent($"Popis: {ex}");
                        fileStream.Close();
                        SaveLogs.RemoveDuplicateAggregateFile();
                        return;
                    }
                    finally
                    {
                        Configuration.globalLogs[index] = null;
                    }

                }
                fileStream.Close();
            }



            //Inform the user about the total number of processed logs and records.

            Program.LogEvent($"Spracovaných bolo  {Configuration.globalLogs.Count()} súborov ({processedRecords} záznamov)", onlyVerbose: false);
            Program.LogEvent(delimeter, onlyVerbose: false);




            try
            {
                SaveLogs.AppendClosingSequence();
                SaveLogs.SaveTempFile();
            }catch(Exception ex)
            {
                Program.LogEvent($"Pri ukladaní záznamu s logmi sa vyskytla chyba : {ex}");
                return;
            }
            finally
            {
                Configuration.IsRunning = false;
            }


            return;

        }

        private void importSettings_Click(object sender, EventArgs e)
        {

        }
    }
}

