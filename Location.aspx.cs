﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace job
{
    public partial class Location : System.Web.UI.Page
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strQuery = "SELECT * FROM Locations";
            SqlCommand cmd = new SqlCommand(strQuery);
            DataTable dt = GetData(cmd);
            gvLocations.DataSource = dt;
            gvLocations.DataBind();
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
        private void delete(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connStr);
            int id = int.Parse((sender as LinkButton).CommandArgument);
            string strQuery = "delete FROM Locations WHERE Location_id = @Id";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            // FillGrid();
            Response.Redirect("Location.aspx");


        }
        private void edit(object sender, EventArgs e)
        {

            int id = int.Parse((sender as LinkButton).CommandArgument);
            Response.Redirect("LocationEdit.aspx?id=" + id);


        }
    }
}