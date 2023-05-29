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

    class RealTimeUpdate
    {
        public static Timer timer1;
        public static SqlConnection con = Database.db_connect();
        public static int result2 = x();
        public static void Timer(EventHandler e)
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(e);
            timer1.Interval = 10; // in miliseconds
            timer1.Start();
        }
        public static int result()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@actiontype", "CountData");
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            con.Close();
            return result;
        }
        public static int x(){

            if (result() == result2)
            {

                return result() + 1;

            }
            else
            {
                return result();
            }
        }

        public static void Update()
        {
            result();
            SaveData();
        }
        public static void SaveData()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("spUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Value ", "");
            cmd.Parameters.AddWithValue("@actiontype", "SaveData");
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
}
