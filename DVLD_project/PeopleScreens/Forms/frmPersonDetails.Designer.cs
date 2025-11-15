namespace DVLD_project.People.Forms
{
    partial class frmPersonDetails
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblLogoPersonDetails = new System.Windows.Forms.Label();
            this.ctrPersonDetails1 = new DVLD_project.People.Components.ctrPersonDetails();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(566, 258);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 42);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // lblLogoPersonDetails
            // 
            this.lblLogoPersonDetails.AutoSize = true;
            this.lblLogoPersonDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogoPersonDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblLogoPersonDetails.Location = new System.Drawing.Point(348, 9);
            this.lblLogoPersonDetails.Name = "lblLogoPersonDetails";
            this.lblLogoPersonDetails.Size = new System.Drawing.Size(257, 39);
            this.lblLogoPersonDetails.TabIndex = 6;
            this.lblLogoPersonDetails.Text = "Person Details";
            // 
            // ctrPersonDetails1
            // 
            this.ctrPersonDetails1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrPersonDetails1.Location = new System.Drawing.Point(12, 63);
            this.ctrPersonDetails1.Name = "ctrPersonDetails1";
            this.ctrPersonDetails1.Size = new System.Drawing.Size(902, 306);
            this.ctrPersonDetails1.TabIndex = 7;
            // 
            // frmPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 367);
            this.Controls.Add(this.ctrPersonDetails1);
            this.Controls.Add(this.lblLogoPersonDetails);
            this.Controls.Add(this.btnClose);
            this.Name = "frmPersonDetails";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblLogoPersonDetails;
        private Components.ctrPersonDetails ctrPersonDetails1;
    }
}