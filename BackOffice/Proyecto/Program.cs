using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static Blank Blank;
        public static ADODB.Recordset rs = new ADODB.Recordset();
        public static ADODB.Connection cm = new ADODB.Connection();
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Blank = new Blank());
        }
    }
}
