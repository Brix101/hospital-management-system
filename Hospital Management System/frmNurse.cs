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
    public partial class frmNurse : Form
    {
        frmAdmin_Patient patient = new frmAdmin_Patient() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmProfile profile = new frmProfile() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        int width, height;

        public frmNurse()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmMain.showLogin();
        }

        private void frmNurse_Load(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Add(patient);
            this.pnlContainer.Controls.Add(profile);
            patient.Show();
            profile.Show();
        }

        private void btnLogOut_MouseHover(object sender, EventArgs e)
        {
            btnLogOut.ForeColor = Color.Red;
            btnLogOut.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void btnLogOut_MouseLeave(object sender, EventArgs e)
        {
            btnLogOut.ForeColor = Color.Black;
            btnLogOut.BackColor = Color.FromArgb(136, 147, 165);
        }
        private void btnPatient_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(patient);
            btnSelected(btnPatient);
            patient.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(profile);
            btnSelected(btnProfile);
            profile.Show();
        }
        private void btnSelected(Button x)
        {
            if (x == btnPatient)
            {
                btnSelect(btnPatient);
                btnunSelect(btnProfile);
            }
            if (x == btnProfile)
            {
                btnunSelect(btnPatient);
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

        private void btnPatient_Click_1(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(patient);
            btnSelected(btnPatient);
            patient.Show();
        }

        private void btnProfile_Click_1(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(profile);
            btnSelected(btnProfile);
            profile.Show();
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
    }
}
