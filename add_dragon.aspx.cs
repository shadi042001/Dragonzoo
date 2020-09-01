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
    public partial class add_dragon : System.Web.UI.Page
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
        public void FillDropdownlist(DropDownList ddl, string query, string text, string value)
        {
            // FillDropdownlist(DropDownList1, "select * from departments", "department_Name_Ar", "department_id");
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            //string q = "select * from Departments";
            SqlCommand com = new SqlCommand(query, conn); // table name 
            SqlDataAdapter ad = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            ad.Fill(ds);  // fill dataset
            ddl.Items.Clear();
            ddl.DataTextField = ds.Tables[0].Columns[text].ToString();
            ddl.DataValueField = ds.Tables[0].Columns[value].ToString();
            //  SqlCommand cmd2 = new SqlCommand(q, conn);

            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            FillDropdownlist(DropDownList1, "select * from locations", "location_desc", "location_id");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "insert into Dragons values (@Dragon_Name, @Dragon_color, @Dragon_Location);";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
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