using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class frmDoctor : Form
    {
        frmDoctor_Patient patient = new frmDoctor_Patient() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmDoctor_Prescription prescription = new frmDoctor_Prescription() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmProfile profile = new frmProfile() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        int width, height;

        public frmDoctor()
        {
            InitializeComponent();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Add(patient);
            this.pnlContainer.Controls.Add(prescription);
            this.pnlContainer.Controls.Add(profile);
            patient.Show();
            prescription.Show();
            profile.Show();
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmMain.showLogin();
        }

        private void btnSelected(Button x)
        {
            if (x == btnPatient)
            {
                btnSelect(btnPatient);
                btnunSelect(btnPrescription);
                btnunSelect(btnProfile);
            }
            if (x == btnPrescription)
            {
                btnunSelect(btnPatient);
                btnSelect(btnPrescription);
                btnunSelect(btnProfile);
            }
            if (x == btnProfile)
            {
                btnunSelect(btnPatient);
                btnunSelect(btnPrescription);
                btnSelect(btnProfile);
            }

        }
        private void btnSelect(Button x)
        {

            width = this.Size.Width;
            height = this.Size.Height;
            width = 152;
            height = 50;
            x.BackColor = Color.FromArgb(192, 192, 255);
            x.Enabled = false;
            x.Size = new Size(width, height);
            x.AutoSize = false;
            x.TextAlign = ContentAlignment.MiddleRight;
        }
        private void btnunSelect(Button x)
        {
            width = this.Size.Width;
            height = this.Size.Height;
            width = 140;
            height = 50;
            x.BackColor = Color.FromArgb(136, 147, 165);
            x.Enabled = true;
            x.Size = new Size(width, height);
            x.AutoSize = false;
            x.TextAlign = ContentAlignment.MiddleLeft;
        }
        private void btnLogOut_MouseHover(object sender, EventArgs e)
        {
            btnLogOut.ForeColor = Color.Red;
            btnLogOut.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void frmAdmin_VisibleChanged(object sender, EventArgs e)
        {
            btnPatient.PerformClick();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(patient);
            btnSelected(btnPatient);
            patient.Show();
        }

        private void btnPrescription_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(prescription);
            btnSelected(btnPrescription);
            prescription.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(profile);
            btnSelected(btnProfile);
            profile.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogOut_MouseLeave(object sender, EventArgs e)
        {
            btnLogOut.ForeColor = Color.Black;
            btnLogOut.BackColor = Color.FromArgb(136, 147, 165);
        }

       
    }
}
