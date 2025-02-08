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
    public partial class News : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            getNews();
        }
        protected string FilterContent(string htmlContent)
        {
            // 移除所有 <figure> 標籤及其內容(去掉圖片)
            string cleanedHtml = Regex.Replace(htmlContent, @"<figure[^>]*>.*?</figure>", string.Empty, RegexOptions.Singleline);
            // 移除所有 標籤
            string cleanedHtml2 = Regex.Replace(cleanedHtml, "<.*?>", string.Empty);
            // 使用正則表達式按空格分割單字
            var words = cleanedHtml2.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            // 截取指定數量的單詞
            string limitedText = string.Join(" ", words.Take(50));
            // 如果字數超過最大字數，添加省略號
            if (words.Length > 50)
            {
                limitedText += "...";
            }            
            return limitedText;
        }

        public void getNews()
        {
            string query = @"SELECT News.Title, NewsImgs.imagePath AS NewsImg, News.NewsContent, CONVERT(NVARCHAR,News.CreatedAt, 111) AS CreatedAt FROM News INNER JOIN NewsImgs ON NewsImgs.newsId = News.Id WHERE NewsImgs.Cover = 1";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                Repeater1.DataSource = reader;
                Repeater1.DataBind();
            }
        }
    }
}