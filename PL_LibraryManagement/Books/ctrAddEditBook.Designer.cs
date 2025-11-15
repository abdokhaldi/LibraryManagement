namespace PL_LibraryManagement.Books
{
    partial class ctrAddEditBook
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
            this.gbForm = new PL_LibraryManagement.UI_Theme.CustomGroupBox();
            this.plForm = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lklblAddImage = new System.Windows.Forms.LinkLabel();
            this.lnkRemoveImage = new System.Windows.Forms.LinkLabel();
            this.plImage = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.cmbCaterory = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtYearPublished = new System.Windows.Forms.TextBox();
            this.gbForm.SuspendLayout();
            this.plForm.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbForm
            // 
            this.gbForm.AutoSize = true;
            this.gbForm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.gbForm.Controls.Add(this.plForm);
            this.gbForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbForm.Location = new System.Drawing.Point(0, 0);
            this.gbForm.Name = "gbForm";
            this.gbForm.Size = new System.Drawing.Size(628, 290);
            this.gbForm.TabIndex = 24;
            this.gbForm.TabStop = false;
            this.gbForm.Text = "Add :";
            this.gbForm.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.gbForm.TitleFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            // 
            // plForm
            // 
            this.plForm.Controls.Add(this.panel1);
            this.plForm.Controls.Add(this.panel3);
            this.plForm.Controls.Add(this.panel2);
            this.plForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plForm.Location = new System.Drawing.Point(3, 16);
            this.plForm.Name = "plForm";
            this.plForm.Size = new System.Drawing.Size(622, 271);
            this.plForm.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.plImage);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(484, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 271);
            this.panel1.TabIndex = 41;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.lklblAddImage);
            this.panel4.Controls.Add(this.lnkRemoveImage);
            this.panel4.Location = new System.Drawing.Point(3, 153);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(132, 43);
            this.panel4.TabIndex = 35;
            // 
            // lklblAddImage
            // 
            this.lklblAddImage.AutoSize = true;
            this.lklblAddImage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lklblAddImage.Location = new System.Drawing.Point(17, 5);
            this.lklblAddImage.Name = "lklblAddImage";
            this.lklblAddImage.Size = new System.Drawing.Size(103, 17);
            this.lklblAddImage.TabIndex = 31;
            this.lklblAddImage.TabStop = true;
            this.lklblAddImage.Text = "Add ImagePath";
            this.lklblAddImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblAddImage_LinkClicked_1);
            // 
            // lnkRemoveImage
            // 
            this.lnkRemoveImage.AutoSize = true;
            this.lnkRemoveImage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkRemoveImage.Location = new System.Drawing.Point(5, 22);
            this.lnkRemoveImage.Name = "lnkRemoveImage";
            this.lnkRemoveImage.Size = new System.Drawing.Size(127, 17);
            this.lnkRemoveImage.TabIndex = 32;
            this.lnkRemoveImage.TabStop = true;
            this.lnkRemoveImage.Text = "Remove ImagePath";
            // 
            // plImage
            // 
            this.plImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.plImage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.plImage.Location = new System.Drawing.Point(17, 30);
            this.plImage.Name = "plImage";
            this.plImage.Size = new System.Drawing.Size(110, 117);
            this.plImage.TabIndex = 34;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 232);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(133, 36);
            this.flowLayoutPanel1.TabIndex = 36;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 37);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(68, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 37);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.txtQuantity);
            this.panel3.Controls.Add(this.txtAuthor);
            this.panel3.Controls.Add(this.chkIsActive);
            this.panel3.Controls.Add(this.cmbCaterory);
            this.panel3.Location = new System.Drawing.Point(253, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(228, 263);
            this.panel3.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(12, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 38;
            this.label1.Text = "Quantity:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label18.Location = new System.Drawing.Point(22, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 21);
            this.label18.TabIndex = 1;
            this.label18.Text = "Author :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label23.Location = new System.Drawing.Point(5, 19);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 21);
            this.label23.TabIndex = 14;
            this.label23.Text = "Category :";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(109, 124);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(84, 20);
            this.txtQuantity.TabIndex = 37;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(99, 69);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(123, 20);
            this.txtAuthor.TabIndex = 28;
            this.txtAuthor.TextChanged += new System.EventHandler(this.txtAuthor_TextChanged);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(109, 179);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(64, 17);
            this.chkIsActive.TabIndex = 29;
            this.chkIsActive.Text = "IsActive";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // cmbCaterory
            // 
            this.cmbCaterory.FormattingEnabled = true;
            this.cmbCaterory.Location = new System.Drawing.Point(99, 18);
            this.cmbCaterory.Name = "cmbCaterory";
            this.cmbCaterory.Size = new System.Drawing.Size(109, 21);
            this.cmbCaterory.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtPublisher);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtTitle);
            this.panel2.Controls.Add(this.txtYearPublished);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 271);
            this.panel2.TabIndex = 39;
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(99, 64);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(123, 20);
            this.txtPublisher.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label17.Location = new System.Drawing.Point(7, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 21);
            this.label17.TabIndex = 2;
            this.label17.Text = "Publisher :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label16.Location = new System.Drawing.Point(7, 116);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(131, 21);
            this.label16.TabIndex = 3;
            this.label16.Text = "Year Published :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(7, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "Title :";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(65, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(139, 20);
            this.txtTitle.TabIndex = 24;
            // 
            // txtYearPublished
            // 
            this.txtYearPublished.Location = new System.Drawing.Point(140, 116);
            this.txtYearPublished.Name = "txtYearPublished";
            this.txtYearPublished.Size = new System.Drawing.Size(82, 20);
            this.txtYearPublished.TabIndex = 27;
            // 
            // ctrAddEditBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbForm);
            this.Name = "ctrAddEditBook";
            this.Size = new System.Drawing.Size(628, 290);
            this.gbForm.ResumeLayout(false);
            this.plForm.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UI_Theme.CustomGroupBox gbForm;
        private System.Windows.Forms.Panel plForm;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel lklblAddImage;
        private System.Windows.Forms.LinkLabel lnkRemoveImage;
        private System.Windows.Forms.Panel plImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.ComboBox cmbCaterory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtYearPublished;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}
