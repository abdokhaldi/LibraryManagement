using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice_events_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void calculationControl1_OnResultSelected_1(int obj)
        {
            int result = obj;

            if (result != 0)
            {
                // MessageBox.Show("result is : " + result);
                lblResult.Text = result.ToString();
            }
        }

        private void calculationControl1_Load(object sender, EventArgs e)
        {

        }

        private void calculationControl1_OnCalculationCompleted(object sender, calculationControl.Bag e)
        {
            lblResult.Text = e.Result.ToString();

            MessageBox.Show("Val1= "+e.Val1 + " " + 
                "Val2= "+ e.Val2 + " " +
                "Result= " + e.Result);
        }
    }
}
