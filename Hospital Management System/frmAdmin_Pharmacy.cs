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
    public partial class frmAdmin_Pharmacy : Form
    {

        public static frmAdmin_Medicine Medicine = new frmAdmin_Medicine() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        public static frmAdmin_Pharmacist Pharmacist = new frmAdmin_Pharmacist() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        public frmAdmin_Pharmacy()
        {
            InitializeComponent();
            showMedicine();
        }

        private void frmAdmin_Pharmacy_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Medicine);
            this.Controls.Add(Pharmacist);
            Medicine.Show();
            Pharmacist.Show();
        }
        public static void showMedicine()
        {
            Medicine.Show();
            Pharmacist.Hide();
        }
        public static void showPharmacist()
        {
            Medicine.Hide();
            Pharmacist.Show();
        }

        private void frmAdmin_Pharmacy_VisibleChanged(object sender, EventArgs e)
        {
            if (Medicine.Visible == false)
            {
                Medicine.Hide();
                Medicine.Show();
            }
            else
            {
                Pharmacist.Hide();
                Pharmacist.Show();
            }
        }
    }
}
