using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.FrontEnd
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(Request.QueryString["pos"]))
                {
                    Response.Redirect("News.aspx");
                } else
                {
                    getNews();
                }
            }
        }

        public void getNews()
        {
            string query = @"SELECT Title, NewsContent FROM News WHERE Id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", Request.QueryString["pos"]);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string newsContent = HttpUtility.HtmlDecode(reader["NewsContent"].ToString());
                    

                    // 🔥 刪除開頭 & 結尾的多餘空白
                    //newsContent = Regex.Replace(newsContent, @"<\/?p[^>]*>", "", RegexOptions.IgnoreCase);
                    //newsContent = newsContent.Trim();
                    NewsTitle.Text = reader["Title"].ToString();
                    News.Text = $"<div class='news-content'>{newsContent}</div>";


                }
            }
        }
    }
}