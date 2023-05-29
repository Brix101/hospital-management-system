using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class frmMain : Form
    {
        SqlConnection con = Database.db_connect();

        public static frmAdmin Admin = new frmAdmin() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        public static frmDoctor Doctor = new frmDoctor() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        public static frmLogin Login = new frmLogin() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        public static frmNurse Nurse = new frmNurse() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        public static frmAccountant accountant = new frmAccountant() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        public static frmPharmacist pharmacist = new frmPharmacist() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
       // public static frmError error = new frmError() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };


         static   Color bgcolor = Color.FromArgb(192, 192, 255);
        public static string errormessage;

        public frmMain()
        {
            InitializeComponent();
             showLogin();
           // showAdmin();
        }

        public void conerror()
        {
            Database.db_connect();
            try
            {
                if (Database.con.State == ConnectionState.Closed)
                {
                    Database.con.Open();
             //       this.pnlContainer.Controls.Remove(pnlError);
                    showLogin();

                }
            }
            catch (Exception ex)
            {
              //  txtError.Text = "Please Check Your Connection!!!       " + ex.Message;
            }
        }
      

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.pnlContainer.Controls.Add(Admin);
            this.pnlContainer.Controls.Add(Doctor);
            this.pnlContainer.Controls.Add(Login);
            this.pnlContainer.Controls.Add(Nurse);
            this.pnlContainer.Controls.Add(accountant);
            this.pnlContainer.Controls.Add(pharmacist);
        }
        
        public static void showAdmin()
        {
            Admin.Show();
            Doctor.Hide();
            Login.Hide();
            Nurse.Hide();
            accountant.Hide();
            pharmacist.Hide();

        }
        public static void showDoctor()
        {
            Admin.Hide();
            Doctor.Show();
            Login.Hide();
            Nurse.Hide();
            accountant.Hide();
            pharmacist.Hide();
        }
        public static void showLogin()
        {
            Admin.Hide();
            Doctor.Hide();
            Login.Show();
            Nurse.Hide();
            accountant.Hide();
            pharmacist.Hide();

        }
        public static void showNurse()
        {
            Admin.Hide();
            Doctor.Hide();
            Login.Hide();
            Nurse.Show();
            accountant.Hide();
            pharmacist.Hide();
        }
        public static void showBilling()
        {
            Admin.Hide();
            Doctor.Hide();
            Login.Hide();
            Nurse.Hide();
            accountant.Show();
            pharmacist.Hide();

        }
        public static void showPharmacy()
        {
            Admin.Hide();
            Doctor.Hide();
            Login.Hide();
            Nurse.Hide();
            accountant.Hide();
            pharmacist.Show();

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@actiontype", "DeleteData");
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            RealTimeUpdate.Update();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            btnMinimize.ForeColor = Color.Black;
            btnMinimize.BackColor = Color.FromArgb(76, 87, 105);
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.ForeColor = Color.White;
            btnMinimize.BackColor = Color.FromArgb(36, 47, 65);
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.ForeColor = Color.Red;
            btnExit.BackColor = Color.FromArgb(76, 87, 105);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.ForeColor = Color.White;
            btnExit.BackColor = Color.FromArgb(36, 47, 65);
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {

        }
    }
}
