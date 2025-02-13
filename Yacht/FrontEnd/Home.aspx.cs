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
    public partial class Home : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            getNews();
        }
        public void getNews()
        {
            string query = "SELECT TOP 3 News.Id AS Id, News.Title AS NewsTitle, News.PinUp AS NewsPinUp, NewsImgs.imagePath AS PinUpImg, News.NewsContent, News.NewsContent AS NewsContent, CONVERT(NVARCHAR,News.CreatedAt, 111) AS CreatedAt FROM News INNER JOIN NewsImgs ON NewsImgs.newsId = News.Id WHERE NewsImgs.Cover = 1 Order By PinUp DESC, CreatedAt DESC";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                Repeater1.DataSource = reader;
                Repeater1.DataBind();
            }
        }

        protected string FilterContent(object htmlContent)
        {
            if (htmlContent == null)
            {
                return string.Empty;
            }

            // 1. 先轉成字串，並確保內容不為 null
            string content = htmlContent.ToString();

            // 2. 移除所有 <figure> 標籤及其內容 (去掉圖片)
            content = Regex.Replace(content, @"<figure[^>]*>.*?</figure>", string.Empty, RegexOptions.Singleline);

            // 3. 移除所有 HTML 標籤
            content = Regex.Replace(content, "<.*?>", string.Empty);

            // 4. 移除 HTML 編碼，例如 `&nbsp;` 轉為空格
            content = HttpUtility.HtmlDecode(content);

            // 5. 移除多餘的換行與空格
            content = Regex.Replace(content, @"\s+", " ").Trim();

            // 6. 截取 25 個字，確保長度受限
            var words = content.Take(50);
            string limitedText = string.Join("", words);

            // 7. 如果超過 25 字，加上 "..."
            if (content.Length > 50)
            {
                limitedText += "...";
            }

            return limitedText;
        }
    }

}