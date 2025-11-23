using BLL_LibraryManagement;
using PL_LibraryManagement.Books;
using PL_LibraryManagement.DashBoard;
using PL_LibraryManagement.Managers;
using PL_LibraryManagement.People.UserControls;
using PL_LibraryManagement.UI_Theme;
using PL_LibraryManagement.Users.UserControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PL_LibraryManagement
{
    public partial class frmHome : Form
    {
       private BookManager _BookManager;
        private PeopleManager _PeopleManager;
        private DashboardManager _DashboardManager;
        private UsersManager _UsersManager;
        private BorrowingManager _BorrowingManager;
        private MemberManager _MemberManager;
        public frmHome()
        {
            InitializeComponent();
           // if (!CurrentUser.IsAdmin())
           // {
           //     menuStrip1.Items.Remove(usersToolStripMenuItem);
           // }
            mainPanel.Padding = new Padding(25,10,25,15);
            _PeopleManager = new PeopleManager(this.mainPanel);
            _DashboardManager = new DashboardManager(this.mainPanel);
            _BookManager = new BookManager(this.mainPanel);
            _UsersManager = new UsersManager(mainPanel);
            _BorrowingManager = new BorrowingManager(mainPanel);
            _MemberManager = new MemberManager(mainPanel);
        } 
      
        private void SetMDIBackgroundColor()
        {
            foreach (Control ctr in this.Controls)
            {
                if (ctr is MdiClient client)
                {
                    client.BackColor = AppColors.Background;
                }
            }
        }
        private void SetupMenuStripUI()
        {
            this.menuStrip1.BackColor = AppColors.Primary;
            this.menuStrip1.Padding = new Padding(10, 10, 10, 10);

            foreach (ToolStripMenuItem item in this.menuStrip1.Items)
            {
                item.Font = AppFonts.MenuStripFont;
                item.ForeColor = AppColors.Background;
            }
        }
        private void SetupUI()
        {
            SetMDIBackgroundColor();
            this.mainPanel.BackColor = AppColors.Background;
            SetupMenuStripUI();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            SetupUI();
        }
        // _____________________________________________


        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DashboardManager.AddControlsToMainPanel();
        }


        private void manageBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _BookManager.AddBooksList();
        }

        private void registerNewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _PeopleManager.ShowPeopleListPage();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _UsersManager.ShowUsersList();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void borrowingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageBorrowingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _BorrowingManager.ShowBorrowingList();
        }

        private void manageMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _MemberManager.ShowMembersList();
        }

        // event to add book Card


    }
}
