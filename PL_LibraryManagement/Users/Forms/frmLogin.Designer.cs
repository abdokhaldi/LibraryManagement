namespace PL_LibraryManagement.Users.Forms
{
    partial class frmLogin
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
            this.ctrLogin1 = new PL_LibraryManagement.ctrLogin();
            this.SuspendLayout();
            // 
            // ctrLogin1
            // 
            this.ctrLogin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrLogin1.Location = new System.Drawing.Point(0, 0);
            this.ctrLogin1.Name = "ctrLogin1";
            this.ctrLogin1.Size = new System.Drawing.Size(459, 279);
            this.ctrLogin1.TabIndex = 1;
            this.ctrLogin1.LoginResult += new System.Action<BLL_LibraryManagement.OperationResultBLL>(this.ctrLogin1_LoginResult);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 279);
            this.Controls.Add(this.ctrLogin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrLogin ctrLogin1;
    }
}