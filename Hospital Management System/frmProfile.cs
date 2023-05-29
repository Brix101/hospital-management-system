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
    public partial class frmProfile : Form
    {
        SqlConnection con = Database.db_connect();
        int id;
        int Aid;
        string st;
        public frmProfile()
        {
            InitializeComponent();
        }
        private void frmProfile_Load(object sender, EventArgs e)
        {
            
        }
        private int ID()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", frmLogin.ConID);
            cmd.Parameters.AddWithValue("@actiontype", "FetchDoctorID");
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return id;
        }
        private void InfoRecord(int id)
        {
            SqlDataReader dr;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InfoID", id);
                cmd.Parameters.AddWithValue("@actiontype", "FetchRecord");
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtLastname.Text = dr["LastName"].ToString();
                    txtFirstName.Text = dr["FirstName"].ToString();
                    txtMiddleName.Text = dr["MiddleName"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                    st = dr["Status"].ToString();
                    txtBirthdate.Text = dr["Birthdate"].ToString();
                    txtContactNo.Text = dr["ContactNo"].ToString();
                    Aid = Convert.ToInt32(dr["AddressID"]);
                }
                cmd.Dispose();
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void UserRecord(int id)
        //{
        //    SqlDataReader dr;
        //    try
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("spUser", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@UserID", id);
        //        cmd.Parameters.AddWithValue("@actiontype", "FetchRecord");
        //        dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            txtUsername.Text = dr["Username"].ToString();
        //            txtPassword.Text = dr["Password"].ToString();
        //            txtConfirmPass.Text = dr["Password"].ToString();
        //        }
        //        cmd.Dispose();
        //        dr.Close();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        private void AddressRecord(int id)
        {
            SqlDataReader dr;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spAddress", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AddressID", id);
                cmd.Parameters.AddWithValue("@actiontype", "FetchRecord");
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtStreet.Text = dr["Street_Address"].ToString();
                    txtMunicipality.Text = dr["Municipality"].ToString();
                    txtProvince.Text = dr["Province"].ToString();
                    txtZipCode.Text = dr["Zip_Code"].ToString();
                }
                cmd.Dispose();
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            InfoRecord(ID());
        }

        private void frmProfile_VisibleChanged(object sender, EventArgs e)
        {
            InfoRecord(ID());
            AddressRecord(Aid);
            switch (st)
            {
                case "Single":
                    cbStatus.Text = "Single";
                    break;
                case "Married":
                    cbStatus.Text = "Married";
                    break;
                case "Widow":
                    cbStatus.Text = "Widow";
                    break;
                default:
                    cbStatus.Text = "Select...";
                    break;
            }
        }
    }
}
