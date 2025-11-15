namespace DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications
{
    partial class frmAppointment
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppointment));
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.dataGridAppointments = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblApp_LOGO = new System.Windows.Forms.Label();
            this.pbApp_LOGO = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.ctrDLApplicationInfo1 = new DVLD_project.DrivingLicenseServicesScreens.LocalDrivingLicenseApplications.ctrDLApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAppointments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbApp_LOGO)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddAppointment.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddAppointment.BackgroundImage")));
            this.btnAddAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddAppointment.Location = new System.Drawing.Point(642, 415);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(45, 30);
            this.btnAddAppointment.TabIndex = 36;
            this.btnAddAppointment.UseVisualStyleBackColor = false;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // dataGridAppointments
            // 
            this.dataGridAppointments.AllowUserToAddRows = false;
            this.dataGridAppointments.AllowUserToDeleteRows = false;
            this.dataGridAppointments.AllowUserToOrderColumns = true;
            this.dataGridAppointments.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAppointments.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridAppointments.Location = new System.Drawing.Point(23, 448);
            this.dataGridAppointments.Name = "dataGridAppointments";
            this.dataGridAppointments.ReadOnly = true;
            this.dataGridAppointments.Size = new System.Drawing.Size(664, 85);
            this.dataGridAppointments.TabIndex = 39;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("takeTestToolStripMenuItem.Image")));
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 536);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "#Records :";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(611, 539);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 23);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblApp_LOGO
            // 
            this.lblApp_LOGO.AutoSize = true;
            this.lblApp_LOGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApp_LOGO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblApp_LOGO.Location = new System.Drawing.Point(229, 75);
            this.lblApp_LOGO.Name = "lblApp_LOGO";
            this.lblApp_LOGO.Size = new System.Drawing.Size(268, 25);
            this.lblApp_LOGO.TabIndex = 41;
            this.lblApp_LOGO.Text = "Vision Test Appointment";
            // 
            // pbApp_LOGO
            // 
            this.pbApp_LOGO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbApp_LOGO.Image = ((System.Drawing.Image)(resources.GetObject("pbApp_LOGO.Image")));
            this.pbApp_LOGO.Location = new System.Drawing.Point(334, 2);
            this.pbApp_LOGO.Name = "pbApp_LOGO";
            this.pbApp_LOGO.Size = new System.Drawing.Size(72, 70);
            this.pbApp_LOGO.TabIndex = 40;
            this.pbApp_LOGO.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Appointments:";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(111, 536);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(18, 20);
            this.lblRecords.TabIndex = 43;
            this.lblRecords.Text = "0";
            // 
            // ctrDLApplicationInfo1
            // 
            this.ctrDLApplicationInfo1.Location = new System.Drawing.Point(9, 103);
            this.ctrDLApplicationInfo1.Name = "ctrDLApplicationInfo1";
            this.ctrDLApplicationInfo1.Size = new System.Drawing.Size(691, 306);
            this.ctrDLApplicationInfo1.TabIndex = 0;
            // 
            // frmAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 569);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblApp_LOGO);
            this.Controls.Add(this.pbApp_LOGO);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.dataGridAppointments);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrDLApplicationInfo1);
            this.Name = "frmAppointment";
            this.Text = "frmAppointment";
            this.Load += new System.EventHandler(this.frmAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAppointments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbApp_LOGO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrDLApplicationInfo ctrDLApplicationInfo1;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.DataGridView dataGridAppointments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblApp_LOGO;
        private System.Windows.Forms.PictureBox pbApp_LOGO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}