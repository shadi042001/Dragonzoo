using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Data;

namespace job
{
    public partial class DragonEdit : System.Web.UI.Page
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
        public void FillDropdownlist(DropDownList ddl, string query, string text, string value)
        {
           
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            
            SqlCommand com = new SqlCommand(query, conn); // table name 
            SqlDataAdapter ad = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            ad.Fill(ds);  // fill dataset
            ddl.Items.Clear();
            ddl.DataTextField = ds.Tables[0].Columns[text].ToString();
            ddl.DataValueField = ds.Tables[0].Columns[value].ToString();            
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            FillDropdownlist(DropDownList1, "select * from locations", "location_desc", "location_id");
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
        private void GetDragonData()
        {
            int dragon_id =Convert.ToInt32(Request.QueryString["id"].ToString());
            string strQuery = "SELECT * from Dragons where Dragon_id=@Id";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.AddWithValue("@Id", dragon_id);
            DataTable dt = GetData(cmd);
            txt_Name.Text = dt.Rows[0]["Dragon_name"].ToString();
  
            ddl_Colors.SelectedValue= dt.Rows[0]["Dragon_color"].ToString();
            DropDownList1.SelectedValue= dt.Rows[0]["Location_id"].ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int dragon_id = Convert.ToInt32(Request.QueryString["id"].ToString());
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "Update Dragons set Dragon_name=@Dragon_Name, Dragon_color= @Dragon_color,Dragon_Location=@Dragon_Location where Dragon_id=@id";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@id", dragon_id);
                    cmd.Parameters.AddWithValue("@Dragon_Name", txt_Name.Text);
                    cmd.Parameters.AddWithValue("@Dragon_color", ddl_Colors.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Dragon_Location", DropDownList1.SelectedItem.Value);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}