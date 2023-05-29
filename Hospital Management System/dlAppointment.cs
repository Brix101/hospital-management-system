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
    public partial class dlAppointment : Form
    {
        SqlConnection con = Database.db_connect();
        public dlAppointment()
        {
            InitializeComponent();
            LoadPatient(cbPatient.Text);
            LoadDoctor(cbDoctor.Text);
        }

        private void dlAppointment_Load(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0;
            cbStartingDate.SelectedIndex = 0;
            cbEndingDate.SelectedIndex = 0;
        }
        public void LoadPatient(String search = "")
        {
            cbPatient.Items.Clear();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "FetchData");
                cmd.Parameters.AddWithValue("@Search", search);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    cbPatient.Items.Add(dr["LastName"].ToString() +" "+ dr["FirstName"].ToString());
                }
                
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadDoctor(String search = "")
        {
            cbDoctor.Items.Clear();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "FetchUsertype");
                cmd.Parameters.AddWithValue("@UserTypeID", 2);
                cmd.Parameters.AddWithValue("@Search", search);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cbDoctor.Items.Add(dr["LastName"].ToString() + " " + dr["FirstName"].ToString());
                }

                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbPatient_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
