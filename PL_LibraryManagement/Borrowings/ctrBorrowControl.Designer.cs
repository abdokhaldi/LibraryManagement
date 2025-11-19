namespace PL_LibraryManagement.Borrowings
{
    partial class ctrBorrowControl
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
            this.gbBorrow = new PL_LibraryManagement.UI_Theme.CustomGroupBox();
            this.plBorrow = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbSelectBook = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrBookLookUP1 = new PL_LibraryManagement.Borrowings.ctrBookLookUP();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.plSelectBorrower = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrLookUpControl1 = new PL_LibraryManagement.Borrowings.ctrLookUpControl();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDueDate = new System.Windows.Forms.DateTimePicker();
            this.gbBorrow.SuspendLayout();
            this.plBorrow.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbSelectBook.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.plSelectBorrower.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBorrow
            // 
            this.gbBorrow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.gbBorrow.Controls.Add(this.plBorrow);
            this.gbBorrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBorrow.Location = new System.Drawing.Point(0, 0);
            this.gbBorrow.Name = "gbBorrow";
            this.gbBorrow.Size = new System.Drawing.Size(644, 186);
            this.gbBorrow.TabIndex = 0;
            this.gbBorrow.TabStop = false;
            this.gbBorrow.Text = "Borrowing Card :";
            this.gbBorrow.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.gbBorrow.TitleFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            // 
            // plBorrow
            // 
            this.plBorrow.Controls.Add(this.panel1);
            this.plBorrow.Controls.Add(this.panel2);
            this.plBorrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plBorrow.Location = new System.Drawing.Point(3, 16);
            this.plBorrow.Name = "plBorrow";
            this.plBorrow.Size = new System.Drawing.Size(638, 167);
            this.plBorrow.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbSelectBook);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(352, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 167);
            this.panel1.TabIndex = 6;
            // 
            // tbSelectBook
            // 
            this.tbSelectBook.Controls.Add(this.label1);
            this.tbSelectBook.Controls.Add(this.ctrBookLookUP1);
            this.tbSelectBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSelectBook.Location = new System.Drawing.Point(0, 0);
            this.tbSelectBook.Name = "tbSelectBook";
            this.tbSelectBook.Size = new System.Drawing.Size(286, 122);
            this.tbSelectBook.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Book";
            // 
            // ctrBookLookUP1
            // 
            this.ctrBookLookUP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrBookLookUP1.Location = new System.Drawing.Point(115, 3);
            this.ctrBookLookUP1.Name = "ctrBookLookUP1";
            this.ctrBookLookUP1.Size = new System.Drawing.Size(167, 87);
            this.ctrBookLookUP1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnBorrow);
            this.panel3.Location = new System.Drawing.Point(0, 122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(286, 45);
            this.panel3.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 45);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnBorrow
            // 
            this.btnBorrow.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBorrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrow.Location = new System.Drawing.Point(138, 0);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(148, 45);
            this.btnBorrow.TabIndex = 0;
            this.btnBorrow.Text = "Borrow";
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.plSelectBorrower);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 167);
            this.panel2.TabIndex = 7;
            // 
            // plSelectBorrower
            // 
            this.plSelectBorrower.Controls.Add(this.label2);
            this.plSelectBorrower.Controls.Add(this.ctrLookUpControl1);
            this.plSelectBorrower.Controls.Add(this.label3);
            this.plSelectBorrower.Controls.Add(this.dtDueDate);
            this.plSelectBorrower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plSelectBorrower.Location = new System.Drawing.Point(0, 0);
            this.plSelectBorrower.Name = "plSelectBorrower";
            this.plSelectBorrower.Size = new System.Drawing.Size(316, 167);
            this.plSelectBorrower.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Borrower";
            // 
            // ctrLookUpControl1
            // 
            this.ctrLookUpControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrLookUpControl1.Location = new System.Drawing.Point(146, 3);
            this.ctrLookUpControl1.Name = "ctrLookUpControl1";
            this.ctrLookUpControl1.Size = new System.Drawing.Size(167, 87);
            this.ctrLookUpControl1.TabIndex = 1;
            this.ctrLookUpControl1.Load += new System.EventHandler(this.ctrLookUpControl1_Load);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Due Date      ";
            // 
            // dtDueDate
            // 
            this.dtDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDueDate.Location = new System.Drawing.Point(125, 96);
            this.dtDueDate.Name = "dtDueDate";
            this.dtDueDate.Size = new System.Drawing.Size(167, 26);
            this.dtDueDate.TabIndex = 5;
            // 
            // ctrBorrowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbBorrow);
            this.Name = "ctrBorrowControl";
            this.Size = new System.Drawing.Size(644, 186);
            this.gbBorrow.ResumeLayout(false);
            this.plBorrow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tbSelectBook.ResumeLayout(false);
            this.tbSelectBook.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.plSelectBorrower.ResumeLayout(false);
            this.plSelectBorrower.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UI_Theme.CustomGroupBox gbBorrow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ctrLookUpControl ctrLookUpControl1;
        private ctrBookLookUP ctrBookLookUP1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtDueDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel plSelectBorrower;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.FlowLayoutPanel tbSelectBook;
        private System.Windows.Forms.Panel plBorrow;
    }
}
