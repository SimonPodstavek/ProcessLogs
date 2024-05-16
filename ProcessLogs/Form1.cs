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


namespace ProcessLogs
{

    public partial class Form1 : Form
    {
        private string filePathXML = string.Empty;
        private string sourceDirectory = string.Empty;

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
                sourceDirectory = dialog.SelectedPath;
                sourceDirectory = sourceDirectory.Trim();
                sourceDirectoryTextBox.Text = sourceDirectory;
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
                filePathXML = dialog.FileName;
                filePathXML = filePathXML.Trim();
                filePathXMLTextBox.Text = filePathXML;
            }

        }

        private void initiateButton_Click(object sender, EventArgs e)
        {

            //Update global path variables to match the user's choice
            filePathXML = filePathXMLTextBox.Text;
            sourceDirectory = sourceDirectoryTextBox.Text;


            Console.WriteLine(Directory.GetDirectories(sourceDirectory));


            IEnumerable LogPaths = Iterator.GetLogPathsFromRoot(sourceDirectory);

            foreach(string path in LogPaths)
            {
                Console.WriteLine(path);
            }

        }
    }
}
