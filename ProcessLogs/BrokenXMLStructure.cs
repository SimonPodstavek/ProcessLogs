using ProcessLogs.logs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessLogs.structures
{
    public partial class BrokenXMLStructure : Form
    {

        private LogClass logObject;
        private LogClass.record logRecord;
        public bool keepRecord;


        internal BrokenXMLStructure()
        {
            InitializeComponent();
            InitializeForm();
        }


        //internal BrokenXMLStructure(LogClass.record _logRecord, LogClass _logObject)
        //{
        //    InitializeComponent();
        //    logObject = _logObject;
        //    logRecord = _logRecord;
        //    InitializeForm();
        //}

        private void InitializeForm()
        {

        }


        private void BrokenXMLStructure_Load(object sender, EventArgs e)
        {

        }
    }
}
