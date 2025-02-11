using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.BackEnd
{
    public partial class EditNews : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected string Id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Id = Request.QueryString["id"];
                showEdit();
            }
        }

        protected void sendEdit(object sender, EventArgs e)
        {
            string editorContent = Request.Unvalidated.Form["editor1"];

            // 修正圖片標籤，使其包含 src
            string pattern = @"<img[^>]*?data-ck-upload-id=""([^""]+)""[^>]*?>";
            editorContent = Regex.Replace(editorContent, pattern, match =>
            {
                string uploadId = match.Groups[1].Value;
                string newSrc = "/NewsImgs/" + uploadId + ".jpg";

                return $"<img src=\"{newSrc}\" />";
            });

            string query = @"
            UPDATE News SET Title = @title, NewsContent = @content WHERE Id = @Id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"Id", Request.QueryString["Id"]);
                cmd.Parameters.AddWithValue("@title", NewsTitle.Text);
                cmd.Parameters.AddWithValue("@content", editorContent);
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("News.aspx");
        }


        public void showEdit()
        {
            string contentFromDb = "";  // 先宣告變數，確保作用域涵蓋整個方法

            if (String.IsNullOrEmpty(Id))
            {
                Response.Redirect("News.aspx");
            }
            string query = @"
                SELECT
News.Id AS Id, 
News.Title AS NewsTitle, 
NewsImgs.ImagePath AS PinUp, -- 取得封面圖
News.NewsContent, 
CONVERT(NVARCHAR, News.CreatedAt, 111) AS CreatedAt
FROM News
INNER JOIN NewsImgs ON NewsImgs.newsId = News.Id
WHERE News.Id =1 AND Cover = 1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"Id", Id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    NewsTitle.Text = reader["NewsTitle"].ToString().Trim();
                    string selectedCover = reader["PinUp"] != DBNull.Value ? reader["PinUp"].ToString() : "";
                    contentFromDb = HttpUtility.HtmlDecode(reader["NewsContent"]?.ToString() ?? "");
                    Literal1.Text = HttpUtility.HtmlDecode(contentFromDb); // 用 Literal 設定 HTML
                    PreviewImage.ImageUrl = reader["PinUp"].ToString();
                    
                }
            }
        }
    }
}