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
    public partial class frmAdmin_PatientView : Form
    {
        SqlConnection con = Database.db_connect();
        int id;
        int x = RealTimeUpdate.x();
        public frmAdmin_PatientView()
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
            lvPatient.Items.Clear();
            SqlDataReader dr;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "FetchData");
                cmd.Parameters.AddWithValue("@Search", search);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["LastName"].ToString());
                    item.SubItems.Add(dr["FirstName"].ToString());
                    item.SubItems.Add(dr["MiddleName"].ToString());
                    item.SubItems.Add(dr["Gender"].ToString());
                    item.SubItems.Add(dr["Birthdate"].ToString());
                    item.SubItems.Add(dr["Email"].ToString());
                    item.SubItems.Add(dr["ContactNo"].ToString());
                    item.SubItems.Add(dr["Street_Address"].ToString());
                    item.SubItems.Add(dr["Municipality"].ToString());
                    item.SubItems.Add(dr["Province"].ToString());
                    item.SubItems.Add(dr["Zip_Code"].ToString());
                    item.SubItems.Add(dr["PatientID"].ToString());
                    item.SubItems.Add(dr["AddressID"].ToString());
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


        private void btnShowAppointment_Click(object sender, EventArgs e)
        {
            frmAdmin_Patient.showAppointment();
        }

        private void lvRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Method.lvbtn(lvPatient, btnUpdate, btnDelete);
            Method.lvbtn(lvPatient, btnAdmit,btnDelete);
        }

        private void lvPatient_VisibleChanged(object sender, EventArgs e)
        {
            Method.lvbtn(lvPatient, btnUpdate, btnDelete);
            Method.lvbtn(lvPatient, btnAdmit, btnDelete);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (dlPatient dl = new dlPatient())
            {
                dl.ShowDialog();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(lvPatient.SelectedItems[0].SubItems[11].Text);
                int Aid = Int32.Parse(lvPatient.SelectedItems[0].SubItems[12].Text);
                using (dlPatient dl = new dlPatient(id, Aid))
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
                foreach (ListViewItem itemRow in lvPatient.SelectedItems)
                {
                    lvPatient.Items.Remove(itemRow);
                    int id = Convert.ToInt32(itemRow.SubItems[11].Text);
                    int Aid = Convert.ToInt32(itemRow.SubItems[12].Text);
                    DeleteFile.Patient(id, Aid);
                }
            }
        }

        private void btnAdmit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(lvPatient.SelectedItems[0].SubItems[11].Text);
                using (dlAdmitted dl = new dlAdmitted(id))
                {
                    dl.ShowDialog();
                }
            }
            catch
            {

            }
        }
    }
}
