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
    public partial class calculationControl : UserControl
    {

        public class Bag : EventArgs
        {
           public int Val1 { get; }
           public int Val2 { get; }
           public int Result { get; }

            public Bag(int v1,int v2,int result)
            {
                this.Val1 = v1;
                this.Val2 = v2;
                this.Result = result;
            }
        }

        public event EventHandler<Bag> OnCalculationCompleted;

        public calculationControl()
        {
            InitializeComponent();
        }

        protected virtual void raisedCalculationCompleted(Bag e)
        {
            
                OnCalculationCompleted.Invoke(this,e);
            
        }
        public void raisedCalculationCompleted(int val1,int val2,int result)
        {
            raisedCalculationCompleted(new Bag(val1,val2,result));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int val1, val2, result;
             val1 = Convert.ToInt32(txtNum1.Text); 
             val2 = Convert.ToInt32(txtNum2.Text);
             result = val1 + val2;

            if (OnCalculationCompleted != null)
            {
                raisedCalculationCompleted(val1,val2,result);
            }
        }
    }
}
