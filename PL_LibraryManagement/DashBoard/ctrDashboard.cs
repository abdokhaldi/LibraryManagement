using BLL_LibraryManagement;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;

namespace PL_LibraryManagement.DashBoard
{
    public partial class ctrStatistics : UserControl
    {

        public ctrStatistics()
        {
            InitializeComponent();
            lblTitle.ForeColor = AppColors.Primary;
            lblTitle.Font = AppFonts.Title;
            lblTitle.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            tblPanel.Resize += (s, e) => CenterizeLabels();

        }
        private void CenterizeLabels()
        {
            foreach (Control ctr in tblPanel.Controls)
            {
                foreach (Label lbl in ctr.Controls)
                {
                    lbl.Anchor = AnchorStyles.None;
                    lbl.Font = AppFonts.Title;
                    if (lbl.Name.Contains("Title"))
                    {
                        lbl.Location = new Point(
                          (ctr.Width-lbl.Width) /2,(ctr.Height-lbl.Height) / 10);
                    }
                    else
                    {
                         lbl.Location = new Point(
                         (ctr.Width - lbl.Width) / 2, (ctr.Height + lbl.Height) / 3);
                    }
                 }
            }
        }
       
        private void CountBooks()
        {
            lblBooks.Text = BookService.GetAllBooks().Count().ToString(); 
        }
        private void CountMembers()
        {
            lblMembers.Text = MemberService.GetAllMembers().Count().ToString();
        }
        private void CountBorrowings()
        {
            lblBorrowings.Text = BorrowingService.GetAllBorrowings().Count().ToString();
        }
        private void CountLateBooks()
        {
            var list = BorrowingService.GetAllBorrowings().Where(p => p.ReturnDate ==null && p.DueDate < DateTime.Now).ToList();
            lblLate.Text = list.Count().ToString();
        }

        
        private void ctrDashboard_Load(object sender, EventArgs e)
        {
            CountBooks();
            CountBorrowings();
            CountMembers();
            CountLateBooks();
        }
    }
}
