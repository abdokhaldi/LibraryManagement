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

            DialogResult result = DialogResult.None;

            do
            {
                using (frmLogin loginForm = new frmLogin())
                {
                    result = loginForm.ShowDialog();
                }

                if (result == DialogResult.OK)
                {
                    using (frmHome mainForm = new frmHome())
                    {
                      result = mainForm.ShowDialog();
                    }
                }

            } while (result == DialogResult.OK);
}
    }
}