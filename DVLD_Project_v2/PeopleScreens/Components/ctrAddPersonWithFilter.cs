using DVLD_project.People.Forms;
using DVLD_Project_v2.PeopleScreens.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_project.PeopleScreens.Components
{
    public partial class ctrAddPersonWithFilter : UserControl
    {
        public event Action<int> OnSelectedPerson;

        public int SelectedPersonID
        {
            get
            {
                if (this.DesignMode || ctrPersonDetails1 == null)
                    return -1; // قيمة افتراضية أثناء وقت التصميم
                return ctrPersonDetails1.SelectedPersonID;
            }
        }

        public bool gbFilterEnabled
        {
            get { return gbFilter.Enabled; }
            set { gbFilter.Enabled = value; }
        }

        public TextBox txtFilter
        {
            get { return txtFilterPrsn; }
            set { txtFilterPrsn = value; }
        }

        public ComboBox cbFilter
        {
            get { return cbFilterBy; }
            set { cbFilterBy = value; }
        }

        public ctrAddPersonWithFilter()
        {
            InitializeComponent();
        }

        public void _LoadPersonData(int personID)
        {
            if (this.DesignMode) return;

            cbFilterBy.SelectedIndex = 1;
            txtFilterPrsn.Text = personID.ToString();
            FindNow();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            FindNow(); 
        }

        private void FindNow()
        {
            if (this.DesignMode || ctrPersonDetails1 == null) return;
            if (string.IsNullOrWhiteSpace(txtFilterPrsn.Text))
            {
                return;
            }
            switch (cbFilterBy.Text)
            {
                case "PersonID":
                    ctrPersonDetails1.FillPersonInfo(int.Parse(txtFilterPrsn.Text));
                    break;
                case "NationalNo":
                    ctrPersonDetails1.FillPersonInfo(txtFilterPrsn.Text);
                    break;
                default:
                    break;
            }

            OnSelectedPerson?.Invoke(SelectedPersonID);
        }

        private void DataBack(int personID)
        {
            cbFilter.SelectedIndex = 1;
            txtFilterPrsn.Text = personID.ToString();
            btnSearch.PerformClick();
        }
        private void ctrAddPersonWithFilter_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            // أضف الأكواد التي يجب تنفيذها فقط أثناء وقت التشغيل هنا
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {

            frmAddUpdatePerson addPerson = new frmAddUpdatePerson();
            addPerson.OnPersonAdded += DataBack;
            addPerson.Show();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            if (cbFilterBy.SelectedIndex == 0)
            {
                plSearchFilter.Visible = false;
                return;
            }
            plSearchFilter.Visible = true;
        }

        private void txtFilterPrsn_KeyPress(object sender, KeyPressEventArgs e)
        {
            // to allow enter digits only
            if (cbFilterBy.SelectedIndex == 1)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                    e.Handled = true;
                }
            }
           // to allow enter letters and digits only
            if (cbFilterBy.SelectedIndex == 2)
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
