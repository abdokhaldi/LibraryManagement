namespace DVLD_Project_v2.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications
{
    partial class frmDLApplicationInfo
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
            this.ctrDLApplicationInfo1 = new DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications.ctrDLApplicationInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrDLApplicationInfo1
            // 
            this.ctrDLApplicationInfo1.Location = new System.Drawing.Point(24, 64);
            this.ctrDLApplicationInfo1.Name = "ctrDLApplicationInfo1";
            this.ctrDLApplicationInfo1.Size = new System.Drawing.Size(984, 448);
            this.ctrDLApplicationInfo1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(204, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(630, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Driving License Application Info";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(869, 509);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "close";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmDLApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 560);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrDLApplicationInfo1);
            this.Name = "frmDLApplicationInfo";
            this.Text = "frmDLApplicationInfo";
            this.Load += new System.EventHandler(this.frmDLApplicationInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications.ctrDLApplicationInfo ctrDLApplicationInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}