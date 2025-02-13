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
                    getFiles();
                    getImgs();
                }
            }
        }

        public void getFiles()
        {
            string query = @"SELECT FileName FROM NewsFiles WHERE NewsId = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["pos"]);

                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows) // 不消耗 reader，只檢查是否有資料
                {
                    fileBox.Visible = false;
                }
                else
                {
                    FileRepeater.DataSource = reader;
                    FileRepeater.DataBind();
                }
            }
        }

        public void getImgs()
        {
            string query = @"SELECT ImagePath FROM NewsImgs WHERE NewsId = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", Request.QueryString["pos"]);
                SqlDataReader reader = cmd.ExecuteReader();
                ImgRepeater.DataSource = reader;
                ImgRepeater.DataBind();
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