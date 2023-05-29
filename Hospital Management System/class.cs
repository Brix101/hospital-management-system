using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
   
    class Method
    {
        public static void lvbtn(ListView x, Button btnUpdate, Button btnDelete)
        {
            int item = Convert.ToInt32(x.SelectedItems.Count);
            if (item == 0)
            {
                btn(btnUpdate, false);
                btn(btnDelete, false);
            }
            else if (item == 1)
            {
                btn(btnUpdate, true);
                btn(btnDelete, true);
            }
            else
            {
                btn(btnUpdate, false);
            }
        }
        public static void btn(Button x, Boolean y)
        {
            if (y == false)
            {
                x.Enabled = false;
                x.ForeColor = Color.FromArgb(192, 192, 255);
                x.BackColor = Color.FromArgb(192, 192, 255);
            }
            else
            {
                x.Enabled = true;
                x.ForeColor = Color.Black;
                x.BackColor = Color.FromArgb(136, 147, 165);
            }
        }
    }
    class DeleteFile
    {
        static SqlConnection con = Database.db_connect();

        public static void User(int infoID, int UserID, int AddressID)
        {
            DeleteInfo(infoID);
            DeleteUser(UserID);
            DeleteAddress(AddressID);
        }
        public static void Patient(int id, int AddressID)
        {
            DeletePatient(id);
            DeleteAddress(AddressID);
        }
        static void DeletePatient(int id)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "DeleteData");
                cmd.Parameters.AddWithValue("@PatientID", id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        static void DeleteInfo(int InfoID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "DeleteData");
                cmd.Parameters.AddWithValue("@InfoID", InfoID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        static void DeleteUser(int userID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "DeleteData");
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        static void DeleteAddress(int AddressID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spAddress", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "DeleteData");
                cmd.Parameters.AddWithValue("@AddressID", AddressID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }


    }
    class dialresult
    {
        

        public static DialogResult SaveData(Form x)
        {
            DialogResult result = MessageBox.Show("Are you sure to" + x.Text, "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result;
        }

        public static DialogResult DeleteData()
        {
            using (dlConAd dlConAd = new dlConAd())
            {
                dlConAd.ShowDialog();
            }
            DialogResult result = dlConAd.res;
            return result;
        }

        
    }
}
