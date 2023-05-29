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
    public partial class dlConAd : Form
    {
        static SqlConnection con = Database.db_connect();
        public static DialogResult res;
        public dlConAd()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Usertype() == "Admin")
            {
                DialogResult result = MessageBox.Show("Are you sure to Delete", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    res = result;
                    this.Close();
                }

            }
            else
            {
                DialogResult res = MessageBox.Show("Error", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (DialogResult.Cancel == res)
                {
                    this.Close();
                }
            }
        }
        public int UserID()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username ", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@actiontype", "UserChecker");
            int userID = Convert.ToInt32(cmd.ExecuteScalar());
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
