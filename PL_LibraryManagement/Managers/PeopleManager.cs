using BLL_LibraryManagement;
using PL_LibraryManagement.Books;
using PL_LibraryManagement.People.UserControls;
using System;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace PL_LibraryManagement.UI_Theme
{
    public class PeopleManager
    {
      private readonly Timer resizeTimer = new Timer
            {
                Interval = 50,
                Enabled = false
            };
        private readonly Panel _MainPanel;
        private  ctrPeopleList _PeopleListControl;
        private  ctrAddEditPerson _AddEditPersonControl;
        private  ctrPersonCard _PersonCardControl;

        private PanelState _PanelState;

        public PeopleManager(Panel mainPanel)
        {
            
            _MainPanel = mainPanel;
            _PeopleListControl = new ctrPeopleList();
            _PersonCardControl = new ctrPersonCard();
            _PanelState = new PanelState();
            _MainPanel.Resize += mainPanel_Resize;
            resizeTimer.Tick += timer_tick;
        }



        ///  ------------------ People List -----------------------

        public void ShowPeopleListPage()
        {
            _MainPanel.Controls.Clear();
            _PanelState.HasPersonCard = false;
            _PanelState.HasAddEditForm = false;
            SetupPeoplePageUI();

            AddControlToPanel(_PeopleListControl);

            AttachPeopleListEvents();
        }

        private void SetupPeoplePageUI()
        {
            _PeopleListControl.Height = _MainPanel.Height - (_MainPanel.Height / 2);

            CardPosition.SetDockStyle(CardPosition.enDock.Fill, _PeopleListControl);
            _MainPanel.Padding = new Padding(10, 10, 10, 10);
        }

        private void AddControlToPanel(UserControl control)
        {
            _MainPanel.Controls.Add(control);
        }

        private void AttachPeopleListEvents()
        {
            _PeopleListControl.PersonSelected -= SelectedPerson;
            _PeopleListControl.PersonSelected += SelectedPerson;

            _PeopleListControl.CardInfoShowed -= AddPersonCard;
            _PeopleListControl.CardInfoShowed += AddPersonCard;

            _PeopleListControl.PersonSelectedToEdit -= AddPersonFormToAddEdit;
            _PeopleListControl.PersonSelectedToEdit += AddPersonFormToAddEdit;
        }

        private void timer_tick(object sender,EventArgs e)
        {
            resizeTimer.Start();
            if (_MainPanel.Contains(_PersonCardControl))
            {
                if (_MainPanel.Contains(_AddEditPersonControl))
                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomLeft, _MainPanel, _PersonCardControl);
                else
                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _PersonCardControl);
                UIConfigurator.SetControlSize(_MainPanel, _PersonCardControl, 0.54, 0.43);
            }

            if (_MainPanel.Contains(_AddEditPersonControl))
            {
                if (_MainPanel.Contains(_PersonCardControl))
                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomRight, _MainPanel, _AddEditPersonControl);
                else
                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _AddEditPersonControl);
                UIConfigurator.SetControlSize(_MainPanel, _AddEditPersonControl, 0.43, 0.43);
            }
        }

        private void mainPanel_Resize(object sender, EventArgs e)
        {
            resizeTimer.Stop();
            resizeTimer.Start();
        }
        private void SelectedPerson(PersonService person)
        {

            if (person != null)
            {
                _PersonCardControl.LoadPerson(person);
            }

        }

        /// ---------------------- PersonCard -------------------------------

        private void SetupPersonCardUI(ctrPersonCard personCard)
        {
            personCard.Dock = DockStyle.None;
            personCard.BackColor = AppColors.Primary;
            personCard.Anchor = AnchorStyles.None;
            CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, personCard);

        }

        private void AttachPersonCardEvents(ctrPersonCard card)
        {
            card.OnClose -= ClosePersonCard;
            card.OnClose += ClosePersonCard;

            card.OnAddPersonFormToAddEdit -= AddPersonFormToAddEdit;
            card.OnAddPersonFormToAddEdit += AddPersonFormToAddEdit;

            card.DataGridRefreshed -= _PeopleListControl.RefreshDataGrid;
            card.DataGridRefreshed += _PeopleListControl.RefreshDataGrid;
        }

        private void ClosePersonCard()
        {

           _MainPanel.Controls.Remove(_PersonCardControl);

            _PeopleListControl.ActiveCardInfoToolStripMenuItem();

          if (_PanelState.HasAddEditForm)
          {
              CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _AddEditPersonControl);
          }
            _PanelState.HasPersonCard = false;

            if (!_PanelState.HasAddEditForm)
            {
                CardPosition.SetDockStyle(CardPosition.enDock.Fill, _PeopleListControl);
            }
           
            _PersonCardControl.Dispose();
        }
        private void AddPersonCard()
        {
            
            CardPosition.SetDockStyle(CardPosition.enDock.Top, _PeopleListControl);


           UIConfigurator.SetControlSize(_MainPanel,_PersonCardControl,0.54,0.43);
           SetupPersonCardUI(_PersonCardControl);

            _MainPanel.Controls.Add(_PersonCardControl);

            AttachPersonCardEvents(_PersonCardControl);

            _PanelState.HasPersonCard = true;

            if (_PanelState.HasAddEditForm)
            {
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomRight, _MainPanel, _AddEditPersonControl);
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomLeft, _MainPanel, _PersonCardControl);
            }

        }


        /// ------------------ AddEditForm -------------------

        private void CloseAddEditForm()
        {
            _MainPanel.Controls.Remove(_AddEditPersonControl);
            CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _PersonCardControl);
            _PanelState.HasAddEditForm = false;

            if (!_PanelState.HasPersonCard)
            {
                _PeopleListControl.Dock = DockStyle.Fill;
            }
            _AddEditPersonControl.Dispose();
        }

        private void SetupAddEditPersonUI()
        {
            _AddEditPersonControl.Dock = DockStyle.None;
            _AddEditPersonControl.Margin = new Padding(10, 10, 10, 10);
            _AddEditPersonControl.BackColor = AppColors.Primary;
            _AddEditPersonControl.Anchor = AnchorStyles.None;
            CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomLeft, _MainPanel, _PersonCardControl);
            CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomRight, _MainPanel, _AddEditPersonControl);

        }

        private void AddPersonFormToAddEdit(PersonService person)
        {
            if (person == null)
            {
                AddFormToAddPerson();
            }
            else
            {
                AddFormToEditPerson(person);
            }
        }

        private void AttachAddEditEvents()
        {
            _AddEditPersonControl.OnClose -= CloseAddEditForm;
            _AddEditPersonControl.OnClose += CloseAddEditForm;

            _AddEditPersonControl.DataGridRefreshed -= _PeopleListControl.RefreshDataGrid;
            _AddEditPersonControl.DataGridRefreshed += _PeopleListControl.RefreshDataGrid;

            _AddEditPersonControl.CardInfoUpdated -= _PersonCardControl.LoadPerson;
            _AddEditPersonControl.CardInfoUpdated += _PersonCardControl.LoadPerson;
        }
        
        private void AddFormToAddPerson()
        {
           _MainPanel.Controls.Remove(_AddEditPersonControl);
           _AddEditPersonControl = new ctrAddEditPerson();
            UIConfigurator.SetControlSize(_MainPanel,_AddEditPersonControl, 0.43,0.43);

            SetupAddEditPersonUI();
                _MainPanel.Controls.Add(_AddEditPersonControl);
                AttachAddEditEvents();

                _PanelState.HasAddEditForm = true;
            }
        

        private void AddFormToEditPerson(PersonService person)
        {
           
            if (person == null) return;
            _MainPanel.Controls.Remove(_AddEditPersonControl);
            _AddEditPersonControl = new ctrAddEditPerson(person);
           UIConfigurator.SetControlSize(_MainPanel,_AddEditPersonControl, 0.43, 0.43);

            SetupAddEditPersonUI();

            if (!_PanelState.HasPersonCard)
            {
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _AddEditPersonControl);
            }

            _MainPanel.Controls.Add(_AddEditPersonControl);

            _PanelState.HasAddEditForm = true;

            if (_PanelState.HasPersonCard)
            {
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomLeft, _MainPanel, _PersonCardControl);
            }

            AttachAddEditEvents();
        }

    }
}
