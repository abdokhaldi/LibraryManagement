namespace PL_LibraryManagement.Borrowings
{
    partial class frmBorrowScrean
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrLookUpControl1 = new PL_LibraryManagement.Borrowings.ctrLookUpControl();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // ctrLookUpControl1
            // 
            this.ctrLookUpControl1.Location = new System.Drawing.Point(352, 29);
            this.ctrLookUpControl1.Name = "ctrLookUpControl1";
            this.ctrLookUpControl1.Size = new System.Drawing.Size(225, 80);
            this.ctrLookUpControl1.TabIndex = 2;
            this.ctrLookUpControl1.Load += new System.EventHandler(this.ctrLookUpControl1_Load);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(352, 115);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(225, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // frmBorrowScrean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 305);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.ctrLookUpControl1);
            this.Name = "frmBorrowScrean";
            this.Text = "frmBorrowScrean";
            this.ResumeLayout(false);

        }

        #endregion
        private ctrLookUpControl ctrLookUpControl1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}