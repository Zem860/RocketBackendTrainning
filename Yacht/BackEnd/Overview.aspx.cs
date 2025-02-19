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

    public partial class Overview : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDropDown();
                getOverviewText();
            }
        }


        public void getDropDown()
        {
            string query = @"SELECT Id, Model FROM YachtsModel";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                YachtModel.DataSource = reader;
                YachtModel.DataTextField = "Model";  // 設定 Model 為顯示的名稱
                YachtModel.DataValueField = "Id";    // 設定 Id 為選擇的值
                YachtModel.DataBind();
            }
        }

        public void addOverviewText()
        {
            string editorContent = Request.Unvalidated.Form["editor1"];
            string query = @"UPDATE OverviewText SET Text = @text WHERE YachtId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", editorContent);
                cmd.ExecuteNonQuery();
            }
        }
        public void getOverviewText()
        {

            string query = @"SELECT Text FROM OverviewText WHERE YachtId = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", YachtModel.SelectedValue);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string contentFromDb = HttpUtility.HtmlDecode(reader["Text"]?.ToString() ?? "");
                    Literal1.Text = HttpUtility.HtmlDecode(contentFromDb); // 用 Literal 設定 HTML
                } else
                {
                    Literal1.Text = "";
                }
             

            }
        }

        protected void YachtModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            getOverviewText();
        }

        protected void addOverviewText(object sender, EventArgs e)
        {
            string editorContent = Request.Unvalidated.Form["editor1"];
            string query = @"
        IF EXISTS (SELECT 1 FROM OverviewText WHERE YachtId = @id)
            UPDATE OverviewText SET Text = @text WHERE YachtId = @id
        ELSE
            INSERT INTO OverviewText (YachtId, Text) VALUES (@id, @text)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", YachtModel.SelectedValue);
                cmd.Parameters.AddWithValue(@"text", editorContent);
                cmd.ExecuteNonQuery();
            }
        }
    }

}