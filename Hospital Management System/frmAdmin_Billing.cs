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
    public partial class frmAdmin_Billing : Form
    {
        public static frmAdmin_Accountant Accountant = new frmAdmin_Accountant() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        public static frmAdmin_Bill Bill = new frmAdmin_Bill() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        public frmAdmin_Billing()
        {
            InitializeComponent();
        }

        private void frmAdmin_Billing_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Bill);
            this.Controls.Add(Accountant);
            Accountant.Show();
            Bill.Show();
        }
        public static void showAccountant()
        {
           Accountant.Show();
            Bill.Hide();
        }
        public static void showBill()
        {
            Accountant.Hide();
            Bill.Show();
        }
        private void frmAdmin_Billing_VisibleChanged(object sender, EventArgs e)
        {
            if (Bill.Visible == false)
            {
                Bill.Hide();
                Bill.Show();
            }
            else
            {
                Accountant.Hide();
                Accountant.Show();
            }
        }
    }
}
