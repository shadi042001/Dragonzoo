using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.IO;

namespace job
{
    public partial class LocationEdit : System.Web.UI.Page
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        private DataTable GetData(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }
        private void GetLocationData()
        {
            int Location_id = Convert.ToInt32(Request.QueryString["id"].ToString());
            string strQuery = "SELECT * from Locations where Location_id=@Id";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.AddWithValue("@Id", Location_id);
            DataTable dt = GetData(cmd);
            txt_Name.Text = dt.Rows[0]["Location_desc"].ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int Location_id = Convert.ToInt32(Request.QueryString["id"].ToString());
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "Update Locations set Location_name=@Location_name where Location_id=@id";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@id", Location_id);
                    cmd.Parameters.AddWithValue("@Location_name", txt_Name.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("location.aspx");
        }
    }
}