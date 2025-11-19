using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_LibraryManagement.Borrowings
{
    public partial class frmBorrowScrean : Form
    {
        public frmBorrowScrean()
        {
            InitializeComponent();
           // ctrLookUpControl1.dtDueDateVisible += Visible;
           // ctrLookUpControl1.dtDueDateInvisible += Invisible;
        }

        private void Visible()
        {
            dateTimePicker1.Visible = true;
        }
        private void Invisible()
        {
            dateTimePicker1.Visible = false;
        }

        private void ctrLookUpControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
