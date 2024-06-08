using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessLogs.logs;
using ProcessLogs.utilities;


namespace ProcessLogs
{
    public partial class HashIntegrityBroken : Form
    {
        private Logs logObject;
        private Logs.record logRecord;
        public bool keepRecord;

        internal HashIntegrityBroken(Logs.record _logRecord, Logs _logObject)
        {
            InitializeComponent();
            logObject = _logObject;
            logRecord = _logRecord;
            InitializeForm();
        }



        private void InitializeForm()
        {
            // Use the parameters to initialize form controls
            string infoTitleStr = $"Integrita záznamu súboru: {logObject.filePath} je porušená.";
            infoTitle.Text = infoTitleStr;
            computedHashTextBox.Text = LogHandler.HexByteToString(logRecord.computedHash);
            XMLHashTextBox.Text = LogHandler.HexByteToString(logRecord.XMLHash);

            string XMLStringRepresentation = Encoding.UTF8.GetString(logRecord.byteXMLSequence);
            XMLRecordContent.Text = LogHandler.XMLStringPrettyPrint(XMLStringRepresentation); ;
        }

        private void keepButton_Click(object sender, EventArgs e)
        {
            keepRecord = true;
            this.Close();
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            keepRecord = false;
            this.Close();
        }

        private void infoTitle_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
