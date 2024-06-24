using ProcessLogs.logs;
using ProcessLogs.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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


        public byte[] XMLByteRepresentation
        {
            
            get { return Encoding.UTF8.GetBytes(XMLRecordContent.Text); }
        }



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
            //Show the user change in cursour position
            XMLRecordContent.SelectionChanged += UpdateCursorPosition;
            //Disable acceptance eligibility on change in text
            XMLRecordContent.TextChanged += DisableAcceptanceEligibility;

        }

        //Update text boxes for user to know their current position
        private void UpdateCursorPosition(object sender, EventArgs e)
        {
            int cursorPositionTextBox = XMLRecordContent.SelectionStart;
            this.cursorPositionTextBox.Text = cursorPositionTextBox.ToString();

        }

        //Disable accepting on change in the text
        private void DisableAcceptanceEligibility(object sender, EventArgs e)
        {
            XMLStructureIntegrityLabel.Text = "Platnosť štruktúry XML: Neplatná";
            hasValidXMLStructure = false;
            keepButton.Enabled = false;
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
