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
    public partial class dlAdmitted : Form
    {
        SqlConnection con = Database.db_connect();
        int _id;
        string plastname,pfirstname,pmiddlename;


        public dlAdmitted(int id = 0)
        {
            InitializeComponent();
            PatientRecord(_id = id);
            LoadFloorNo(cbFloorNo.Text);
            LoadDoctor(cbDoctor.Text);
        }
        private void PatientRecord(int id)
        {
            SqlDataReader dr;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spPatient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientID", id);
                cmd.Parameters.AddWithValue("@actiontype", "FetchRecord");
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtLastname.Text = dr["LastName"].ToString()+", "+ dr["FirstName"].ToString()+" "+ dr["MiddleName"].ToString();
                    plastname = dr["LastName"].ToString();
                    pfirstname = dr["FirstName"].ToString();
                    pmiddlename = dr["MiddleName"].ToString();
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

        public void LoadFloorNo(String search = "")
        {
            cbFloorNo.Items.Clear();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spFloorNo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "FetchData");
                cmd.Parameters.AddWithValue("@Search", search);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cbFloorNo.Items.Add(dr["FloorNo"].ToString());
                }

                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadRoomNo(String x = "")
        {
            cbRoomNo.Items.Clear();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spRoom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "SelectRoom");
                cmd.Parameters.AddWithValue("@FloorNo", x);
                cmd.Parameters.AddWithValue("@Availability", "Available");
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cbRoomNo.Items.Add(dr["RoomNo"].ToString());
                }

                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadDoctor(String x = "")
        {
            cbDoctor.Items.Clear();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actiontype", "FetchUsertype");
                cmd.Parameters.AddWithValue("@UserTypeID", 2);
                cmd.Parameters.AddWithValue("@Search", x);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cbDoctor.Items.Add(dr["LastName"].ToString()  + ", " + dr["FirstName"].ToString() + " " + dr["MiddleName"].ToString());
                }

                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnAdmitted_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            int roomId = RoomChecker();
            int pId = patientChecker();
            int dId = FetchDoctor(cbDoctor.Text);
            if (dialresult.SaveData(this) == DialogResult.Yes)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spAdmit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientID ", pId);
                cmd.Parameters.AddWithValue("@RoomID", roomId);
                cmd.Parameters.AddWithValue("@Status", "Admitted");
                cmd.Parameters.AddWithValue("@DateTimeIn", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@DoctorID", dId);
                cmd.Parameters.AddWithValue("@Diagnosis", txtDiagnosis.Text);
                cmd.Parameters.AddWithValue("@AdmitID", 0);
                cmd.Parameters.AddWithValue("@actiontype", "SaveData");
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

                this.Close();
                MessageBox.Show("Sucess Operation", "Sucess Operation");
                RealTimeUpdate.Update();
                RoomUpdate(RoomChecker());
            }
            
        }
        private void RoomUpdate(int id)
        {
                con.Open();
                SqlCommand cmd = new SqlCommand("spRoom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Availability", "Unavailable");
                cmd.Parameters.AddWithValue("@RoomID", id);
                cmd.Parameters.AddWithValue("@actiontype", "Unavailable");
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
        }
        private int patientChecker()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spPatient", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Lastname ", plastname);
            cmd.Parameters.AddWithValue("@FirstName ", pfirstname);
            cmd.Parameters.AddWithValue("@MiddleName", pmiddlename);
            cmd.Parameters.AddWithValue("@actiontype", "PatientChecker");
            int ID = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return ID;
        }

        private int RoomChecker()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spRoom", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoomNo ", cbRoomNo.Text);
            cmd.Parameters.AddWithValue("@FloorNo", cbFloorNo.Text);
            cmd.Parameters.AddWithValue("@actiontype", "RoomChecker");
            int RoomID = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return RoomID;
        }

        private void dlAdmitted_Load(object sender, EventArgs e)
        {
            cbFloorNo.Text = "Select...";
            cbRoomNo.Text = "Select...";
            cbDoctor.Text = "Select...";
        }

        private int FetchDoctor(string x = "")
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@actiontype", "FetchDoctor");
            cmd.Parameters.AddWithValue("@UserTypeID", 2);
            cmd.Parameters.AddWithValue("@Search", x);
            int Id = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return Id;
        }

        private void cbFloorNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoomNo(cbFloorNo.Text);
            if (cbFloorNo.Text == "")
            {
                cbRoomNo.Enabled = false;
            }
            else
            {
                cbRoomNo.Enabled = true;
            }
        }
    }
}
