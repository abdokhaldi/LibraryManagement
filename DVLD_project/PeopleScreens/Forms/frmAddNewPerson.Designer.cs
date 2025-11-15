namespace DVLD_project.People.Forms
{
    partial class frmAddNewPerson
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
            this.lblLogoTitle = new System.Windows.Forms.Label();
            this.ctrAddPerson1 = new DVLD_project.People.Components.ctrAddPerson();
            this.SuspendLayout();
            // 
            // lblLogoTitle
            // 
            this.lblLogoTitle.AutoSize = true;
            this.lblLogoTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblLogoTitle.Location = new System.Drawing.Point(278, 25);
            this.lblLogoTitle.Name = "lblLogoTitle";
            this.lblLogoTitle.Size = new System.Drawing.Size(186, 25);
            this.lblLogoTitle.TabIndex = 6;
            this.lblLogoTitle.Text = "Add New Person";
            // 
            // ctrAddPerson1
            // 
            this.ctrAddPerson1.Location = new System.Drawing.Point(8, 77);
            this.ctrAddPerson1.Name = "ctrAddPerson1";
            this.ctrAddPerson1.Size = new System.Drawing.Size(738, 332);
            this.ctrAddPerson1.TabIndex = 0;
            this.ctrAddPerson1.Load += new System.EventHandler(this.ctrAddPerson1_Load);
            // 
            // frmAddNewPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 413);
            this.Controls.Add(this.lblLogoTitle);
            this.Controls.Add(this.ctrAddPerson1);
            this.Name = "frmAddNewPerson";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmAddNewPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.ctrAddPerson ctrAddPerson1;
        private System.Windows.Forms.Label lblLogoTitle;
    }
}