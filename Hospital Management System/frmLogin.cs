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
    public partial class frmLogin : Form
    {
        SqlConnection con = Database.db_connect();
        public static int ConID=-1;
        public frmLogin()
        {
            InitializeComponent();
        }
        private int UserID()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username ", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@actiontype", "UserChecker");
            int userID = Convert.ToInt32(cmd.ExecuteScalar());
            ConID = userID;
            return userID;
        }
        private int UsertypeID()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", UserID());
            cmd.Parameters.AddWithValue("@actiontype", "InfoChecker");
            int usertypeID = Convert.ToInt32(cmd.ExecuteScalar());
            return usertypeID;
        }
        private string Usertype()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spUsertype", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsertypeID", UsertypeID());
            cmd.Parameters.AddWithValue("@actiontype", "UsertypeChecker");
            String usertype = Convert.ToString(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return usertype;
            
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (UserID() != 0)
            {
                switch (Usertype())
                {
                    case "Admin":
                        frmMain.showAdmin();
                        reset();
                        break;
                    case "Doctor":
                        frmMain.showDoctor();
                        reset();
                        break;
                    case "Nurse":
                        frmMain.showNurse();
                        reset();
                        break;
                    case "Accountant":
                        frmMain.showBilling();
                        reset();
                        break;
                    case "Pharmacist":
                        frmMain.showPharmacy();
                        reset();
                        break;
                    default:
                        MessageBox.Show("Login Failed", "Error");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Login Failed", "Error");
            }
        }
        public void reset()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            ShowPass.Checked = false;
        }

        private void ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(192, 192, 255);
            btnLogin.Font = new Font(btnLogin.Font.FontFamily, 30);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(136, 147, 165);
            btnLogin.Font = new Font(btnLogin.Font.FontFamily, 26);
        }
    }
}
