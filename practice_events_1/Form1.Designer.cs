namespace practice_events_1
{
    partial class Form1
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblResult = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.calculationControl1 = new practice_events_1.calculationControl();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(341, 322);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(32, 33);
            this.lblResult.TabIndex = 7;
            this.lblResult.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "Result :";
            // 
            // calculationControl1
            // 
            this.calculationControl1.Location = new System.Drawing.Point(70, 41);
            this.calculationControl1.Name = "calculationControl1";
            this.calculationControl1.Size = new System.Drawing.Size(555, 245);
            this.calculationControl1.TabIndex = 8;
            this.calculationControl1.OnCalculationCompleted += new System.EventHandler<practice_events_1.calculationControl.Bag>(this.calculationControl1_OnCalculationCompleted);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(700, 396);
            this.Controls.Add(this.calculationControl1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label3;
        private calculationControl calculationControl1;
    }
}

