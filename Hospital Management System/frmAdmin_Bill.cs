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
    public partial class frmAdmin_Bill : Form
    {
        public frmAdmin_Bill()
        {
            InitializeComponent();
        }

        private void btnShowAccountant_Click(object sender, EventArgs e)
        {
            frmAdmin_Billing.showAccountant();
        }
    }
}
