using ProcessLogs.logs;
using ProcessLogs.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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


        internal BrokenXMLStructure()
        {
            InitializeComponent();
            InitializeForm();
        }


        internal BrokenXMLStructure(LogClass.record _logRecord, LogClass _logObject, XmlException _ex)
        {
            InitializeComponent();
            logObject = _logObject;
            logRecord = _logRecord;
            ex = _ex; 
            InitializeForm();
        }

        private void InitializeForm()
        {
            string infoTitleStr = $"Štruktúra XML súboru {logObject.filePath} je poškodená";
            infoTitle.Text = infoTitleStr;
            errorLineTextBox.Text = ex.LineNumber.ToString();
            errorPositionTextBox.Text = ex.LinePosition.ToString();

            string XMLStringRepresentation = Encoding.UTF8.GetString(logRecord.byteXMLSequence);
            XMLRecordContent.Text = LogHandler.XMLStringPrettyPrint(XMLStringRepresentation);

        }

        private void checkXMLStructureButton_Click(object sender, EventArgs e)
        {
            byte[] XMLByteRepresentation = Encoding.UTF8.GetBytes(XMLRecordContent.Text);
            try
            {
                StructureVerification.VerifyXMLStructure(XMLByteRepresentation);
                XMLStructureIntegrityLabel.Text = "Platnosť štruktúry XML: Neplatná";
                hasValidXMLStructure = false;
                keepButton.Enabled = false;
            }
            catch(Exception ex)
            {
                XMLStructureIntegrityLabel.Text = "Platnosť štruktúry XML: Platná";
                hasValidXMLStructure = true;
                keepButton.Enabled = true;
            }
        }


        private void BrokenXMLStructure_Load(object sender, EventArgs e)
        {

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
