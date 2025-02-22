using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.BackEnd
{
    public partial class Specification : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(Request.QueryString["yactypeId"]) && String.IsNullOrEmpty(Request.QueryString["specId"]))
                {
                    Response.Redirect("AddYachtSpec.aspx");
                }
                getSpecTitle();
                getSpecs();
            }

        }


        public void getSpecTitle()
        {

            string query = @"SELECT YachtsModel.Model AS Model, SpecificationType.SpecType AS SpecType FROM YachtsModel INNER JOIN SpecificationType ON SpecificationType.YachtId = YachtsModel.Id WHERE SpecificationType.yachtId = @yachtId AND SpecificationType.Id = @id ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"yachtId", Request.QueryString["yactypeId"]);
                cmd.Parameters.AddWithValue(@"id", Request.QueryString["specId"]);
                
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    YachtTitle.Text = reader["Model"].ToString();
                    SpecTitle.Text = reader["SpecType"].ToString();
                }

            }
        }
        public void getSpecs()
        {
            TextBox1.Text = "";
            string query = @"SELECT SpecDetails.Id AS Id, SpecDetails.Detail As SpecDetail FROM SpecDetails INNER JOIN SpecificationType ON SpecificationType.Id = SpecDetails.SpecId WHERE SpecificationType.Id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", Request.QueryString["specId"]);
                SqlDataReader reader = cmd.ExecuteReader();

                SpecGridview.DataSource = reader;
                SpecGridview.DataBind();
            }
        
        }

        protected void SpecGridview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SpecGridview.EditIndex = e.NewEditIndex;
            getSpecs();
        }

        protected void SpecGridview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(SpecGridview.DataKeys[e.RowIndex].Value);
            TextBox txtEditSpecDetail = (TextBox)SpecGridview.Rows[e.RowIndex].FindControl("txtEditSpecDetail");

            string query = "UPDATE SpecDetails SET Detail = @SpecDetail WHERE Id = @Id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SpecDetail", txtEditSpecDetail.Text);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            SpecGridview.EditIndex = -1;
            getSpecs();
        }

        protected void SpecGridview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SpecGridview.EditIndex = -1;
            getSpecs();
        }

        protected void SpecGridview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(SpecGridview.DataKeys[e.RowIndex].Value);

            string query = "DELETE FROM SpecDetails WHERE SpecId = @Id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }

                  getSpecs();

        }

        protected void addSpec(object sender, EventArgs e)
        {
            string query = "INSERT INTO SpecDetails (SpecId, Detail) VALUES (@specId, @detail)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"specId", Request.QueryString["specId"]);
                cmd.Parameters.AddWithValue(@"detail", TextBox1.Text);
                cmd.ExecuteNonQuery();

            }
            getSpecs();
        }

        protected void BacktoSpecTitle(object sender, EventArgs e)
        {
            Response.Redirect("~/BackEnd/AddYachtSpec.aspx");
        }
    }
}