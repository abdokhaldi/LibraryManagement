using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace DVLD_project
{
    public class MessageHelper
    {
        private static void _ShowMessage(string messageResult)
        {
            MessageBox.Show(messageResult);
        }
        public static void ShowMessageResult(bool success, string successMessage, string failureMessage)
        {
            _ShowMessage(success ? successMessage : failureMessage);
        }
       public static bool SowMessageConform(string message)
        {
            return (MessageBox.Show(message, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK);
        }
    }
}
