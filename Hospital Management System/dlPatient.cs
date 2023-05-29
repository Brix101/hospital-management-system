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
    public partial class dlPatient : Form
    {
        SqlConnection con = Database.db_connect();
        int _id;
        int AddressID;
        string Gender;
        public dlPatient(int id = 0, int Aid = 0)
        {
            InitializeComponent();
            PatientRecord(_id = id);
            AddressRecord(AddressID = Aid);
            if (_id > 0)
            {
                btnSave.Text = "Update";
                this.Text = " Update Patient";
            }
            else
            {
                this.Text = " New Patient";
                btnSave.Text = "Save";
            }
        }
        private void dlPatient_Load(object sender, EventArgs e)
        {
            switch (Gender)
            {
                case "Male":
                    cbGender.Text = "Male";
                    break;
                case "Female":
                    cbGender.Text = "Female";
                    break;
                default:
                    cbGender.Text = "Select...";
                    break;
            }
        }
        private void PatientRecord(int id)
        {
            SqlDataReader dr;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientID", id);
                cmd.Parameters.AddWithValue("@actiontype", "FetchRecord");
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtLastname.Text = dr["LastName"].ToString();
                    txtFirstName.Text = dr["FirstName"].ToString();
                    txtMiddleName.Text = dr["MiddleName"].ToString();
                    Gender = dr["Gender"].ToString();
                    txtBirthdate.Text = dr["Birthdate"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                    txtContactNo.Text = dr["ContactNo"].ToString();
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


        private void SavePatient()
        {
            int aID = AddressChecker();
            if (dialresult.SaveData(this) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LastName ", txtLastname.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                cmd.Parameters.AddWithValue("@Gender", cbGender.SelectedItem);
                cmd.Parameters.AddWithValue("@Birthdate", txtBirthdate.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
                cmd.Parameters.AddWithValue("@AddressID", aID);
                cmd.Parameters.AddWithValue("@PatientID", _id);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAddress();
            SavePatient();
        }
        private void resetInput()
        {
            txtLastname.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cbGender.SelectedIndex = 0;
            txtBirthdate.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtStreet.Text = string.Empty;
            txtMunicipality.Text = string.Empty;
            txtProvince.Text = string.Empty;
            txtZipCode.Text = string.Empty;
        }

       
    }
}
