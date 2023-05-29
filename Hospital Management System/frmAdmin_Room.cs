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
    public partial class frmAdmin_Room : Form
    {
        SqlConnection con = Database.db_connect();
        int id;
        int x = RealTimeUpdate.x();
        public frmAdmin_Room()
        {
            InitializeComponent();
            LoadData(txtSearch.Text);
            RealTimeUpdate.Timer(AutoUpdate);
        }
        public void AutoUpdate(object sender, EventArgs e)
        {
            if (RealTimeUpdate.result() == x){
                LoadData(txtSearch.Text);
                x = RealTimeUpdate.result() + 1;
            }
        }

        public void LoadData(String search = "")
        {
            lvRoom.Items.Clear();
            SqlDataReader dr;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spRoom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "FetchData");
                cmd.Parameters.AddWithValue("@Search", search);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["RoomNo"].ToString());
                    item.SubItems.Add(dr["FloorNo"].ToString());
                    item.SubItems.Add(dr["Availability"].ToString());
                    item.SubItems.Add(dr["Description"].ToString());
                    item.SubItems.Add(dr["RoomID"].ToString());
                    lvRoom.Items.Add(item);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dialresult.DeleteData() == DialogResult.Yes)
            {
                RealTimeUpdate.Update();
                foreach (ListViewItem itemRow in lvRoom.SelectedItems)
                {
                    lvRoom.Items.Remove(itemRow);
                    int ID = Convert.ToInt32(itemRow.SubItems[4].Text);

                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("spRoom", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@actiontype", "DeleteData");
                        cmd.Parameters.AddWithValue("@RoomID", ID);
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
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (dlRoom dlRoom = new dlRoom())
            {
                dlRoom.ShowDialog();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                id = Int32.Parse(lvRoom.SelectedItems[0].SubItems[5].Text);
                using (dlRoom dlRoom = new dlRoom(id))
                {
                    dlRoom.ShowDialog();
                }
            }
            catch
            {

            }
        }


        private void lvRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Method.lvbtn(lvRoom, btnUpdate, btnDelete);
        }

        private void frmAdmin_Room_VisibleChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
            Method.lvbtn(lvRoom, btnUpdate, btnDelete);
        }
    }
}
