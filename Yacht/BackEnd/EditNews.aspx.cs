using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
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


        public string HandleCkImgs(int id, string editorContent)
        {
            string localPathHeading = Server.MapPath("~/Test/");

            // 確保 /Test/ 資料夾存在
            if (!Directory.Exists(localPathHeading))
            {
                Directory.CreateDirectory(localPathHeading);
            }

            // 取得所有圖片的原始 URL（未被修改的 `src`）
            string imgPattern = @"<img\s+[^>]*?src=['""](https?:\/\/[^'""]+)['""][^>]*?>";
            MatchCollection matches = Regex.Matches(editorContent, imgPattern);

            if (matches.Count == 0)
            {
                return editorContent; // 沒有圖片則直接返回原內容
            }
            string query = @"UPDATE NewsContentImgs SET ImagePath = @img WHERE NewsId = @id";
            //string query = @"INSERT INTO NewsImgs (NewsId, ImagePath, Cover) VALUES (@id, @img, @cover)";
            int count = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                foreach (Match match in matches)
                {
                    string imageUrl = match.Groups[1].Value; // 原始圖片網址
                    string imgName = Path.GetFileName(new Uri(imageUrl).LocalPath); // 取得圖片名稱
                    string localPath = Path.Combine(localPathHeading, imgName); // 儲存圖片的路徑
                    string imgMappingPath = "/Test/" + imgName; // 新的本地 URL

                    try
                    {
                        // 下載圖片
                        using (var client = new System.Net.WebClient())
                        {
                            client.DownloadFile(imageUrl, localPath);
                        }

                        // **儲存圖片資訊到資料庫**
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue(@"id", id);
                        cmd.Parameters.AddWithValue(@"img", imgMappingPath);

                        cmd.ExecuteNonQuery();
                        count++;

                        // **更新 `editorContent`，替換 `src`**
                        editorContent = editorContent.Replace(imageUrl, imgMappingPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"圖片下載失敗: {imageUrl}, 錯誤: {ex.Message}");
                    }
                }
            }

            return editorContent; // **回傳更新後的內容**
        }

        protected void sendEdit(object sender, EventArgs e)
        {
            string editorContent = Request.Unvalidated.Form["editor1"];

            editorContent = HandleCkImgs(Convert.ToInt32(Request.QueryString["Id"]), editorContent);

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
WHERE News.Id =@Id AND Cover = 1;";

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