
using System.Drawing;
using System.Windows.Forms;

namespace PL_LibraryManagement.UI_Theme
{
   
    public class CardPosition
    {
        
        public enum enCardLocation { BottomLeft, BottomRight, BottomCenter }
        public enum enDock { Fill = 1, Top = 2 }

        static private Point AddCardLocation(enCardLocation location, Panel mainPanel, UserControl card)
        {
            int panelWidth =  mainPanel.Width;
            int panelHeight = mainPanel.Height;
            int cardWidth = card.Width;
            int cardHeight = card.Height;
            int margin = 10;

            return location switch
            {
                enCardLocation.BottomLeft =>
                    new Point(
                      panelWidth - panelWidth + margin,
                       panelHeight - cardHeight - margin),


                enCardLocation.BottomRight =>
                     new Point(
                        panelWidth - cardWidth - margin,
                       panelHeight - cardHeight - margin),

                enCardLocation.BottomCenter =>

                        new Point(
                          (panelWidth - cardWidth) / 2 - margin,
                           panelHeight - cardHeight - margin),
            };
        }
        static public void SetCardPosition(enCardLocation location, Panel mainPanel, UserControl card)
        {
            card.Location = AddCardLocation(location, mainPanel, card);
        }
       


        private static DockStyle MakeDockStyle(enDock dok)
        {
            return dok switch
            {
                enDock.Fill => DockStyle.Fill,
                enDock.Top => DockStyle.Top,
            };
        }
        public static void SetDockStyle(enDock dok, UserControl userControl)
        {
            userControl.Dock = MakeDockStyle(dok);
        }

    }
}
