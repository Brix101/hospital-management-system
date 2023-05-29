namespace Hospital_Management_System
{
    partial class frmAdmin_Bill
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
            this.btnShowAccountant = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowAccountant
            // 
            this.btnShowAccountant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(147)))), ((int)(((byte)(165)))));
            this.btnShowAccountant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAccountant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAccountant.Location = new System.Drawing.Point(12, 12);
            this.btnShowAccountant.Name = "btnShowAccountant";
            this.btnShowAccountant.Size = new System.Drawing.Size(150, 37);
            this.btnShowAccountant.TabIndex = 20;
            this.btnShowAccountant.Text = "View Accountant";
            this.btnShowAccountant.UseVisualStyleBackColor = false;
            this.btnShowAccountant.Click += new System.EventHandler(this.btnShowAccountant_Click);
            // 
            // frmAdmin_Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1218, 748);
            this.Controls.Add(this.btnShowAccountant);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdmin_Bill";
            this.Text = "frmAdmin_Billing";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnShowAccountant;
    }
}