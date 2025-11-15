using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Windows.Forms;

namespace PL_LibraryManagement.People.UserControls
{
    public partial class ctrPersonCard : UserControl
    {
        public event Action OnClose;
        public event Action DataGridRefreshed;

        public event Action <PersonService> OnAddPersonFormToAddEdit;
        PersonService _PersonSelected;

        private bool isDeactivated = false;

        public Button _btnClose
        {
            get
            {
                return btnClose;
            }
            set
            {
                btnClose = value;
            }
        }
        public ctrPersonCard()
        {
            InitializeComponent();
            _UI_setup();
            
        }

        private void _UI_setup()
        {
            this.BackColor = AppColors.Primary;
            plCard.BackColor = AppColors.Background;
            plButons.BackColor = AppColors.Primary;

            btnClose.BackColor = AppColors.Danger;
            btnClose.ForeColor = AppColors.Background;
          
            btnActive.Text = isDeactivated?  "Deactive":"Active";
            btnActive.Font = AppFonts.Button;
            SetupCardLabels();
            AppColors.SetupGroupBoxFormUI(gbxCard,"Person Card:");
        }
        private void SetupCardLabels()
        {
            UIConfigurator.SetupCardLabels(plCard,"lbl");
            
        }
        public void LoadPerson(PersonService person)
        {
          if (person != null)
            {
                _PersonSelected = person;
                btnActive.Text = person.IsActive ? "Deactive" : "Active";
                lblPersonID.Text = person.PersonID.ToString();
                lblFirstName.Text = person.FirstName;
                lblLastName.Text = person.LastName;
                lblPhone.Text = person.Phone;
                lblEmail.Text = person.Email;
                lblAddress.Text = person.Address;
                lblCity.Text = person.City;
                lblGender.Text = person.Gender =='M'? "Male" : "Female";
                lblStatus.Text = (person.IsActive) ? "Active" : "Inactive";
                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnAddPersonFormToAddEdit?.Invoke(null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnClose?.Invoke();
        }

        private void btnEdit(object sender, EventArgs e)
        {
            OnAddPersonFormToAddEdit?.Invoke(_PersonSelected);
        }


        private void Activation_Click(object sender, EventArgs e)
        {
           
            if (_PersonSelected.IsActive)
            {
               OperationResultBLL result = PersonService.DesactivePerson(_PersonSelected);
                if (result.Success)
                {
                   // btnActive.Text = "Active";
                     isDeactivated = true;
                    MessageBox.Show(result.Message);
                    _PersonSelected.IsActive = false;
                }
            }
            else 
            {
               OperationResultBLL result = PersonService.ActivePerson(_PersonSelected);

                if (result.Success)
                {
                    
                    isDeactivated = false;
                MessageBox.Show(result.Message);
                _PersonSelected.IsActive = true;
                }
 }
            DataGridRefreshed?.Invoke();
            LoadPerson(_PersonSelected);
            SetupActiveButton();
        }

        private void SetupActiveButton()
        {
            if (_PersonSelected.IsActive)
            {
                btnActive.BackColor = AppColors.Danger;
                btnActive.Text = "Deactivate";
            }
            else
            {
                btnActive.BackColor = AppColors.Success;
                btnActive.Text = "Activate";
            }
        }
    }
}
