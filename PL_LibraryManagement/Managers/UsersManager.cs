using BLL_LibraryManagement;
using PL_LibraryManagement.Books;
using PL_LibraryManagement.UI_Theme;
using PL_LibraryManagement.Users.UserControls;
using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace PL_LibraryManagement.Managers
{
    internal class UsersManager
    {
        UserService _SelectedUser;
        private Panel _MainPanel;
        ctrUsersList _ManageUsers;
        ctrAddUpdateUser _AddUpdateControl;
        ctrUserCard _UserCardControl;
        public UsersManager(Panel mainPanel)
        {
            _MainPanel = mainPanel;
            _ManageUsers = new ctrUsersList();
           
        }
     public void ShowUsersList()
        {
            _MainPanel.Controls.Clear();

            _ManageUsers.Dock = DockStyle.Fill;
            _MainPanel.Controls.Add(_ManageUsers);
            AttachUsersListEvents();
        }

        ///  ------------------ Add/Update -----------------------
        private bool HasCard(Control Container, Control card)
        {
            return Container.Controls.Contains(card);
        }
        private void RemoveFromContainer(Control control)
        {
            _MainPanel.Controls.Remove(control);
         }
        private void AddFormToEditUser(UserService user = null)
        {
            if(HasCard(_MainPanel, _AddUpdateControl)) 
                RemoveFromContainer(_AddUpdateControl);
            if (user != null)
            {
                _AddUpdateControl = new ctrAddUpdateUser(user);
            }
            else
            {
                _AddUpdateControl = new ctrAddUpdateUser();
            }

           
            if (HasCard(_MainPanel,_UserCardControl))
            {
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomLeft, _MainPanel, _UserCardControl);
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomRight, _MainPanel, _AddUpdateControl);
            }
            else
            {
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _AddUpdateControl);


            }
            _ManageUsers.Dock = DockStyle.Top;
            
            _MainPanel.Controls.Add(_AddUpdateControl);
            AttachFormEvents();
        }
        private void CloseAddUpdateControl()
        {
            _MainPanel.Controls.Remove(_AddUpdateControl);
            _AddUpdateControl.Dispose();
            if (HasCard(_MainPanel, _UserCardControl))
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter,_MainPanel,_UserCardControl);

        }
       private void AttachFormEvents()
        {
            _AddUpdateControl.AddUpdateFormClosed -= CloseAddUpdateControl;
            _AddUpdateControl.AddUpdateFormClosed += CloseAddUpdateControl;
        }
        private void CloseCardControl()
        {
            RemoveFromContainer(_UserCardControl);
            _UserCardControl.Dispose();
            if (HasCard(_MainPanel, _AddUpdateControl))
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter,_MainPanel,_AddUpdateControl);
        }
        private void AttachEventsCard()
        {
            _UserCardControl.CardClosed -= CloseCardControl;
            _UserCardControl.CardClosed += CloseCardControl;

            _UserCardControl.UpdateFormAdded -= AddFormToEditUser;
            _UserCardControl.UpdateFormAdded += AddFormToEditUser;

           _UserCardControl.AddFormAdded -= AddFormToAddUser;
           _UserCardControl.AddFormAdded += AddFormToAddUser;

            _UserCardControl.ControlRefereshed -= _ManageUsers.ReloadInfo;
            _UserCardControl.ControlRefereshed += _ManageUsers.ReloadInfo;
          
            _UserCardControl.ControlRefereshed -= _UserCardControl.ReloadCardInfo;
            _UserCardControl.ControlRefereshed += _UserCardControl.ReloadCardInfo;


        }

        

        private void AddUserCardControl(UserService selectedUser)
        {
            _SelectedUser = selectedUser;
            if (selectedUser != null)
            {

                if (HasCard(_MainPanel, _UserCardControl))
                {
                    
                    _MainPanel.Controls.Remove(_UserCardControl);
                    _UserCardControl.Dispose();
                }

                _UserCardControl = new ctrUserCard(selectedUser);
                _ManageUsers.Dock = DockStyle.Top;
                if (HasCard(_MainPanel, _AddUpdateControl)) {
                   
                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomLeft, _MainPanel, _UserCardControl);
                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomRight, _MainPanel, _AddUpdateControl);

                }
                else
            {

                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _UserCardControl);
            }
                _MainPanel.Controls.Add(_UserCardControl);
                AttachEventsCard();
            }
        }
        private void AddFormToAddUser()
        {
            AddFormToEditUser(null);
        }
        private void AttachUsersListEvents()
        {
            _ManageUsers.UserAddFormAdded -= AddFormToAddUser;
            _ManageUsers.UserAddFormAdded += AddFormToAddUser;

            _ManageUsers.UserUpdateFormAdded -= AddFormToEditUser;
            _ManageUsers.UserUpdateFormAdded += AddFormToEditUser;

            _ManageUsers.UserCardAdded -= AddUserCardControl;
            _ManageUsers.UserCardAdded += AddUserCardControl;

        }



    }
}
