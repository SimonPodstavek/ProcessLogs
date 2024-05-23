using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessLogs
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        static Form1 MainForm;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new Form1();
           
            Application.Run(MainForm);

        }

        internal static void LogEvent(string message)
        {
            //Check if status box is not null
            var statusBox  = MainForm?.statusBox;

            if(statusBox != null)
            {
                statusBox.SafeInvoke(() => statusBox.AppendTextWithNewLine(message));
            }
        }



    }
}
