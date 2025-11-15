namespace DVLD_project.UserScreens.Forms
{
    partial class frmAddUpdateUser
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbUser = new System.Windows.Forms.TabControl();
            this.tbPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrAddPersonWithFilter1 = new DVLD_project.PeopleScreens.Components.ctrAddPersonWithFilter();
            this.tbLoginInfo = new System.Windows.Forms.TabPage();
            this.ctrLoginInfo1 = new DVLD_project.UserScreens.Components.ctrLoginInfo();
            this.tbUser.SuspendLayout();
            this.tbPersonalInfo.SuspendLayout();
            this.tbLoginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblTitle.Location = new System.Drawing.Point(434, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(239, 39);
            this.lblTitle.TabIndex = 22;
            this.lblTitle.Text = "Add new user";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(872, 575);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 48);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(755, 575);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 48);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbUser
            // 
            this.tbUser.Controls.Add(this.tbPersonalInfo);
            this.tbUser.Controls.Add(this.tbLoginInfo);
            this.tbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUser.Location = new System.Drawing.Point(7, 66);
            this.tbUser.Name = "tbUser";
            this.tbUser.SelectedIndex = 0;
            this.tbUser.Size = new System.Drawing.Size(981, 507);
            this.tbUser.TabIndex = 25;
            // 
            // tbPersonalInfo
            // 
            this.tbPersonalInfo.Controls.Add(this.btnNext);
            this.tbPersonalInfo.Controls.Add(this.ctrAddPersonWithFilter1);
            this.tbPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPersonalInfo.Location = new System.Drawing.Point(4, 34);
            this.tbPersonalInfo.Name = "tbPersonalInfo";
            this.tbPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPersonalInfo.Size = new System.Drawing.Size(973, 469);
            this.tbPersonalInfo.TabIndex = 0;
            this.tbPersonalInfo.Text = "Personal Info";
            this.tbPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(849, 418);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(118, 45);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrAddPersonWithFilter1
            // 
            this.ctrAddPersonWithFilter1.gbFilterEnabled = true;
            this.ctrAddPersonWithFilter1.Location = new System.Drawing.Point(6, 5);
            this.ctrAddPersonWithFilter1.Name = "ctrAddPersonWithFilter1";
            this.ctrAddPersonWithFilter1.Size = new System.Drawing.Size(964, 410);
            this.ctrAddPersonWithFilter1.TabIndex = 0;
            this.ctrAddPersonWithFilter1.OnSelectedPerson += new System.Action<int>(this.ctrAddPersonWithFilter1_OnSelectedPerson_1);
            // 
            // tbLoginInfo
            // 
            this.tbLoginInfo.Controls.Add(this.ctrLoginInfo1);
            this.tbLoginInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLoginInfo.Location = new System.Drawing.Point(4, 34);
            this.tbLoginInfo.Name = "tbLoginInfo";
            this.tbLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbLoginInfo.Size = new System.Drawing.Size(973, 469);
            this.tbLoginInfo.TabIndex = 1;
            this.tbLoginInfo.Text = "Login Info";
            this.tbLoginInfo.UseVisualStyleBackColor = true;
            // 
            // ctrLoginInfo1
            // 
            this.ctrLoginInfo1.chbIsActive = false;
            this.ctrLoginInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrLoginInfo1.lblUserID = "????";
            this.ctrLoginInfo1.Location = new System.Drawing.Point(7, 7);
            this.ctrLoginInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrLoginInfo1.Name = "ctrLoginInfo1";
            this.ctrLoginInfo1.Size = new System.Drawing.Size(411, 233);
            this.ctrLoginInfo1.TabIndex = 26;
            this.ctrLoginInfo1.txtConfirmPassword = "";
            this.ctrLoginInfo1.txtPassword = "";
            this.ctrLoginInfo1.txtUserName = "";
            // 
            // frmAddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 624);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmAddUpdateUser";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmAddUser_Load);
            this.tbUser.ResumeLayout(false);
            this.tbPersonalInfo.ResumeLayout(false);
            this.tbLoginInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tbUser;
        private System.Windows.Forms.TabPage tbPersonalInfo;
        private System.Windows.Forms.TabPage tbLoginInfo;
        private System.Windows.Forms.Button btnNext;
        private PeopleScreens.Components.ctrAddPersonWithFilter ctrAddPersonWithFilter1;
        private Components.ctrLoginInfo ctrLoginInfo1;
    }
}