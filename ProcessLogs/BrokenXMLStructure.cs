using ProcessLogs.logs;
using ProcessLogs.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProcessLogs.structures
{
    public partial class BrokenXMLStructure : Form
    {

        private LogClass logObject;
        private LogClass.record logRecord;
        private XmlException ex;
        private volatile bool hasValidXMLStructure = false;
        public bool keepRecord = false;



        internal BrokenXMLStructure(LogClass.record _logRecord, LogClass _logObject)
        {
            InitializeComponent();
            logObject = _logObject;
            logRecord = _logRecord; 
            InitializeForm();
        }

        private void InitializeForm()
        {
            string infoTitleStr = $"Štruktúra XML súboru {logObject.filePath} je poškodená";
            infoTitle.Text = infoTitleStr;
            CheckXMLStructure(logRecord.byteXMLSequence);

            string XMLStringRepresentation = Encoding.UTF8.GetString(logRecord.byteXMLSequence);
            XMLRecordContent.Text = XMLStringRepresentation;

        }

        private void checkXMLStructureButton_Click(object sender, EventArgs e)
        {
            byte[] XMLByteRepresentation = Encoding.UTF8.GetBytes(XMLRecordContent.Text);
            CheckXMLStructure(XMLByteRepresentation);
            
        }

        //Check whether the XML file is valid and change the form's behaviour accordingly.
        private void CheckXMLStructure(byte[] checkedBytes)
        {
            try
            {
                StructureVerification.VerifyXMLStructure(checkedBytes);
                XMLStructureIntegrityLabel.Text = "Platnosť štruktúry XML: Platná";
                hasValidXMLStructure = true;
                keepButton.Enabled = true;
                errorLineTextBox.Text = String.Empty;
                errorPositionTextBox.Text = String.Empty;
                errorMessageLabel.Text = String.Empty;

            }
            catch (Exception ex)
            {
                if(!(ex.InnerException is XmlException innerEx))
                {
                    throw;
                }
                XMLStructureIntegrityLabel.Text = "Platnosť štruktúry XML: Neplatná";
                hasValidXMLStructure = false;
                keepButton.Enabled = false;
                errorLineTextBox.Text = innerEx.LineNumber.ToString();
                errorPositionTextBox.Text = innerEx.LinePosition.ToString();
                errorMessageLabel.Text = innerEx.Message;


            }

        }


        private void keepButton_Click(object sender, EventArgs e)
        {
            if (hasValidXMLStructure)
            {
                keepRecord = true;
                this.Close();
            }
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            keepRecord = false;
            this.Close();
        }
    }
}
