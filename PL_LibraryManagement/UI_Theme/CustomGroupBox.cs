using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_LibraryManagement.UI_Theme
{
    public class CustomGroupBox : GroupBox
    {
        public Font TitleFont { get; set; } = AppFonts.GbText;
        public Color BorderColor { get; set; } = AppColors.Background;
        public Color TitleColor { get; set; } = AppColors.Background;

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Size textSize = TextRenderer.MeasureText(Text , TitleFont);
            Rectangle textRect = new Rectangle(10,0,textSize.Width, textSize.Height);
            int topOffset = textSize.Height / 2;

            Rectangle borderRect = new Rectangle(0,topOffset,Width-1,Height-topOffset -1);

            using (Brush backBrush = new SolidBrush(BackColor))
            {
                g.FillRectangle(backBrush,textRect );
            }

            using (Pen pen = new Pen(BorderColor,1))
            
                g.DrawRectangle(pen,borderRect);

            TextRenderer.DrawText(g,Text,TitleFont,textRect,TitleColor,TextFormatFlags.Left);
        }
    
    }
}
