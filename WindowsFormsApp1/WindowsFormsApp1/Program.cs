using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        public static string cs = "Data Source=DESKTOP-VSA1TA1\\SQLEXPRESS;Initial Catalog=EX1_Summer_2018;Integrated Security=True";
       public static string cexcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\ECategories.xlsx ;Extended Properties=Excel 8.0";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login2Form());
        }
    }
}
