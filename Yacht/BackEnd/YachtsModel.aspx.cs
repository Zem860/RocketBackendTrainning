using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.BackEnd
{
    public partial class YachtsModel : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // 確保只有首次載入時執行
            {
                getModel();
            }
        }


        public void getModel()
        {
            string query = @"SELECT Id, Model FROM YachtsModel";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                YachtsGridView.DataSource = reader;
                YachtsGridView.DataBind();
            }
        }

        protected void YachtsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            YachtsGridView.EditIndex = e.NewEditIndex;
            getModel();
        }

        protected void YachtsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            YachtsGridView.EditIndex = -1;
            getModel();
        }

        protected void YachtsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(YachtsGridView.DataKeys[e.RowIndex].Value);
            TextBox modelname = (TextBox)YachtsGridView.Rows[e.RowIndex].FindControl("ModelText");
            string query = @"UPDATE YachtsModel SET Model = @model WHERE Id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"model", modelname.Text);
                cmd.Parameters.AddWithValue(@"id", id);
                cmd.ExecuteNonQuery();
                YachtsGridView.EditIndex = -1;
                getModel();
            }
        }

        protected void YachtsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(YachtsGridView.DataKeys[e.RowIndex].Value);
            string query = @"DELETE FROM YachtsModel WHERE Id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", id);
                cmd.ExecuteNonQuery();
            }
            getModel();
        }
    }
}