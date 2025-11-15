
using DVLD_DataAccess.TestTypes;
using System;
using System.Windows.Forms;

namespace DVLD_project.TestTypeScreens
{
    public partial class frmEditTestTypes : Form
    {
        private int _id; 
        private clsTestType _TestType;
        private frmManageTestTypes _manageTestType;
        public frmEditTestTypes(frmManageTestTypes manageTestType, int id)
        {
            InitializeComponent();
            _id = id;
            _manageTestType = manageTestType;
        }

        private void _loadInfoToUpdateForm()
        {
            _TestType = clsTestType.FindTestType(_id);
            if (_TestType != null)
            {
                lblTestTypeID.Text = _TestType.TestTypeID.ToString();
                txtTitle.Text = _TestType.TestTypeTitle;
                txtDescription.Text = _TestType.TestTypeDescription;
                txtFees.Text = _TestType.TestTypeFees.ToString();
            }
        }
        private void frmEditTestTypes_Load(object sender, EventArgs e)
        {
                _loadInfoToUpdateForm();
            }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_TestType != null)
            {
                if (!string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtFees.Text))
                {
                    _TestType.TestTypeTitle = txtTitle.Text;
                    _TestType.TestTypeDescription = txtDescription.Text;
                    _TestType.TestTypeFees = Convert.ToDouble(txtFees.Text);
                    if (this._TestType.UpdateTestType(_id))
                    {
                        MessageBox.Show("The Test Type Updated Successfuly");
                        _manageTestType._RefereshtTestTypesList();
                    }
                    else
                    {
                        MessageBox.Show("Updating the Test Type Was Faild");
                    }
                }
                else
                {
                    MessageBox.Show("can't save: One of more fields are empty");
                }
            }
        }
    }
}
    