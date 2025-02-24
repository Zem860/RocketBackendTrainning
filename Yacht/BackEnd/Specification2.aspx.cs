using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.BackEnd
{
    public partial class Specification2 : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                getDropDown();
                getSpec();
            }
        }
        //public void getSpecType()
        //{
        //    string id = YachtDropDown.SelectedValue;
        //    string query = @"SELECT Id, SpecType, YachtId FROM SpecificationType WHERE yachtId = @id";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand cmd = new SqlCommand(query, connection);
        //        cmd.Parameters.AddWithValue(@"id", id);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        SpecHeadGridView.DataSource = reader;
        //        SpecHeadGridView.DataBind();

        //    }

        //}
        public void getDropDown()
        {
            string query = "SELECT Id, Model FROM YachtsModel";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                YachtDropDown.DataSource = reader;
                YachtDropDown.DataTextField = "Model"; // 顯示文字
                YachtDropDown.DataValueField = "Id";   // 隱藏值
                YachtDropDown.DataBind();
            }
        }

        protected void YachtDropDown_TextChanged(object sender, EventArgs e)
        {
            getSpec();
        }

        public void getSpec()
        {
            string query = "SELECT SpecContent FROM Specification2 WHERE YachtId = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", YachtDropDown.SelectedValue);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Literal1.Text = reader["SpecContent"].ToString();
                } else
                {
                    Literal1.Text = String.Empty;
                }
            }
        }

        protected void sendEdit(object sender, EventArgs e)
        {
            string editorContent = Request.Unvalidated.Form["editor1"];
            string query = "";
            if (String.IsNullOrEmpty(Literal1.Text))
            {
                query = @"INSERT INTO Specification2 (SpecContent, YachtId) VALUES (@spec, @id)";
            } else
            {
                query = "UPDATE Specification2 SET SpecContent = @spec WHERE YachtId = @id";
            }
             
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"spec", editorContent);
                cmd.Parameters.AddWithValue(@"id", YachtDropDown.SelectedValue);
                cmd.ExecuteNonQuery();

            }
            getSpec();
            
        }
    }
}