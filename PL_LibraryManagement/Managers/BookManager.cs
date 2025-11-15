using BLL_LibraryManagement;
using PL_LibraryManagement.Books;
using PL_LibraryManagement.People.UserControls;
using PL_LibraryManagement.UI_Theme;
using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace PL_LibraryManagement.Managers
{
    
    public class BookManager
    {
        
        BookService _SelectedBook;
        Panel _MainPanel;
        ctrBookCard _BookCardControl;
        ctrBooksList _BookListControl;
        ctrAddEditBook _AddEditBookControl;

        private static readonly Timer _ResizeTimer = new System.Windows.Forms.Timer
        {
            Interval = 50,
            Enabled = false,
        };
        public BookManager(Panel mainPanel)
        {
            _MainPanel = mainPanel;
            _BookListControl = new ctrBooksList();
            _BookCardControl = new ctrBookCard(_SelectedBook);
           

            AttachResizeEvents();
        }

        private void AttachResizeEvents()
        {
            _MainPanel.Resize -= mainPanel_Resize;
            _ResizeTimer.Tick -= resize_Tick;
            _MainPanel.Resize += mainPanel_Resize;
            _ResizeTimer.Tick += resize_Tick;
        }
        private void resize_Tick(object sender, EventArgs e)
        {
            _ResizeTimer.Stop();

            if (_MainPanel.Contains(_BookCardControl))
            {
                if (_MainPanel.Contains(_AddEditBookControl))
                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomLeft, _MainPanel, _BookCardControl);
                else
                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _BookCardControl);
                UIConfigurator.SetControlSize(_MainPanel, _BookCardControl, 0.54, 0.43);
            }

            if (_MainPanel.Contains(_AddEditBookControl))
            {
                if (_MainPanel.Contains(_AddEditBookControl))
                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomRight, _MainPanel, _AddEditBookControl);
                else
                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _BookCardControl);
                UIConfigurator.SetControlSize(_MainPanel, _AddEditBookControl, 0.43, 0.43);
            }
        }

        private void mainPanel_Resize(object sender, EventArgs e)
        {
            _ResizeTimer.Stop();
            _ResizeTimer.Start();
        }

        public void AddBooksList()
        {      
            _MainPanel.Controls.Clear();
             
            _BookListControl.Height = _MainPanel.Height - (_MainPanel.Height / 2);
            
            CardPosition.SetDockStyle(CardPosition.enDock.Fill, _BookListControl);
            _MainPanel.Padding = new Padding(10, 10, 10, 10);
            _MainPanel.Controls.Add(_BookListControl);
            AttachBooksListEvents();
        }

        private void AttachBooksListEvents()
        {
            _BookListControl.BookSelected -= AddBookCard;
            _BookListControl.BookSelected += AddBookCard;

            _BookListControl.AddBookFormAdded -= AddFormToAddBook;
            _BookListControl.AddBookFormAdded += AddFormToAddBook;

            _BookListControl.EditBookFormAdded -= AddFormToEditBook;
            _BookListControl.EditBookFormAdded += AddFormToEditBook;
    
        }

        private void AddFormToEditBook(BookService book=null)
        {
            _MainPanel.Controls.Remove(_AddEditBookControl);
            if (book != null)
            {
                _AddEditBookControl = new ctrAddEditBook(book);
            }
            else
            {
                _AddEditBookControl = new ctrAddEditBook();
            }

            _BookListControl.Dock = DockStyle.Top;
            if (_MainPanel.Contains(_BookCardControl))
            {
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomLeft, _MainPanel, _BookCardControl);
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomRight, _MainPanel, _AddEditBookControl);
            }
            else
            {
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _AddEditBookControl);

            }

            _MainPanel.Controls.Add(_AddEditBookControl);
            AttachFormEvents();
        }
        private void AddFormToAddBook()
        {
            AddFormToEditBook(null);
         }

        


        private void AddBookCard(BookService selectedBook)
        {
            if (selectedBook == null) return;
                    
            _MainPanel.Controls.Remove(_BookCardControl);

            _SelectedBook = selectedBook;
            _BookCardControl = new ctrBookCard(_SelectedBook);
            _BookListControl.Dock = DockStyle.Top;
            if (_MainPanel.Contains(_AddEditBookControl))
            {
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomRight, _MainPanel, _AddEditBookControl);
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomLeft, _MainPanel, _BookCardControl);
            }
            else
            {
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _BookCardControl);
            }

            _MainPanel.Controls.Add(_BookCardControl);
            AttachBookCardEvents();
        }

        private void AttachBookCardEvents()
        {
            _BookCardControl.AddBookFormAdded -= AddFormToAddBook;
            _BookCardControl.AddBookFormAdded += AddFormToAddBook;

            _BookCardControl.EditBookFormAdded -= AddFormToEditBook;
            _BookCardControl.EditBookFormAdded += AddFormToEditBook;

            _BookCardControl.BookCardClosed -= CloseBookCard;
            _BookCardControl.BookCardClosed += CloseBookCard;

            _BookCardControl.BooksListRefereshed -= _BookListControl.RefereshBooksList;
          
            _BookCardControl.BooksListRefereshed += _BookListControl.RefereshBooksList;

            _BookCardControl.CardInfoStripeEnabled -= _BookListControl.ActiveCardInfoToolStripMenuItem;
            _BookCardControl.CardInfoStripeEnabled += _BookListControl.ActiveCardInfoToolStripMenuItem;
        }

        private void AttachFormEvents()
        {
            _AddEditBookControl.OnFormClosed -= CloseForm;
            _AddEditBookControl.OnFormClosed += CloseForm;
        }
        private void CloseForm()
        {
            
            _MainPanel.Controls.Remove(_AddEditBookControl);
            if(_MainPanel.Contains(_BookCardControl))
            CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter,_MainPanel,_BookCardControl);
            else
             _BookListControl.Dock = DockStyle.Fill;
            
        }
        private void CloseBookCard()
        {

            _MainPanel.Controls.Remove(_BookCardControl);
            if (_MainPanel.Contains(_AddEditBookControl))
            {
                CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _AddEditBookControl);
            }
            else
            {
                _BookListControl.Dock = DockStyle.Fill;
            }

            }
    }
}
