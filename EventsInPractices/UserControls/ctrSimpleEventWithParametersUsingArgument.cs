using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsInPractices.UserControls
{
    
    public partial class ctrMyUserControl : UserControl
    {
        public class CalculationEventArgs : EventArgs
        {
            public int val1 { get; }
            public int val2 { get; }
            public int result { get; }

            public CalculationEventArgs(int val1 , int val2, int result)
            {
                this.val1 = val1;
                this.val2 = val2;
                this.result = result;
            }
        }
        public event EventHandler<CalculationEventArgs> OnCalculationComplete;

        public virtual void RaisedCalculationComplete(int val1 , int val2, int result)
        {
            OnCalculationComplete?.Invoke(this,new CalculationEventArgs(val1,val2,result));
        }

        public ctrMyUserControl()
        {
            InitializeComponent();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            int val1 = Convert.ToInt32(txtNum1.Text);
            int val2 = Convert.ToInt32(txtNum2.Text);
            int result = val1 + val2;
            if (OnCalculationComplete != null)
            {
                RaisedCalculationComplete(val1, val2,result);
            }
        }
    }

}
