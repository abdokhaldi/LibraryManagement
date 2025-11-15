namespace DVLD_project.DrivingLicenseServicesScreens
{
    partial class frmLicenseHistory
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
            this.lblLicenseHistory_LOGO = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbLocalLicenses = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this._dtLocalLicenses = new System.Windows.Forms.DataGridView();
            this.tbInternationalLicenses = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this._dtInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrAddPersonWithFilter1 = new DVLD_project.PeopleScreens.Components.ctrAddPersonWithFilter();
            this.tabControl1.SuspendLayout();
            this.tbLocalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dtLocalLicenses)).BeginInit();
            this.tbInternationalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dtInternationalLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLicenseHistory_LOGO
            // 
            this.lblLicenseHistory_LOGO.AutoSize = true;
            this.lblLicenseHistory_LOGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseHistory_LOGO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblLicenseHistory_LOGO.Location = new System.Drawing.Point(428, 9);
            this.lblLicenseHistory_LOGO.Name = "lblLicenseHistory_LOGO";
            this.lblLicenseHistory_LOGO.Size = new System.Drawing.Size(249, 37);
            this.lblLicenseHistory_LOGO.TabIndex = 32;
            this.lblLicenseHistory_LOGO.Text = "License History";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(958, 654);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 40);
            this.button1.TabIndex = 33;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.close_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbLocalLicenses);
            this.tabControl1.Controls.Add(this.tbInternationalLicenses);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 459);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1070, 189);
            this.tabControl1.TabIndex = 34;
            // 
            // tbLocalLicenses
            // 
            this.tbLocalLicenses.Controls.Add(this.label1);
            this.tbLocalLicenses.Controls.Add(this._dtLocalLicenses);
            this.tbLocalLicenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLocalLicenses.Location = new System.Drawing.Point(4, 29);
            this.tbLocalLicenses.Name = "tbLocalLicenses";
            this.tbLocalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tbLocalLicenses.Size = new System.Drawing.Size(1062, 156);
            this.tbLocalLicenses.TabIndex = 0;
            this.tbLocalLicenses.Text = "Local";
            this.tbLocalLicenses.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 25);
            this.label1.TabIndex = 33;
            this.label1.Text = "Local Licenses : ";
            // 
            // _dtLocalLicenses
            // 
            this._dtLocalLicenses.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this._dtLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dtLocalLicenses.Location = new System.Drawing.Point(6, 31);
            this._dtLocalLicenses.Name = "_dtLocalLicenses";
            this._dtLocalLicenses.Size = new System.Drawing.Size(1050, 119);
            this._dtLocalLicenses.TabIndex = 0;
            // 
            // tbInternationalLicenses
            // 
            this.tbInternationalLicenses.Controls.Add(this.label2);
            this.tbInternationalLicenses.Controls.Add(this._dtInternationalLicenses);
            this.tbInternationalLicenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInternationalLicenses.Location = new System.Drawing.Point(4, 29);
            this.tbInternationalLicenses.Name = "tbInternationalLicenses";
            this.tbInternationalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tbInternationalLicenses.Size = new System.Drawing.Size(1062, 156);
            this.tbInternationalLicenses.TabIndex = 1;
            this.tbInternationalLicenses.Text = "International";
            this.tbInternationalLicenses.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(6, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 25);
            this.label2.TabIndex = 35;
            this.label2.Text = "International Licenses:";
            // 
            // _dtInternationalLicenses
            // 
            this._dtInternationalLicenses.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this._dtInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dtInternationalLicenses.Location = new System.Drawing.Point(6, 32);
            this._dtInternationalLicenses.Name = "_dtInternationalLicenses";
            this._dtInternationalLicenses.Size = new System.Drawing.Size(1050, 116);
            this._dtInternationalLicenses.TabIndex = 34;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DVLD_Project_v2.Properties.Resources.user_clock;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(16, 211);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 133);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ctrAddPersonWithFilter1
            // 
            this.ctrAddPersonWithFilter1.gbFilterEnabled = true;
            this.ctrAddPersonWithFilter1.Location = new System.Drawing.Point(154, 45);
            this.ctrAddPersonWithFilter1.Name = "ctrAddPersonWithFilter1";
            this.ctrAddPersonWithFilter1.Size = new System.Drawing.Size(966, 408);
            this.ctrAddPersonWithFilter1.TabIndex = 35;
            this.ctrAddPersonWithFilter1.OnSelectedPerson += new System.Action<int>(this.ctrAddPersonWithFilter1_OnSelectedPerson);
            // 
            // frmLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 701);
            this.Controls.Add(this.ctrAddPersonWithFilter1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblLicenseHistory_LOGO);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmLicenseHistory";
            this.Text = "frmLicenseHistory";
            this.Load += new System.EventHandler(this.frmLicenseHistory_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbLocalLicenses.ResumeLayout(false);
            this.tbLocalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dtLocalLicenses)).EndInit();
            this.tbInternationalLicenses.ResumeLayout(false);
            this.tbInternationalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dtInternationalLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLicenseHistory_LOGO;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbLocalLicenses;
        private System.Windows.Forms.TabPage tbInternationalLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView _dtLocalLicenses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView _dtInternationalLicenses;
        private PeopleScreens.Components.ctrAddPersonWithFilter ctrAddPersonWithFilter1;
    }
}