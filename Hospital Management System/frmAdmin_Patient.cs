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
    public partial class frmAdmin_Patient : Form
    {
        public static frmAdmin_Admitted Appointment = new frmAdmin_Admitted() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        public static frmAdmin_PatientView PatientView = new frmAdmin_PatientView() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        public frmAdmin_Patient()
        {
            InitializeComponent();
        }

        private void frmAdmin_Patient_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Appointment);
            this.Controls.Add(PatientView);
            Appointment.Show();
            PatientView.Show();
        }
        public static void showAppointment()
        {
            Appointment.Show();
            PatientView.Hide();
        }
        public static void showPatient()
        {
            Appointment.Hide();
            PatientView.Show();
        }

        private void frmAdmin_Patient_VisibleChanged(object sender, EventArgs e)
        {
            if (Appointment.Visible == false)
            {
                Appointment.Hide();
                Appointment.Show();
            }
            else
            {
                PatientView.Hide();
                PatientView.Show();
            }
        }
    }
}
