using DVLD_DataAccess.ApplicationTypes;
using DVLD_project.ApplicationTypeScreens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project
{
    public partial class frmEditAppType : Form
    {
        private int _id;
        private clsApplicationType _applicationType;
        private frmManageApplicationTypes _manageApplicationType;
        public frmEditAppType(frmManageApplicationTypes manageApplicationType,int id)
        {
            InitializeComponent();
            _id = id;
            _manageApplicationType = manageApplicationType;
        }
        public frmEditAppType()
        {
            InitializeComponent();

        }
        private void _loadInfoToUpdateForm()
        {
             _applicationType = clsApplicationType.FindApplicationType(_id);
            if (_applicationType != null)
            {
                lblApplicationTypeID.Text = _applicationType.ApplicationTypeID.ToString();
                txtTitle.Text = _applicationType.ApplicationTypeTitle;
                txtFees.Text = _applicationType.ApplicationTypeFeese.ToString(); ; 
            }
        }

        private void frmEditAppType_Load(object sender, EventArgs e)
        {
            _loadInfoToUpdateForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_applicationType != null )
            {
                if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtFees.Text)) { 
                _applicationType.ApplicationTypeTitle = txtTitle.Text;
                _applicationType.ApplicationTypeFeese = Convert.ToDouble(txtFees.Text);
                    if (this._applicationType.UpdateApplicationType(_id))
                    {
                        MessageBox.Show("The Application Type Updated Successfuly");
                        _manageApplicationType._RefereshApplicationTypesList();
                    }
                    else
                    {
                        MessageBox.Show("Updating the application Type Was Faild");
                    }
                
               }else
                {
                    MessageBox.Show("can't save: One of more fields are empty");
                }
            }
        }
    }
}
