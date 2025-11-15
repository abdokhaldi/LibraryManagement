using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_LibraryManagement.UI_Theme
{
    public class AppColors
    {
        public static readonly Color Primary =  Color.FromArgb(44,62,80);
        public static readonly Color Accent = Color.FromArgb(26,188,156);
        public static readonly Color Background = Color.FromArgb(244,246,247);
        public static readonly Color TextDark = Color.FromArgb(44, 62, 80);
        public static readonly Color ButtonText = Color.White;
        public static readonly Color Danger = Color.FromArgb(231,76,60);
        public static readonly Color Warning = Color.FromArgb(241,196,15);
        public static readonly Color Success = Color.FromArgb(39,174,96);
        public static readonly Color Border = Color.FromArgb(189,195,199);

        public static void SetupGroupBoxFormUI(CustomGroupBox groupBox,string title)
        {
            groupBox.Text = title;
            groupBox.TitleFont = AppFonts.GbText;
            groupBox.TitleColor = AppColors.Background;
            groupBox.BorderColor = AppColors.Primary;
            groupBox.BackColor = AppColors.Primary;
            groupBox.Padding = new Padding(10, 20, 10, 10);
            
         }
        public static void SetupDataGridViewUI(DataGridView dataGrid
            )
        {
            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Primary;
            dataGrid.BackgroundColor = Background;
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = ButtonText;
            dataGrid.DefaultCellStyle.SelectionBackColor = Accent;
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 234, 237);
            dataGrid.BorderStyle = BorderStyle.None;
        }



    }
}
