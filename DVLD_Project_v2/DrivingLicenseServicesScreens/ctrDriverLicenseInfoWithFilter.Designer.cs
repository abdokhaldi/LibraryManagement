namespace DVLD_project.DrivingLicenseServicesScreens
{
    partial class ctrDriverLicenseInfoWithFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrDriverLicenseInfoWithFilter));
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.ctrFilter2 = new DVLD_project.ComonUserControls.ctrFilter();
            this.ctrFilter1 = new DVLD_project.ComonUserControls.ctrFilter();
            this.ctrDriverLicenseInfo1 = new DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications.ctrDriverLicenseInfo();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnSearch);
            this.gbFilter.Controls.Add(this.label12);
            this.gbFilter.Controls.Add(this.txtSearch);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(13, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(523, 101);
            this.gbFilter.TabIndex = 97;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter :";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.Location = new System.Drawing.Point(447, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(51, 43);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnFind_Click);
            this.btnSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnSearch_MouseClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(29, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 29);
            this.label12.TabIndex = 1;
            this.label12.Text = "License ID :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(197, 42);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(235, 35);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // ctrFilter2
            // 
            this.ctrFilter2.Location = new System.Drawing.Point(320, 128);
            this.ctrFilter2.Name = "ctrFilter2";
            this.ctrFilter2.Size = new System.Drawing.Size(8, 8);
            this.ctrFilter2.TabIndex = 100;
            this.ctrFilter2.txtSearch = "";
            // 
            // ctrFilter1
            // 
            this.ctrFilter1.Location = new System.Drawing.Point(259, 144);
            this.ctrFilter1.Name = "ctrFilter1";
            this.ctrFilter1.Size = new System.Drawing.Size(8, 8);
            this.ctrFilter1.TabIndex = 99;
            this.ctrFilter1.txtSearch = "";
            // 
            // ctrDriverLicenseInfo1
            // 
            this.ctrDriverLicenseInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrDriverLicenseInfo1.Location = new System.Drawing.Point(3, 110);
            this.ctrDriverLicenseInfo1.Name = "ctrDriverLicenseInfo1";
            this.ctrDriverLicenseInfo1.Size = new System.Drawing.Size(1005, 369);
            this.ctrDriverLicenseInfo1.TabIndex = 98;
            // 
            // ctrDriverLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrFilter2);
            this.Controls.Add(this.ctrFilter1);
            this.Controls.Add(this.ctrDriverLicenseInfo1);
            this.Controls.Add(this.gbFilter);
            this.Name = "ctrDriverLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(1024, 482);
            this.Load += new System.EventHandler(this.ctrDriverLicenseInfoWithFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LocalDrivingLicenseApplications.ctrDriverLicenseInfo ctrDriverLicenseInfo1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSearch;
        private ComonUserControls.ctrFilter ctrFilter1;
        private ComonUserControls.ctrFilter ctrFilter2;
    }
}
