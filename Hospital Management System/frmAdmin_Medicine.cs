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
    public partial class frmAdmin_Medicine : Form
    {
        SqlConnection con = Database.db_connect();
        int id;
        int x = RealTimeUpdate.x();

        public frmAdmin_Medicine()
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
            lvMedicine.Items.Clear();
            SqlDataReader dr;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spMedicine", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "FetchData");
                cmd.Parameters.AddWithValue("@Search", search);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["Name"].ToString());
                    item.SubItems.Add(dr["Price"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    item.SubItems.Add(dr["Unit"].ToString());
                    item.SubItems.Add(dr["ExpDate"].ToString());
                    item.SubItems.Add(dr["Description"].ToString());
                    item.SubItems.Add(dr["MedicineID"].ToString());
                    lvMedicine.Items.Add(item);
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
        private void btnShowPharmacist_Click(object sender, EventArgs e)
        {
            frmAdmin_Pharmacy.showPharmacist();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (dlMedicine dlMedicine = new dlMedicine())
            {
                dlMedicine.ShowDialog();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                id = Int32.Parse(lvMedicine.SelectedItems[0].SubItems[6].Text);
                using (dlMedicine dlMedicine = new dlMedicine(id))
                {
                    dlMedicine.ShowDialog();
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
                foreach (ListViewItem itemRow in lvMedicine.SelectedItems)
                {
                    lvMedicine.Items.Remove(itemRow);
                    int ID = Convert.ToInt32(itemRow.SubItems[6].Text);
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("spMedicine", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@actiontype", "DeleteData");
                        cmd.Parameters.AddWithValue("@MedicineID", ID);
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

        private void lvMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            Method.lvbtn(lvMedicine, btnUpdate, btnDelete);
        }

        private void frmAdmin_Medicine_VisibleChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
            Method.lvbtn(lvMedicine, btnUpdate, btnDelete);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }
    }
}
