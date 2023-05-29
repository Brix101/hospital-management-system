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
    public partial class frmAdmin : Form
    {
        frmAdmin_Dashboard dashboard = new frmAdmin_Dashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmAdmin_Doctor doctor = new frmAdmin_Doctor() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmAdmin_Nurse nurse = new frmAdmin_Nurse() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmAdmin_Patient patient = new frmAdmin_Patient() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmAdmin_Room room = new frmAdmin_Room() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmAdmin_User user = new frmAdmin_User() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmAdmin_Billing billing = new frmAdmin_Billing() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmAdmin_Pharmacy pharmacy = new frmAdmin_Pharmacy() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        int width, height;

        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Add(patient);
            this.pnlContainer.Controls.Add(dashboard);
            this.pnlContainer.Controls.Add(doctor);
            this.pnlContainer.Controls.Add(nurse);
            this.pnlContainer.Controls.Add(room);
            this.pnlContainer.Controls.Add(user);
            this.pnlContainer.Controls.Add(billing);
            this.pnlContainer.Controls.Add(pharmacy);
           // dashboard.Show();
            doctor.Show();
            nurse.Show();
            patient.Show();
            room.Show();
            user.Show();
            billing.Show();
            pharmacy.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(dashboard);
            btnSelected(btnDashboard);
            dashboard.Show();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(patient);
            btnSelected(btnPatient);
            patient.Show();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(doctor);
            btnSelected(btnDoctor);
            doctor.Show();
        }

        private void btnNurse_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(nurse);
            btnSelected(btnNurse);
            nurse.Show();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(billing);
            btnSelected(btnBilling);
            billing.Show();
        }

        private void btnPharmacy_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(pharmacy);
            btnSelected(btnPharmacy);
            pharmacy.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(user);
            btnSelected(btnUser);
            user.Show();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Clear();
            this.pnlContainer.Controls.Add(room);
            btnSelected(btnRoom);
            room.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmMain.showLogin();
        }

        private void btnSelected(Button x)
        {
            if(x == btnDashboard)
            {
                btnSelect(btnDashboard);
                btnunSelect(btnPatient);
                btnunSelect(btnDoctor);
                btnunSelect(btnNurse);
                btnunSelect(btnBilling);
                btnunSelect(btnPharmacy);
                btnunSelect(btnRoom);
                btnunSelect(btnUser);
            }
            if (x == btnPatient)
            {
                btnunSelect(btnDashboard);
                btnSelect(btnPatient);
                btnunSelect(btnDoctor);
                btnunSelect(btnNurse);
                btnunSelect(btnBilling);
                btnunSelect(btnPharmacy);
                btnunSelect(btnRoom);
                btnunSelect(btnUser);
            }
            if (x == btnDoctor)
            {
                btnunSelect(btnDashboard);
                btnunSelect(btnPatient);
                btnSelect(btnDoctor);
                btnunSelect(btnNurse);
                btnunSelect(btnBilling);
                btnunSelect(btnPharmacy);
                btnunSelect(btnRoom);
                btnunSelect(btnUser);
            }
            if (x == btnNurse)
            {
                btnunSelect(btnDashboard);
                btnunSelect(btnPatient);
                btnunSelect(btnDoctor);
                btnSelect(btnNurse);
                btnunSelect(btnBilling);
                btnunSelect(btnPharmacy);
                btnunSelect(btnRoom);
                btnunSelect(btnUser);
            }
            if (x == btnBilling)
            {
                btnunSelect(btnDashboard);
                btnunSelect(btnPatient);
                btnunSelect(btnDoctor);
                btnunSelect(btnNurse);
                btnSelect(btnBilling);
                btnunSelect(btnPharmacy);
                btnunSelect(btnRoom);
                btnunSelect(btnUser);
            }
            if (x == btnPharmacy)
            {
                btnunSelect(btnDashboard);
                btnunSelect(btnPatient);
                btnunSelect(btnDoctor);
                btnunSelect(btnNurse);
                btnunSelect(btnBilling);
                btnSelect(btnPharmacy);
                btnunSelect(btnRoom);
                btnunSelect(btnUser);
            }
            if (x == btnRoom)
            {
                btnunSelect(btnDashboard);
                btnunSelect(btnPatient);
                btnunSelect(btnDoctor);
                btnunSelect(btnNurse);
                btnunSelect(btnBilling);
                btnunSelect(btnPharmacy);
                btnSelect(btnRoom);
                btnunSelect(btnUser);
            }
            if (x == btnUser)
            {
                btnunSelect(btnDashboard);
                btnunSelect(btnPatient);
                btnunSelect(btnDoctor);
                btnunSelect(btnNurse);
                btnunSelect(btnBilling);
                btnunSelect(btnPharmacy);
                btnunSelect(btnRoom);
                btnSelect(btnUser);
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
            btnDashboard.PerformClick();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogOut_MouseLeave(object sender, EventArgs e)
        {
            btnLogOut.ForeColor = Color.Black;
            btnLogOut.BackColor = Color.FromArgb(136, 147, 165);
        }

       
    }
}
