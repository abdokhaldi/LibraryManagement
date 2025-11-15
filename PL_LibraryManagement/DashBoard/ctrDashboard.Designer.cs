namespace PL_LibraryManagement.DashBoard
{
    partial class ctrStatistics
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
            this.lblTitleBooks = new System.Windows.Forms.Label();
            this.lblTitleMembers = new System.Windows.Forms.Label();
            this.lblTitleLate = new System.Windows.Forms.Label();
            this.plBooks = new System.Windows.Forms.Panel();
            this.lblBooks = new System.Windows.Forms.Label();
            this.plMembers = new System.Windows.Forms.Panel();
            this.lblMembers = new System.Windows.Forms.Label();
            this.plLate = new System.Windows.Forms.Panel();
            this.lblLate = new System.Windows.Forms.Label();
            this.plBorrowings = new System.Windows.Forms.Panel();
            this.lblBorrowings = new System.Windows.Forms.Label();
            this.lblTitleBorrowings = new System.Windows.Forms.Label();
            this.plStats = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tblPanel = new System.Windows.Forms.TableLayoutPanel();
            this.plBooks.SuspendLayout();
            this.plMembers.SuspendLayout();
            this.plLate.SuspendLayout();
            this.plBorrowings.SuspendLayout();
            this.plStats.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tblPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitleBooks
            // 
            this.lblTitleBooks.AutoSize = true;
            this.lblTitleBooks.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleBooks.Location = new System.Drawing.Point(55, 20);
            this.lblTitleBooks.Name = "lblTitleBooks";
            this.lblTitleBooks.Size = new System.Drawing.Size(79, 30);
            this.lblTitleBooks.TabIndex = 0;
            this.lblTitleBooks.Text = "Books ";
            // 
            // lblTitleMembers
            // 
            this.lblTitleMembers.AutoSize = true;
            this.lblTitleMembers.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleMembers.Location = new System.Drawing.Point(40, 20);
            this.lblTitleMembers.Name = "lblTitleMembers";
            this.lblTitleMembers.Size = new System.Drawing.Size(110, 30);
            this.lblTitleMembers.TabIndex = 2;
            this.lblTitleMembers.Text = "Members ";
            // 
            // lblTitleLate
            // 
            this.lblTitleLate.AutoSize = true;
            this.lblTitleLate.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleLate.Location = new System.Drawing.Point(53, 30);
            this.lblTitleLate.Name = "lblTitleLate";
            this.lblTitleLate.Size = new System.Drawing.Size(60, 30);
            this.lblTitleLate.TabIndex = 3;
            this.lblTitleLate.Text = "Late ";
            // 
            // plBooks
            // 
            this.plBooks.BackColor = System.Drawing.Color.SkyBlue;
            this.plBooks.Controls.Add(this.lblBooks);
            this.plBooks.Controls.Add(this.lblTitleBooks);
            this.plBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plBooks.Location = new System.Drawing.Point(3, 3);
            this.plBooks.Name = "plBooks";
            this.plBooks.Size = new System.Drawing.Size(175, 164);
            this.plBooks.TabIndex = 4;
            // 
            // lblBooks
            // 
            this.lblBooks.AutoSize = true;
            this.lblBooks.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooks.Location = new System.Drawing.Point(65, 68);
            this.lblBooks.Name = "lblBooks";
            this.lblBooks.Size = new System.Drawing.Size(49, 30);
            this.lblBooks.TabIndex = 3;
            this.lblBooks.Text = "200";
            // 
            // plMembers
            // 
            this.plMembers.BackColor = System.Drawing.Color.Red;
            this.plMembers.Controls.Add(this.lblMembers);
            this.plMembers.Controls.Add(this.lblTitleMembers);
            this.plMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMembers.Location = new System.Drawing.Point(365, 3);
            this.plMembers.Name = "plMembers";
            this.plMembers.Size = new System.Drawing.Size(175, 164);
            this.plMembers.TabIndex = 5;
            // 
            // lblMembers
            // 
            this.lblMembers.AutoSize = true;
            this.lblMembers.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembers.Location = new System.Drawing.Point(72, 68);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new System.Drawing.Size(49, 30);
            this.lblMembers.TabIndex = 3;
            this.lblMembers.Text = "100";
            // 
            // plLate
            // 
            this.plLate.BackColor = System.Drawing.Color.DarkOrange;
            this.plLate.Controls.Add(this.lblLate);
            this.plLate.Controls.Add(this.lblTitleLate);
            this.plLate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plLate.Location = new System.Drawing.Point(546, 3);
            this.plLate.Name = "plLate";
            this.plLate.Size = new System.Drawing.Size(178, 164);
            this.plLate.TabIndex = 6;
            // 
            // lblLate
            // 
            this.lblLate.AutoSize = true;
            this.lblLate.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLate.Location = new System.Drawing.Point(70, 68);
            this.lblLate.Name = "lblLate";
            this.lblLate.Size = new System.Drawing.Size(25, 30);
            this.lblLate.TabIndex = 4;
            this.lblLate.Text = "5";
            // 
            // plBorrowings
            // 
            this.plBorrowings.BackColor = System.Drawing.Color.LightSlateGray;
            this.plBorrowings.Controls.Add(this.lblBorrowings);
            this.plBorrowings.Controls.Add(this.lblTitleBorrowings);
            this.plBorrowings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plBorrowings.Location = new System.Drawing.Point(184, 3);
            this.plBorrowings.Name = "plBorrowings";
            this.plBorrowings.Size = new System.Drawing.Size(175, 164);
            this.plBorrowings.TabIndex = 7;
            // 
            // lblBorrowings
            // 
            this.lblBorrowings.AutoSize = true;
            this.lblBorrowings.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorrowings.Location = new System.Drawing.Point(69, 87);
            this.lblBorrowings.Name = "lblBorrowings";
            this.lblBorrowings.Size = new System.Drawing.Size(37, 30);
            this.lblBorrowings.TabIndex = 3;
            this.lblBorrowings.Text = "50";
            // 
            // lblTitleBorrowings
            // 
            this.lblTitleBorrowings.AutoSize = true;
            this.lblTitleBorrowings.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleBorrowings.Location = new System.Drawing.Point(25, 30);
            this.lblTitleBorrowings.Name = "lblTitleBorrowings";
            this.lblTitleBorrowings.Size = new System.Drawing.Size(132, 30);
            this.lblTitleBorrowings.TabIndex = 0;
            this.lblTitleBorrowings.Text = "Borrowings ";
            // 
            // plStats
            // 
            this.plStats.Controls.Add(this.flowLayoutPanel1);
            this.plStats.Controls.Add(this.tblPanel);
            this.plStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.plStats.Location = new System.Drawing.Point(0, 0);
            this.plStats.Name = "plStats";
            this.plStats.Padding = new System.Windows.Forms.Padding(10);
            this.plStats.Size = new System.Drawing.Size(747, 325);
            this.plStats.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblTitle);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(727, 68);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(167, 47);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Statistics";
            // 
            // tblPanel
            // 
            this.tblPanel.ColumnCount = 4;
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblPanel.Controls.Add(this.plBorrowings, 1, 0);
            this.tblPanel.Controls.Add(this.plBooks, 0, 0);
            this.tblPanel.Controls.Add(this.plMembers, 2, 0);
            this.tblPanel.Controls.Add(this.plLate, 3, 0);
            this.tblPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tblPanel.Location = new System.Drawing.Point(10, 145);
            this.tblPanel.Name = "tblPanel";
            this.tblPanel.RowCount = 1;
            this.tblPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPanel.Size = new System.Drawing.Size(727, 170);
            this.tblPanel.TabIndex = 2;
            // 
            // ctrStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plStats);
            this.Name = "ctrStatistics";
            this.Size = new System.Drawing.Size(747, 329);
            this.Load += new System.EventHandler(this.ctrDashboard_Load);
            this.plBooks.ResumeLayout(false);
            this.plBooks.PerformLayout();
            this.plMembers.ResumeLayout(false);
            this.plMembers.PerformLayout();
            this.plLate.ResumeLayout(false);
            this.plLate.PerformLayout();
            this.plBorrowings.ResumeLayout(false);
            this.plBorrowings.PerformLayout();
            this.plStats.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tblPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitleBooks;
        private System.Windows.Forms.Label lblTitleMembers;
        private System.Windows.Forms.Label lblTitleLate;
        private System.Windows.Forms.Panel plBooks;
        private System.Windows.Forms.Panel plMembers;
        private System.Windows.Forms.Panel plLate;
        private System.Windows.Forms.Panel plBorrowings;
        private System.Windows.Forms.Label lblTitleBorrowings;
        private System.Windows.Forms.Panel plStats;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBooks;
        private System.Windows.Forms.Label lblMembers;
        private System.Windows.Forms.Label lblLate;
        private System.Windows.Forms.Label lblBorrowings;
        private System.Windows.Forms.TableLayoutPanel tblPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
