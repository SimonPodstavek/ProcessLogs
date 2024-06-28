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
using static ProcessLogs.utilities.Configuration;

namespace ProcessLogs.structures
{
    public partial class BrokenXMLStructure : Form
    {

        private LogClass logObject;
        private LogClass.record logRecord;
        private XmlException ex;
        private volatile bool hasValidXMLStructure = false;
        public bool keepRecord { get; set; }
        public byte[] savedByteSequence { get; set; }

        private string XMLStatusStringValid = "Platnosť štruktúry XML: Platná";
        private string XMLStatusStringInvalid = "Platnosť štruktúry XML: Neplatná";



        public byte[] XMLByteRepresentation
        {
            
            get { return Encoding.UTF8.GetBytes(XMLRecordContent.Text); }
        }



        internal BrokenXMLStructure(LogClass.record _logRecord, LogClass _logObject)
        {
            keepRecord = false;
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
            XMLStructureIntegrityLabel.Text = XMLStatusStringInvalid;
            hasValidXMLStructure = false;
            keepButton.Enabled = false;
        }


        private void checkXMLStructureButton_Click(object sender, EventArgs e)
        {
            byte[] XMLByteRepresentation = Encoding.UTF8.GetBytes(XMLRecordContent.Text);
            CheckXMLStructure(XMLByteRepresentation);
            
        }

        //Check whether the XML file is valid and change the form's behavior accordingly.
        private void CheckXMLStructure(byte[] checkedBytes)
        {
            try
            {
                //Check that XML has valid structure
                StructureVerification.VerifyByteXMLStructure verificator = new StructureVerification.VerifyByteXMLStructure();

                //Verify that <ModifiedOnParse>XML structure<ModifiedOnParse> can be inserted after the <LogElement> to store information about user's intervention
                LogClass.InsertElementAfterLookup(checkedBytes, Configuration.ByteSequences.XMLModifiedOnParse,Configuration.ByteSequences.logXMLOpeningSequence);

                verificator.ValidateXMLStructure(checkedBytes);
                XMLStructureIntegrityLabel.Text = XMLStatusStringValid;
                hasValidXMLStructure = true;
                keepButton.Enabled = true;
                errorLineTextBox.Text = String.Empty;
                errorPositionTextBox.Text = String.Empty;
                errorMessageLabel.Text = String.Empty;

            }
            catch (XmlException ex)
            {
                XMLStructureIntegrityLabel.Text = XMLStatusStringInvalid;
                hasValidXMLStructure = false;
                keepButton.Enabled = false;
                errorLineTextBox.Text = ex.LineNumber.ToString();
                errorPositionTextBox.Text = ex.LinePosition.ToString();
                errorMessageLabel.Text = ex.Message;
            }
            catch (XMLElementNotFound ex)
            {
                XMLStructureIntegrityLabel.Text = XMLStatusStringInvalid;
                hasValidXMLStructure = false;
                keepButton.Enabled = false;
                errorLineTextBox.Text = String.Empty;
                errorPositionTextBox.Text = String.Empty;
                errorMessageLabel.Text = ex.Message;

            }

        }


        private void keepButton_Click(object sender, EventArgs e)
        {
            if (hasValidXMLStructure)
            {
                byte[] XMLByteRepresentation = Encoding.UTF8.GetBytes(XMLRecordContent.Text);
                savedByteSequence = LogClass.InsertElementAfterLookup(XMLByteRepresentation, Configuration.ByteSequences.XMLModifiedOnParse, Configuration.ByteSequences.logXMLOpeningSequence);
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
