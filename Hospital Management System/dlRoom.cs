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
    public partial class dlRoom : Form
    {
        SqlConnection con = Database.db_connect();
        int _id;
        string av;
        public dlRoom(int id = 0)
        {
            InitializeComponent();
            fetchRecord(_id = id);
            if (_id > 0)
            {
                btnSave.Text = "Update";
                this.Text = " Update Room";
            }
            else
            {
                this.Text = " New Room";
                btnSave.Text = "Save";
            }
        }
        private void dlRoom_Load(object sender, EventArgs e)
        {
            cbAvailability.Text = "Select...";
            switch (av) 
            {
                case "Available":
                    cbAvailability.Text = "Available";
                   break;
                case "Unavailable":
                    cbAvailability.Text = "Unavailable";
                    break;
                default:
                    break;

            }

        }
        private void resetInput()
        {
            txtRoomNo.Text = string.Empty;
            txtFloorNo.Text = string.Empty;
            cbAvailability.SelectedIndex = 0;
            txtDescription.Text = string.Empty;
        }

        private void fetchRecord(int id)
        {
            SqlDataReader dr;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spRoom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoomID", id);
                cmd.Parameters.AddWithValue("@actiontype", "FetchRecord");
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtRoomNo.Text = dr["RoomNo"].ToString();
                    txtFloorNo.Text = dr["FloorNo"].ToString();
                    av = dr["Availability"].ToString();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Update")
            {
                SaveData();
            }else if (RoomChecker() == 0)
            {
                if (FloorChecker() == 0)
                {
                    Savefloor();
                }
                SaveData();
            }
            else
            {
                MessageBox.Show("Room Already Regestered", "Error");
            }

            
        }

        private int RoomChecker()
        {
            if(con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spRoom", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoomNo ", txtRoomNo.Text);
            cmd.Parameters.AddWithValue("@FloorNo", txtFloorNo.Text);
            cmd.Parameters.AddWithValue("@actiontype", "RoomChecker");
            int RoomID = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RoomID;
        }
        private void SaveData()
        {
            if (dialresult.SaveData(this) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spRoom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoomNo ", txtRoomNo.Text);
                cmd.Parameters.AddWithValue("@FloorNo", txtFloorNo.Text);
                cmd.Parameters.AddWithValue("@Availability", cbAvailability.SelectedItem);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@RoomID", _id);
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
        private int FloorChecker()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spFloorNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FloorNo", txtFloorNo.Text);
            cmd.Parameters.AddWithValue("@actiontype", "FloorChecker");
            int FloorID = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return FloorID;
        }
        private void Savefloor()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spFloorNo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FloorNo", txtFloorNo.Text);
            cmd.Parameters.AddWithValue("@actiontype", "SaveData");
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        private void txtRoomNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                System.Media.SystemSounds.Exclamation.Play();
            }
            if((e.KeyChar=='.')&&((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtFloorNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                System.Media.SystemSounds.Exclamation.Play();
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
