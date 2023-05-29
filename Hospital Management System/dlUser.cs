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
    public partial class dlUser : Form
    {
        SqlConnection con = Database.db_connect();
        int id;
        int AddressID;
        int UserID;
        string usertype;
        string st;
        int ut;

        public dlUser(int indoid = 0, int userid = 0, int addressid = 0,string usert= "")
        {
            InitializeComponent();
            InfoRecord(id = indoid);
            UserRecord(UserID = userid);
            AddressRecord(AddressID = addressid);
            usertype = usert;
            if (id > 0)
            {
                switch (usertype)
                {
                    case "Doctor":
                        this.Text = " Update Doctor";
                        break;
                    case "Nurse":
                        this.Text = " Update Nurse";
                        break;
                    case "Accountant":
                        this.Text = " Update Accountant";
                        break;
                    case "Pharmacist":
                        this.Text = " Update Pharmacist";
                        break;
                    default:
                        this.Text = " Update User";
                        break;
                }
                btnSave.Text = "Update";
            }
            else
            {
                switch (usertype)
                {
                    case "Doctor":
                        this.Text = " New Doctor";
                        break;
                    case "Nurse":
                        this.Text = " New Nurse";
                        break;
                    case "Accountant":
                        this.Text = " New Accountant";
                        break;
                    case "Pharmacist":
                        this.Text = " New Pharmacist";
                        break;
                    default:
                        this.Text = " New User";
                        break;
                }
               btnSave.Text = "Save";
            }
        }
        private void dlUser_Load(object sender, EventArgs e)
        {
           
            switch (ut)
            {
                case 1:
                    cbUsertype.SelectedIndex = 1;
                    break;
                case 2:
                    cbUsertype.SelectedIndex = 2;
                    break;
                case 3:
                    cbUsertype.SelectedIndex = 3;
                    break;
                case 4:
                    cbUsertype.SelectedIndex = 4;
                    break;
                case 5:
                    cbUsertype.SelectedIndex = 5;
                    break;
                default:
                    switch (usertype)
                    {
                        case "Doctor":
                            cbUsertype.SelectedIndex = 2;
                            break;
                        case "Nurse":
                            cbUsertype.SelectedIndex = 3;
                            break;
                        case "Accountant":
                            cbUsertype.SelectedIndex = 4;
                            break;
                        case "Pharmacist":
                            cbUsertype.SelectedIndex = 5;
                            break;
                        default:
                            cbUsertype.Text = "Select...";
                            break;
                    }
                    break;
            }
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
                    ut = Convert.ToInt32(dr["UsertypeID"]);
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
        private void UserRecord(int id)
        {
            SqlDataReader dr;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", id);
                cmd.Parameters.AddWithValue("@actiontype", "FetchRecord");
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtUsername.Text = dr["Username"].ToString();
                    txtPassword.Text = dr["Password"].ToString();
                    txtConfirmPass.Text = dr["Password"].ToString();
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabUser.SelectedTab = tabPage2;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabUser.SelectedTab = tabPage1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUser();
            SaveAddress();
            SaveInfo();
        }
        private void SaveInfo()
        {
            int uID = UserChecker();
            int aID = AddressChecker();
            if (dialresult.SaveData(this) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID ", uID);
                cmd.Parameters.AddWithValue("@LastName ", txtLastname.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Status", cbStatus.SelectedItem);
                cmd.Parameters.AddWithValue("@Birthdate", txtBirthdate.Text);
                cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@AddressID", aID);
                cmd.Parameters.AddWithValue("@UsertypeID", cbUsertype.SelectedIndex);
                cmd.Parameters.AddWithValue("@InfoID", id);
                cmd.Parameters.AddWithValue("@actiontype", "SaveData");
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                MessageBox.Show("Sucess Operation", "Sucess Operation");
                resetInput();
                this.Close();
                RealTimeUpdate.Update();
            }
        }
        private void SaveAddress()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spAddress", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Street_Address ", txtStreet.Text);
            cmd.Parameters.AddWithValue("@Municipality", txtMunicipality.Text);
            cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
            cmd.Parameters.AddWithValue("@ZipCode", txtZipCode.Text);
            cmd.Parameters.AddWithValue("@AddressID", AddressID);
            cmd.Parameters.AddWithValue("@actiontype", "SaveData");
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        private int AddressChecker()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spAddress", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Street_Address ", txtStreet.Text);
            cmd.Parameters.AddWithValue("@Municipality", txtMunicipality.Text);
            cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
            cmd.Parameters.AddWithValue("@ZipCode", txtZipCode.Text);
            cmd.Parameters.AddWithValue("@actiontype", "AddressChecker");
            int AddressID = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return AddressID;
        }
        private void SaveUser()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username ", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@actiontype", "SaveData");
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        private int UserChecker()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username ", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@actiontype", "UserChecker");
            int userID = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return userID;
        }
        private void resetInput()
        {
            txtLastname.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cbStatus.SelectedIndex = 0;
            txtBirthdate.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtStreet.Text = string.Empty;
            txtMunicipality.Text = string.Empty;
            txtProvince.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            cbUsertype.SelectedIndex = 0;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPass.Text = string.Empty;
        }
    }
}
