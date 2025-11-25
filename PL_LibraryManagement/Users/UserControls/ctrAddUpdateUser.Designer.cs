namespace PL_LibraryManagement.Users.UserControls
{
    partial class ctrAddUpdateUser
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
            this.tbForm = new System.Windows.Forms.TableLayoutPanel();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSelectPerson = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRoles = new System.Windows.Forms.ComboBox();
            this.gbForm.SuspendLayout();
            this.tbForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbForm
            // 
            this.gbForm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.gbForm.Controls.Add(this.tbForm);
            this.gbForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbForm.Location = new System.Drawing.Point(0, 0);
            this.gbForm.Name = "gbForm";
            this.gbForm.Size = new System.Drawing.Size(562, 285);
            this.gbForm.TabIndex = 0;
            this.gbForm.TabStop = false;
            this.gbForm.Text = "Add:";
            this.gbForm.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.gbForm.TitleFont = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            // 
            // tbForm
            // 
            this.tbForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbForm.ColumnCount = 7;
            this.tbForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tbForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tbForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tbForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tbForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tbForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tbForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tbForm.Controls.Add(this.lblUserID, 1, 0);
            this.tbForm.Controls.Add(this.label1, 0, 0);
            this.tbForm.Controls.Add(this.btnClose, 4, 4);
            this.tbForm.Controls.Add(this.label11, 3, 0);
            this.tbForm.Controls.Add(this.lblPersonID, 4, 0);
            this.tbForm.Controls.Add(this.txtUsername, 1, 1);
            this.tbForm.Controls.Add(this.label8, 0, 1);
            this.tbForm.Controls.Add(this.btnSave, 6, 4);
            this.tbForm.Controls.Add(this.btnSelectPerson, 6, 0);
            this.tbForm.Controls.Add(this.label3, 0, 2);
            this.tbForm.Controls.Add(this.txtPassword, 1, 2);
            this.tbForm.Controls.Add(this.label9, 0, 3);
            this.tbForm.Controls.Add(this.chkIsActive, 4, 3);
            this.tbForm.Controls.Add(this.txtConfirmPassword, 1, 3);
            this.tbForm.Controls.Add(this.label2, 3, 1);
            this.tbForm.Controls.Add(this.cbRoles, 4, 1);
            this.tbForm.Location = new System.Drawing.Point(3, 16);
            this.tbForm.Name = "tbForm";
            this.tbForm.RowCount = 5;
            this.tbForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.875F));
            this.tbForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.125F));
            this.tbForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tbForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tbForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbForm.Size = new System.Drawing.Size(556, 266);
            this.tbForm.TabIndex = 2;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(111, 29);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(111, 20);
            this.lblUserID.TabIndex = 28;
            this.lblUserID.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID:";
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(334, 228);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 35);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(237, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 21);
            this.label11.TabIndex = 30;
            this.label11.Text = "PersonID:";
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(334, 29);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(123, 20);
            this.lblPersonID.TabIndex = 31;
            this.lblPersonID.Text = "0";
            // 
            // txtUsername
            // 
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(111, 76);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(111, 26);
            this.txtUsername.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 21);
            this.label8.TabIndex = 7;
            this.label8.Text = "Username:";
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(471, 228);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 35);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSelectPerson
            // 
            this.btnSelectPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectPerson.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectPerson.ForeColor = System.Drawing.Color.White;
            this.btnSelectPerson.Location = new System.Drawing.Point(471, 3);
            this.btnSelectPerson.Name = "btnSelectPerson";
            this.btnSelectPerson.Size = new System.Drawing.Size(82, 43);
            this.btnSelectPerson.TabIndex = 11;
            this.btnSelectPerson.Text = "Select person";
            this.btnSelectPerson.UseVisualStyleBackColor = true;
            this.btnSelectPerson.Click += new System.EventHandler(this.btnSelectPerson_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(111, 137);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(111, 26);
            this.txtPassword.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 42);
            this.label9.TabIndex = 29;
            this.label9.Text = "Confirm Password:";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(334, 169);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(123, 25);
            this.chkIsActive.TabIndex = 33;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(111, 196);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(111, 26);
            this.txtConfirmPassword.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(237, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 21);
            this.label2.TabIndex = 34;
            this.label2.Text = "Role:";
            // 
            // cbRoles
            // 
            this.cbRoles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbRoles.FormattingEnabled = true;
            this.cbRoles.Location = new System.Drawing.Point(334, 81);
            this.cbRoles.Name = "cbRoles";
            this.cbRoles.Size = new System.Drawing.Size(123, 21);
            this.cbRoles.TabIndex = 35;
            // 
            // ctrAddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbForm);
            this.Name = "ctrAddUpdateUser";
            this.Size = new System.Drawing.Size(562, 285);
            this.gbForm.ResumeLayout(false);
            this.tbForm.ResumeLayout(false);
            this.tbForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tbForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSelectPerson;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.CheckBox chkIsActive;
        public UI_Theme.CustomGroupBox gbForm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbRoles;
    }
}
