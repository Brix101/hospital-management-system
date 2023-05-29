namespace Hospital_Management_System
{
    partial class frmAdmin_PatientView
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnShowAppointment = new System.Windows.Forms.Button();
            this.lvPatient = new System.Windows.Forms.ListView();
            this.LastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MiddleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Gender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Birthdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContactNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Street_Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Municipality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Province = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Zip_Code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PatientID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddressID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Image = global::Hospital_Management_System.Properties.Resources.icons8_search_filled_30px;
            this.label1.Location = new System.Drawing.Point(568, 35);
            this.label1.MinimumSize = new System.Drawing.Size(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 29);
            this.label1.TabIndex = 11;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(147)))), ((int)(((byte)(165)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(909, 31);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 37);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(147)))), ((int)(((byte)(165)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Location = new System.Drawing.Point(828, 31);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 37);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(147)))), ((int)(((byte)(165)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(666, 31);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 37);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(329, 35);
            this.txtSearch.MaximumSize = new System.Drawing.Size(243, 30);
            this.txtSearch.MinimumSize = new System.Drawing.Size(243, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(243, 29);
            this.txtSearch.TabIndex = 7;
            // 
            // btnShowAppointment
            // 
            this.btnShowAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(147)))), ((int)(((byte)(165)))));
            this.btnShowAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAppointment.Location = new System.Drawing.Point(12, 12);
            this.btnShowAppointment.Name = "btnShowAppointment";
            this.btnShowAppointment.Size = new System.Drawing.Size(150, 37);
            this.btnShowAppointment.TabIndex = 20;
            this.btnShowAppointment.Text = "View Admitted";
            this.btnShowAppointment.UseVisualStyleBackColor = false;
            this.btnShowAppointment.Click += new System.EventHandler(this.btnShowAppointment_Click);
            // 
            // lvPatient
            // 
            this.lvPatient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LastName,
            this.FirstName,
            this.MiddleName,
            this.Gender,
            this.Birthdate,
            this.Email,
            this.ContactNo,
            this.Street_Address,
            this.Municipality,
            this.Province,
            this.Zip_Code,
            this.PatientID,
            this.AddressID});
            this.lvPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPatient.FullRowSelect = true;
            this.lvPatient.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvPatient.HideSelection = false;
            this.lvPatient.Location = new System.Drawing.Point(59, 91);
            this.lvPatient.Name = "lvPatient";
            this.lvPatient.Size = new System.Drawing.Size(1106, 573);
            this.lvPatient.TabIndex = 21;
            this.lvPatient.UseCompatibleStateImageBehavior = false;
            this.lvPatient.View = System.Windows.Forms.View.Details;
            this.lvPatient.SelectedIndexChanged += new System.EventHandler(this.lvRoom_SelectedIndexChanged);
            this.lvPatient.VisibleChanged += new System.EventHandler(this.lvPatient_VisibleChanged);
            // 
            // LastName
            // 
            this.LastName.Text = "LastName";
            this.LastName.Width = 100;
            // 
            // FirstName
            // 
            this.FirstName.Text = "FirstName";
            this.FirstName.Width = 100;
            // 
            // MiddleName
            // 
            this.MiddleName.Text = "MiddleName";
            this.MiddleName.Width = 100;
            // 
            // Gender
            // 
            this.Gender.Text = "Gender";
            this.Gender.Width = 100;
            // 
            // Birthdate
            // 
            this.Birthdate.Text = "Birthdate";
            this.Birthdate.Width = 100;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 100;
            // 
            // ContactNo
            // 
            this.ContactNo.Text = "ContactNo";
            this.ContactNo.Width = 100;
            // 
            // Street_Address
            // 
            this.Street_Address.Text = "Street  Address";
            this.Street_Address.Width = 100;
            // 
            // Municipality
            // 
            this.Municipality.Text = "Municipality";
            this.Municipality.Width = 100;
            // 
            // Province
            // 
            this.Province.Text = "Province";
            this.Province.Width = 100;
            // 
            // Zip_Code
            // 
            this.Zip_Code.Text = "Zip Code";
            this.Zip_Code.Width = 100;
            // 
            // PatientID
            // 
            this.PatientID.Text = "PatientID";
            this.PatientID.Width = 0;
            // 
            // AddressID
            // 
            this.AddressID.Text = "AddressID";
            this.AddressID.Width = 0;
            // 
            // btnAdmit
            // 
            this.btnAdmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(147)))), ((int)(((byte)(165)))));
            this.btnAdmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmit.ForeColor = System.Drawing.Color.Black;
            this.btnAdmit.Location = new System.Drawing.Point(747, 31);
            this.btnAdmit.Name = "btnAdmit";
            this.btnAdmit.Size = new System.Drawing.Size(75, 37);
            this.btnAdmit.TabIndex = 22;
            this.btnAdmit.Text = "Admit";
            this.btnAdmit.UseVisualStyleBackColor = false;
            this.btnAdmit.Click += new System.EventHandler(this.btnAdmit_Click);
            // 
            // frmAdmin_PatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1218, 748);
            this.Controls.Add(this.btnAdmit);
            this.Controls.Add(this.lvPatient);
            this.Controls.Add(this.btnShowAppointment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdmin_PatientView";
            this.Text = "frmAdmin_Patient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnShowAppointment;
        private System.Windows.Forms.ListView lvPatient;
        private System.Windows.Forms.ColumnHeader LastName;
        private System.Windows.Forms.ColumnHeader FirstName;
        private System.Windows.Forms.ColumnHeader MiddleName;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Gender;
        private System.Windows.Forms.ColumnHeader Birthdate;
        private System.Windows.Forms.ColumnHeader ContactNo;
        private System.Windows.Forms.ColumnHeader Street_Address;
        private System.Windows.Forms.ColumnHeader Municipality;
        private System.Windows.Forms.ColumnHeader Province;
        private System.Windows.Forms.ColumnHeader Zip_Code;
        private System.Windows.Forms.ColumnHeader PatientID;
        private System.Windows.Forms.ColumnHeader AddressID;
        private System.Windows.Forms.Button btnAdmit;
    }
}