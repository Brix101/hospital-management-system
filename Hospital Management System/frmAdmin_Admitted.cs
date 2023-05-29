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
    public partial class frmAdmin_Admitted : Form
    {
        SqlConnection con = Database.db_connect();
        int id;
        int x = RealTimeUpdate.x();

        public frmAdmin_Admitted()
        {
            InitializeComponent();
            LoadData(txtSearch.Text);
            RealTimeUpdate.Timer(AutoUpdate);
        }

        private void btnShowPatient_Click(object sender, EventArgs e)
        {
            frmAdmin_Patient.showPatient();
        }
        public void AutoUpdate(object sender, EventArgs e)
        {
            if (RealTimeUpdate.result() == x)
            {
                LoadData(txtSearch.Text);
                x = RealTimeUpdate.result() + 1;
            }
        }

        public void LoadData(String search = "")
        {
            lvPatient.Items.Clear();
            SqlDataReader dr;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spAdmit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "FetchData");
                cmd.Parameters.AddWithValue("@Search", search);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["PLastName"].ToString()+", "+ dr["PFirstName"].ToString() + " " + dr["PMiddleName"].ToString());
                    item.SubItems.Add(dr["FloorNo"].ToString());
                    item.SubItems.Add(dr["RoomNo"].ToString());
                    item.SubItems.Add(dr["DLastName"].ToString() + ", " + dr["DFirstName"].ToString() + " " + dr["DMiddleName"].ToString());
                    item.SubItems.Add(dr["Diagnosis"].ToString());
                    item.SubItems.Add(dr["DateTimeIn"].ToString());
                    item.SubItems.Add(dr["AdmittedID"].ToString());
                    lvPatient.Items.Add(item);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void btnDischarged_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itemRow in lvPatient.SelectedItems)
            {
                lvPatient.Items.Remove(itemRow);
                int id = Convert.ToInt32(itemRow.SubItems[6].Text);
                int floorno = Convert.ToInt32(itemRow.SubItems[1].Text);
                int roomno = Convert.ToInt32(itemRow.SubItems[2].Text);

               int roomid=  RoomChecker(floorno, roomno);
                RoomUpdate(roomid);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spAdmit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@actiontype", "DeleteData");
                    cmd.Parameters.AddWithValue("@AdmitID", id);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    RealTimeUpdate.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
           
        }
        private void RoomUpdate(int id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("spRoom", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Availability", "Available");
            cmd.Parameters.AddWithValue("@RoomID", id);
            cmd.Parameters.AddWithValue("@actiontype", "Unavailable");
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        private int RoomChecker(int floorno, int roomno)
        {
           
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spRoom", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoomNo ", floorno);
            cmd.Parameters.AddWithValue("@FloorNo", roomno);
            cmd.Parameters.AddWithValue("@actiontype", "RoomChecker");
            int RoomID = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RoomID;

        }

    }
}
