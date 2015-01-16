using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace ITClaims
{
    class ConnectDB
    {
        //public SqlConnection myConn = new SqlConnection("Server=166.168.169.7;Database=Base;Integrated Security=true;");
        public SqlConnection myConn = new SqlConnection("Server=166.168.169.7;Database=Base;User ID=Name;Password=pass;");

        public DataTable SelectData(string str)
        {
            DataTable dt = new DataTable();
            try
            {
                if (myConn.State == ConnectionState.Open)
                    myConn.Close();
                
              //  ConfigurationManager.AppSettings["ConnectDB"].ToString();
                
                myConn.Open();
                SqlDataAdapter sd = new SqlDataAdapter(str, myConn);
                sd.Fill(dt);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                    myConn.Close();

            }
            return dt;
        }

        public bool InsertDB(string str)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand(str, myConn);

                if (myConn.State == ConnectionState.Open)
                    myConn.Close();

                myConn.Open();
                myCommand.ExecuteScalar();
                return true;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                    myConn.Close();
            }
        }
    }
}
