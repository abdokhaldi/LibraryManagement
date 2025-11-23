namespace PL_LibraryManagement.Borrowings
{
    partial class ctrPersonLookUp
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
            this.txtLookUp = new System.Windows.Forms.TextBox();
            this.tbLookUp = new System.Windows.Forms.TableLayoutPanel();
            this.dgvLookUp = new System.Windows.Forms.DataGridView();
            this.tbLookUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLookUp)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLookUp
            // 
            this.txtLookUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLookUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLookUp.Location = new System.Drawing.Point(3, 3);
            this.txtLookUp.Name = "txtLookUp";
            this.txtLookUp.Size = new System.Drawing.Size(175, 26);
            this.txtLookUp.TabIndex = 0;
            this.txtLookUp.TextChanged += new System.EventHandler(this.txtLookUp_TextChanged);
            // 
            // tbLookUp
            // 
            this.tbLookUp.ColumnCount = 1;
            this.tbLookUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLookUp.Controls.Add(this.dgvLookUp, 0, 1);
            this.tbLookUp.Controls.Add(this.txtLookUp, 0, 0);
            this.tbLookUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLookUp.Location = new System.Drawing.Point(0, 0);
            this.tbLookUp.Name = "tbLookUp";
            this.tbLookUp.RowCount = 2;
            this.tbLookUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLookUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tbLookUp.Size = new System.Drawing.Size(181, 95);
            this.tbLookUp.TabIndex = 1;
            // 
            // dgvLookUp
            // 
            this.dgvLookUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLookUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLookUp.Location = new System.Drawing.Point(3, 32);
            this.dgvLookUp.Name = "dgvLookUp";
            this.dgvLookUp.Size = new System.Drawing.Size(175, 60);
            this.dgvLookUp.TabIndex = 2;
            this.dgvLookUp.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLookUp_CellDoubleClick);
            // 
            // ctrPersonLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbLookUp);
            this.Name = "ctrPersonLookUp";
            this.Size = new System.Drawing.Size(181, 95);
            this.tbLookUp.ResumeLayout(false);
            this.tbLookUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLookUp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLookUp;
        private System.Windows.Forms.TableLayoutPanel tbLookUp;
        private System.Windows.Forms.DataGridView dgvLookUp;
    }
}
