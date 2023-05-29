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
    public partial class frmAdmin_Pharmacist : Form
    {
        SqlConnection con = Database.db_connect();
        int id;
        int x = RealTimeUpdate.x();
        public frmAdmin_Pharmacist()
        {
            InitializeComponent();
            LoadData(txtSearch.Text);
            RealTimeUpdate.Timer(AutoUpdate);
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
            int user = Convert.ToInt32(this.Text);
            lvUser.Items.Clear();
            SqlDataReader dr;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "FetchUsertype");
                cmd.Parameters.AddWithValue("@UserTypeID", user);
                cmd.Parameters.AddWithValue("@Search", search);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["LastName"].ToString());
                    item.SubItems.Add(dr["FirstName"].ToString());
                    item.SubItems.Add(dr["MiddleName"].ToString());
                    item.SubItems.Add(dr["Email"].ToString());
                    item.SubItems.Add(dr["Status"].ToString());
                    item.SubItems.Add(dr["Birthdate"].ToString());
                    item.SubItems.Add(dr["ContactNo"].ToString());
                    item.SubItems.Add(dr["Street_Address"].ToString());
                    item.SubItems.Add(dr["Municipality"].ToString());
                    item.SubItems.Add(dr["Province"].ToString());
                    item.SubItems.Add(dr["Zip_Code"].ToString());
                    item.SubItems.Add(dr["InfoID"].ToString());
                    item.SubItems.Add(dr["UserID"].ToString());
                    item.SubItems.Add(dr["AddressID"].ToString());
                    lvUser.Items.Add(item);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (dlUser dl = new dlUser(0, 0, 0, "Pharmacist"))
            {
                dl.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int infoid = Int32.Parse(lvUser.SelectedItems[0].SubItems[11].Text);
                int userid = Int32.Parse(lvUser.SelectedItems[0].SubItems[12].Text);
                int addressid = Int32.Parse(lvUser.SelectedItems[0].SubItems[13].Text);
                using (dlUser dl = new dlUser(infoid, userid, addressid, "Pharmacist"))
                {
                    dl.ShowDialog();
                }
            }
            catch
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dialresult.DeleteData() == DialogResult.Yes)
            {
                RealTimeUpdate.Update();
                foreach (ListViewItem itemRow in lvUser.SelectedItems)
                {
                    lvUser.Items.Remove(itemRow);
                    int infoid = Convert.ToInt32(itemRow.SubItems[11].Text);
                    int userid = Convert.ToInt32(itemRow.SubItems[12].Text);
                    int addressid = Convert.ToInt32(itemRow.SubItems[13].Text);
                    DeleteFile.User(infoid, userid, addressid);
                }
            }
        }

        private void btnShowMedicine_Click(object sender, EventArgs e)
        {
            frmAdmin_Pharmacy.showMedicine();
        }

        private void lvUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            Method.lvbtn(lvUser, btnUpdate, btnDelete);
        }

        private void frmAdmin_Pharmacist_VisibleChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
            Method.lvbtn(lvUser, btnUpdate, btnDelete);
        }
    }
}
