using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.BackEnd
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendData(object sender, EventArgs e)
        {
            string editorContent = Request.Unvalidated.Form["editor1"];
            editorContent = HttpUtility.HtmlEncode(editorContent);
            string plainText = Regex.Replace(editorContent, "<.*?>", ""); // 移除標籤
            plainText = HttpUtility.HtmlDecode(plainText); // 轉換 HTML Entities
            string query = @"INSERT INTO News (Title, NewsContent) VALUES (@title,@content)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"title", NewsTitle.Text);
                cmd.Parameters.AddWithValue(@"content", plainText);
                cmd.ExecuteNonQuery();
            }


        }


    }
}