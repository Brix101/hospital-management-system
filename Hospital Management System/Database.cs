using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    class Database
    {

        public static SqlConnection con;
        public static SqlCommand cmd;
        public static DataTable dt;
        public static SqlDataReader sdr;

        public static string strcon = "Data Source=DESKTOP-BRIX101;Initial Catalog=HospitalManagementDB;" +"User ID=Hospital;Password=hospital;";
        public static string StringResult;
        public static int IntResult;
        public static SqlConnection db_connect()
        {
            con = new SqlConnection(strcon);
            return con;
        }

        public static String getStringResult(string query)
        {
            cmd = new SqlCommand(query, con);
            StringResult = cmd.ExecuteScalar().ToString();
            return StringResult;
        }

        public static int getIntResult(string query)
        {
            cmd = new SqlCommand(query, con);
            IntResult = Convert.ToInt32(cmd.ExecuteScalar());
            return IntResult;
        }
        public static DataTable getDataTableResult(string query)
        {
            cmd = new SqlCommand(query, con);
            dt = new DataTable();
            sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            return dt;
        }
        public static void DataCommand(string query)
        {
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }
        public static int IntCommand(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            int output = Convert.ToInt32(cmd.ExecuteScalar());
            return output;
        }
    }

}
