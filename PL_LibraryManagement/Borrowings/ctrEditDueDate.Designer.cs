namespace PL_LibraryManagement.Borrowings
{
    partial class ctrEditDueDate
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cgbDueDate = new PL_LibraryManagement.UI_Theme.CustomGroupBox();
            this.flwPanelDueDate = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.cgbDueDate.SuspendLayout();
            this.flwPanelDueDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(424, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cgbDueDate, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.80925F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.19075F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(548, 173);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // cgbDueDate
            // 
            this.cgbDueDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.cgbDueDate.Controls.Add(this.flwPanelDueDate);
            this.cgbDueDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgbDueDate.Location = new System.Drawing.Point(3, 39);
            this.cgbDueDate.Name = "cgbDueDate";
            this.cgbDueDate.Size = new System.Drawing.Size(542, 131);
            this.cgbDueDate.TabIndex = 6;
            this.cgbDueDate.TabStop = false;
            this.cgbDueDate.Text = "customGroupBox1";
            this.cgbDueDate.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.cgbDueDate.TitleFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            // 
            // flwPanelDueDate
            // 
            this.flwPanelDueDate.Controls.Add(this.lblDueDate);
            this.flwPanelDueDate.Controls.Add(this.dtDueDate);
            this.flwPanelDueDate.Controls.Add(this.btnSave);
            this.flwPanelDueDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwPanelDueDate.Location = new System.Drawing.Point(3, 16);
            this.flwPanelDueDate.Name = "flwPanelDueDate";
            this.flwPanelDueDate.Size = new System.Drawing.Size(536, 112);
            this.flwPanelDueDate.TabIndex = 2;
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.Location = new System.Drawing.Point(3, 0);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(119, 25);
            this.lblDueDate.TabIndex = 4;
            this.lblDueDate.Text = "Due Date :   ";
            // 
            // dtDueDate
            // 
            this.dtDueDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDueDate.Location = new System.Drawing.Point(128, 3);
            this.dtDueDate.Name = "dtDueDate";
            this.dtDueDate.Size = new System.Drawing.Size(200, 29);
            this.dtDueDate.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(334, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrEditDueDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "ctrEditDueDate";
            this.Size = new System.Drawing.Size(548, 173);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.cgbDueDate.ResumeLayout(false);
            this.flwPanelDueDate.ResumeLayout(false);
            this.flwPanelDueDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtDueDate;
        private System.Windows.Forms.FlowLayoutPanel flwPanelDueDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private UI_Theme.CustomGroupBox cgbDueDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
