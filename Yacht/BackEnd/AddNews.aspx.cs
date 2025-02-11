using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;

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
            string editorContent = Request.Unvalidated.Form["editor1"]; // 獲取 CKEditor 內容，不過濾

            // 替換 <img> 標籤中的 src 屬性，使其指向 /NewsImgs/
            string pattern = "<img([^>]+)src=\"([^\"]+)\"";
            editorContent = Regex.Replace(editorContent, pattern, match =>
            {
                string oldSrc = match.Groups[2].Value; // 原始圖片 URL
                string fileName = Path.GetFileName(oldSrc); // 取得圖片檔名
                string newSrc = "/NewsImgs/" + fileName; // 修改 src
                return $"<img{match.Groups[1].Value} src=\"{newSrc}\""; // 保留其他屬性，僅修改 src
            });

            // 使用 SqlParameter 防止 SQL Injection
            string query = @"INSERT INTO News (Title, NewsContent) VALUES (@title, @content)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@title", NewsTitle.Text); // 標題
                cmd.Parameters.AddWithValue("@content", editorContent); // 儲存 HTML 內容
                cmd.ExecuteNonQuery();
            }
        }
    }
}
