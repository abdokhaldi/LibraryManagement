namespace DVLD_project.PeopleScreens.Components
{
    partial class ctrAddPersonWithFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrAddPersonWithFilter));
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilterPrsn = new System.Windows.Forms.TextBox();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.plSearchFilter = new System.Windows.Forms.Panel();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ctrPersonDetails1 = new DVLD_project.People.Components.ctrPersonDetails();
            this.gbFilter.SuspendLayout();
            this.plSearchFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "NationalNo"});
            this.cbFilterBy.Location = new System.Drawing.Point(199, 34);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(140, 37);
            this.cbFilterBy.TabIndex = 24;
            this.cbFilterBy.Text = "None";
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 29);
            this.label4.TabIndex = 25;
            this.label4.Text = "Filter by :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtFilterPrsn
            // 
            this.txtFilterPrsn.Location = new System.Drawing.Point(3, 6);
            this.txtFilterPrsn.Multiline = true;
            this.txtFilterPrsn.Name = "txtFilterPrsn";
            this.txtFilterPrsn.Size = new System.Drawing.Size(184, 33);
            this.txtFilterPrsn.TabIndex = 23;
            this.txtFilterPrsn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterPrsn_KeyPress);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.cbFilterBy);
            this.gbFilter.Controls.Add(this.plSearchFilter);
            this.gbFilter.Controls.Add(this.label4);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(12, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(667, 89);
            this.gbFilter.TabIndex = 26;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter :";
            // 
            // plSearchFilter
            // 
            this.plSearchFilter.Controls.Add(this.btnAddPerson);
            this.plSearchFilter.Controls.Add(this.btnSearch);
            this.plSearchFilter.Controls.Add(this.txtFilterPrsn);
            this.plSearchFilter.Location = new System.Drawing.Point(354, 29);
            this.plSearchFilter.Name = "plSearchFilter";
            this.plSearchFilter.Size = new System.Drawing.Size(307, 47);
            this.plSearchFilter.TabIndex = 27;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddPerson.BackgroundImage")));
            this.btnAddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddPerson.Location = new System.Drawing.Point(251, 3);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(53, 41);
            this.btnAddPerson.TabIndex = 27;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.Location = new System.Drawing.Point(193, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 41);
            this.btnSearch.TabIndex = 26;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ctrPersonDetails1
            // 
            this.ctrPersonDetails1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrPersonDetails1.Location = new System.Drawing.Point(12, 98);
            this.ctrPersonDetails1.Name = "ctrPersonDetails1";
            this.ctrPersonDetails1.Size = new System.Drawing.Size(950, 313);
            this.ctrPersonDetails1.TabIndex = 1;
            // 
            // ctrAddPersonWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.ctrPersonDetails1);
            this.Name = "ctrAddPersonWithFilter";
            this.Size = new System.Drawing.Size(965, 415);
            this.Load += new System.EventHandler(this.ctrAddPersonWithFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.plSearchFilter.ResumeLayout(false);
            this.plSearchFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private People.Components.ctrPersonDetails ctrPersonDetails1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilterPrsn;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel plSearchFilter;
    }
}
