namespace EventsInPractices
{
    partial class frmMainForm
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
            this.ctrMyUserControl1 = new EventsInPractices.UserControls.ctrMyUserControl();
            this.SuspendLayout();
            // 
            // ctrMyUserControl1
            // 
            this.ctrMyUserControl1.Location = new System.Drawing.Point(48, 38);
            this.ctrMyUserControl1.Name = "ctrMyUserControl1";
            this.ctrMyUserControl1.Size = new System.Drawing.Size(477, 251);
            this.ctrMyUserControl1.TabIndex = 0;
            this.ctrMyUserControl1.OnCalculationComplete += new System.EventHandler<EventsInPractices.UserControls.ctrMyUserControl.CalculationEventArgs>(this.ctrMyUserControl1_OnCalculationComplete);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 450);
            this.Controls.Add(this.ctrMyUserControl1);
            this.Name = "frmMainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ctrMyUserControl ctrMyUserControl1;
    }
}

