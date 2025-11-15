using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsInPractices
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        

       

        private void ctrMyUserControl1_OnCalculationComplete(object sender, UserControls.ctrMyUserControl.CalculationEventArgs e)
        {
            MessageBox.Show($"Val1 = {e.val1} val2 = {e.val2} result = {e.result}");

        }
    }
}
