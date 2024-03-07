using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Weddingnote
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Log_In_Form login = new Log_In_Form();
            if (login.ShowDialog() == DialogResult.Yes)
            {
                Application.Run(new Form1());
            }
        }
    }
}
