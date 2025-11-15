using PL_LibraryManagement.UI_Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace PL_LibraryManagement.Managers
{
    public class ManagerHelper
    {
        private static readonly Timer _ResizeTimer = new System.Windows.Forms.Timer
        {
            Interval = 50,
            Enabled = false,
        };
        private  static Panel _MainPanel ;
        private static UserControl _CardControl;
        private static UserControl _FormControl;

        
        public static void AttachEvents(Panel mainPanel,UserControl card,UserControl form)
        {
            _MainPanel = mainPanel;
            _CardControl = card;
            _FormControl = form;
            

            _MainPanel.Resize -= mainPanel_Resize;
            _ResizeTimer.Tick -= Resize_Tick;
            _MainPanel.Resize += mainPanel_Resize;
              _ResizeTimer.Tick += Resize_Tick;
           
        }


        private static void Resize_Tick(object sender, EventArgs e)
        {
             _ResizeTimer.Stop();
            if (_MainPanel.Contains(_CardControl))
            {
                if (_MainPanel.Contains(_FormControl))
                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomLeft, _MainPanel, _CardControl);
                else
                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _CardControl);
                UIConfigurator.SetControlSize(_MainPanel, _CardControl, 0.54, 0.43);
            }

            if (_MainPanel.Contains(_FormControl))
            {
                if (_MainPanel.Contains(_CardControl))
                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomRight, _MainPanel, _FormControl);
                else
                    CardPosition.SetCardPosition(CardPosition.enCardLocation.BottomCenter, _MainPanel, _CardControl);
                UIConfigurator.SetControlSize(_MainPanel, _FormControl, 0.43, 0.43);
            }
        }

        private static void mainPanel_Resize(object sender, EventArgs e)
        {
            _ResizeTimer.Stop();
            _ResizeTimer.Start();
        }
    }
    
}
