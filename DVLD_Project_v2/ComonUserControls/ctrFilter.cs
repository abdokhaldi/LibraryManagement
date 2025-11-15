using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project.ComonUserControls
{
    public partial class ctrFilter : UserControl
    {
        public ComboBox cbFilter
        {
            set { cbFilterBy=value; }
            get { return cbFilterBy; }
        }
        public string txtSearch
        {
            set { txtSearchPrsn.Text = value; }
            get { return txtSearchPrsn.Text; }
        }
        public TextBox txtSearchControl

        {
            set { txtSearchPrsn = value; }
            get { return txtSearchPrsn; }
        }

        public ctrFilter()
        {
            InitializeComponent();
            cbFilterBy.SelectedIndex = 2;
        }

        
    }
}
