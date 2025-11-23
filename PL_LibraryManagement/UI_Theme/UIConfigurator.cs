using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_LibraryManagement.UI_Theme
{
    public class UIConfigurator
    {
        public static void SetupTextBoxesUI(Control container)
        {
            foreach (Control ctr in container.Controls)
            {
                if (ctr is TextBox || ctr is ComboBox)
                {
                    ctr.Padding = new Padding(8, 5, 5, 5);
                    ctr.Font = AppFonts.Normal;
                    ctr.ForeColor = AppColors.TextDark;
                }
            }
        }
        public static void ConfigureDataGridView(DataGridView dataGridView)
        {       
            // dgvRecentActivities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.ColumnHeadersHeight = 35;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.RowTemplate.Height = 30;
            dataGridView.DefaultCellStyle.Font = AppFonts.DgvText;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = AppFonts.Button;
        }

        private static int ExtractFillWeight(string columnName)
        {
            string fillWeight = columnName.Trim().Substring(columnName.Length-2);
            if (fillWeight.Length < 2)
                return 0;
            if (int.TryParse(fillWeight,out int percentage))
            {
                return percentage;
            }
            return 0;
        }
        public static void CreateColumns(DataGridView dataGridView, Dictionary<string, (string, int)> valueColumnProperties)
        {

            foreach (var val in valueColumnProperties)
            {
                string fullColumnName = val.Key;
                int fillWeight = ExtractFillWeight(fullColumnName);
                string cleanColumnName = fullColumnName.Substring(0,fullColumnName.Length-2);
                
                if (fillWeight >0)
                { 
                  dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = cleanColumnName,
                        HeaderText = val.Value.Item1,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                        FillWeight = fillWeight,
                    });
                }
                else {
                    dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = val.Key,
                        HeaderText = val.Value.Item1,
                        Width = val.Value.Item2>0? val.Value.Item2:70,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    });
                }
            }
        }

        private static List<Label> GetCardLabels(Control container, string startsWith)
        {
            List<Label> cardLabels = new();
            foreach (var ctr in container.Controls)
            {
                if (ctr is Label)
                {

                    cardLabels.Add((Label)ctr);
                }
            }
            return cardLabels.Where(l => l.Name.StartsWith(startsWith)).ToList();
        }

        public static void SetupCardLabels(Panel panel,string startsWith)
        {
            var labelsList = GetCardLabels(panel, startsWith);

            foreach (Label lbl in labelsList)
            {
                lbl.ForeColor = AppColors.TextDark;
                lbl.Font = AppFonts.Normal;
            }
        }
        public static void SetupCardLabels(Control control, string startsWith)
        {
            var labelsList = GetCardLabels(control, startsWith);

            foreach (Label lbl in labelsList)
            {
                lbl.ForeColor = AppColors.TextDark;
                lbl.Font = AppFonts.Normal;
            }
        }

        public static void SetupCardLabels(Panel panel, string startsWith,Font font,Color fontColor)
        {
            var labelsList = GetCardLabels(panel, startsWith);

            foreach (Label lbl in labelsList)
            {
                lbl.ForeColor = fontColor;
                lbl.Font = font;
            }
        }

        public static void SetControlSize(Control mainContainer,UserControl ctr ,double widthPercent, double heightPercent)
        {
            ctr.Width = Convert.ToInt32(mainContainer.Width * widthPercent);
            ctr.Height = Convert.ToInt32(mainContainer.Height * heightPercent);
        }

        
    }



}

