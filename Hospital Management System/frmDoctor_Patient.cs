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
    public partial class frmDoctor_Patient : Form
    {
        SqlConnection con = Database.db_connect();
        int id;
        int x = RealTimeUpdate.x();
        public frmDoctor_Patient()
        {
            InitializeComponent();
            LoadData(txtSearch.Text);
            RealTimeUpdate.Timer(AutoUpdate);
          
        }

        private void frmDoctor_Patient_Load(object sender, EventArgs e)
        {

        }
        private int DoctorID()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", frmLogin.ConID);
            cmd.Parameters.AddWithValue("@actiontype", "FetchDoctorID");
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return id;
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
            int DoctorId = DoctorID();
            lvPatient.Items.Clear();
            SqlDataReader dr;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spAdmit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "DoctorData");
                cmd.Parameters.AddWithValue("@DoctorID", DoctorId);
                cmd.Parameters.AddWithValue("@Search", search);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem item = new ListViewItem(dr["LastName"].ToString() + ", " + dr["FirstName"].ToString() + " " + dr["MiddleName"].ToString());
                    item.SubItems.Add(dr["FloorNo"].ToString());
                    item.SubItems.Add(dr["RoomNo"].ToString());
                    item.SubItems.Add(dr["Diagnosis"].ToString());
                    item.SubItems.Add(dr["DateTimeIn"].ToString());
                  //  item.SubItems.Add(dr["DoctorID"].ToString());
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

        private void btnDischarged_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void frmDoctor_Patient_VisibleChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }
    }
}
