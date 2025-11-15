using BLL_LibraryManagement;
using PL_LibraryManagement.Users.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_LibraryManagement
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

            using (frmLogin login = new frmLogin())
            {
                if (login.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            Application.Run(new frmHome());

           
        }
    }
}
