namespace Hospital_Management_System
{
    partial class frmAdmin_Admitted
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
            this.btnShowPatient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDischarged = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lvPatient = new System.Windows.Forms.ListView();
            this.PatientName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FloorNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RoomNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DoctorName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Diagnosis = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateTimeIN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AdmitID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnShowPatient
            // 
            this.btnShowPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(147)))), ((int)(((byte)(165)))));
            this.btnShowPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowPatient.Location = new System.Drawing.Point(12, 12);
            this.btnShowPatient.Name = "btnShowPatient";
            this.btnShowPatient.Size = new System.Drawing.Size(150, 37);
            this.btnShowPatient.TabIndex = 20;
            this.btnShowPatient.Text = "View Patient";
            this.btnShowPatient.UseVisualStyleBackColor = false;
            this.btnShowPatient.Click += new System.EventHandler(this.btnShowPatient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Image = global::Hospital_Management_System.Properties.Resources.icons8_search_filled_30px;
            this.label1.Location = new System.Drawing.Point(568, 35);
            this.label1.MinimumSize = new System.Drawing.Size(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 29);
            this.label1.TabIndex = 26;
            // 
            // btnDischarged
            // 
            this.btnDischarged.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(147)))), ((int)(((byte)(165)))));
            this.btnDischarged.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDischarged.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDischarged.Location = new System.Drawing.Point(666, 31);
            this.btnDischarged.Name = "btnDischarged";
            this.btnDischarged.Size = new System.Drawing.Size(103, 37);
            this.btnDischarged.TabIndex = 23;
            this.btnDischarged.Text = "Discharged";
            this.btnDischarged.UseVisualStyleBackColor = false;
            this.btnDischarged.Click += new System.EventHandler(this.btnDischarged_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(329, 35);
            this.txtSearch.MaximumSize = new System.Drawing.Size(243, 30);
            this.txtSearch.MinimumSize = new System.Drawing.Size(243, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(243, 29);
            this.txtSearch.TabIndex = 22;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lvPatient
            // 
            this.lvPatient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PatientName,
            this.FloorNo,
            this.RoomNo,
            this.DoctorName,
            this.Diagnosis,
            this.DateTimeIN,
            this.AdmitID});
            this.lvPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPatient.FullRowSelect = true;
            this.lvPatient.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvPatient.HideSelection = false;
            this.lvPatient.Location = new System.Drawing.Point(153, 91);
            this.lvPatient.Name = "lvPatient";
            this.lvPatient.Size = new System.Drawing.Size(904, 573);
            this.lvPatient.TabIndex = 27;
            this.lvPatient.UseCompatibleStateImageBehavior = false;
            this.lvPatient.View = System.Windows.Forms.View.Details;
            // 
            // PatientName
            // 
            this.PatientName.Text = "Patient Name";
            this.PatientName.Width = 200;
            // 
            // FloorNo
            // 
            this.FloorNo.Text = "FloorNo";
            this.FloorNo.Width = 75;
            // 
            // RoomNo
            // 
            this.RoomNo.Text = "RoomNo";
            this.RoomNo.Width = 75;
            // 
            // DoctorName
            // 
            this.DoctorName.Text = "Doctor Name";
            this.DoctorName.Width = 200;
            // 
            // Diagnosis
            // 
            this.Diagnosis.Text = "Diagnosis";
            this.Diagnosis.Width = 150;
            // 
            // DateTimeIN
            // 
            this.DateTimeIN.Text = "Date Admitted";
            this.DateTimeIN.Width = 200;
            // 
            // AdmitID
            // 
            this.AdmitID.Text = "AdmitID";
            this.AdmitID.Width = 0;
            // 
            // frmAdmin_Admitted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1218, 748);
            this.Controls.Add(this.lvPatient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDischarged);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnShowPatient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdmin_Admitted";
            this.Text = "frmAdmin_Patient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowPatient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDischarged;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListView lvPatient;
        private System.Windows.Forms.ColumnHeader PatientName;
        private System.Windows.Forms.ColumnHeader RoomNo;
        private System.Windows.Forms.ColumnHeader FloorNo;
        private System.Windows.Forms.ColumnHeader DateTimeIN;
        private System.Windows.Forms.ColumnHeader DoctorName;
        private System.Windows.Forms.ColumnHeader Diagnosis;
        private System.Windows.Forms.ColumnHeader AdmitID;
    }
}