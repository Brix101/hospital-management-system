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
    public partial class dlMedicine : Form
    {
        SqlConnection con = Database.db_connect();
        int _id;

        public dlMedicine(int id = 0)
        {
            InitializeComponent();
            fetchRecord(_id = id);
            if (_id > 0)
            {
                btnSave.Text = "Update";
                this.Text = " Update Medicine";
            }
            else
            {
                this.Text = " New Medicine";
                btnSave.Text = "Save";
            }
        }

        private void dlMedicine_Load(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            //if (btnSave.Text == "Update")
            //{
            //    SaveData();
            //}
            //else if (RoomChecker() == 0)
            //{
            //    SaveData();
            //}
            //else
            //{
            //    MessageBox.Show("Room Already Regestered", "Error");
            //}
        }

        private void fetchRecord(int id)
        {
            SqlDataReader dr;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spMedicine", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MedicineID", id);
                cmd.Parameters.AddWithValue("@actiontype", "FetchRecord");
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtName.Text = dr["Name"].ToString();
                    txtPrice.Text = dr["Price"].ToString();
                    txtQuantity.Text = dr["Quantity"].ToString();
                    txtUnit.Text = dr["Unit"].ToString();
                    calExpDate.Text = dr["ExpDate"].ToString();
                    txtDescription.Text = dr["Description"].ToString();

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
        private void SaveData()
        {
            if (dialresult.SaveData(this) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spMedicine", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name ", txtName.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@Unit", txtUnit.Text);
                cmd.Parameters.AddWithValue("@ExpDate",calExpDate.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@MedicineID", _id);
                cmd.Parameters.AddWithValue("@actiontype", "SaveData");
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                MessageBox.Show("Sucess Operation", "Sucess Operation");
                resetInput();
                this.Close();
                RealTimeUpdate.Update();
            }
            else if (dialresult.SaveData(this) == DialogResult.No)
            {
                MessageBox.Show("Canceling Operation");
            }
        }
        private void resetInput()
        {
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtUnit.Text = string.Empty;
            calExpDate.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
    }
}
