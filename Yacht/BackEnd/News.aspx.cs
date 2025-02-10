using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.BackEnd
{
    public partial class News : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showNews();
            }
        }

        public void showNews()
        {
            string query = "SELECT News.Id AS Id, News.Title AS NewsTitle, NewsImgs.imagePath AS PinUpImg, News.NewsContent, News.NewsContent AS NewsContent, CONVERT(NVARCHAR,News.CreatedAt, 111) AS CreatedAt FROM News INNER JOIN NewsImgs ON NewsImgs.newsId = News.Id WHERE NewsImgs.Cover = 1";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                // 修改 News Content，縮短字數
                foreach (DataRow row in dt.Rows)
                {
                    if (row["NewsContent"] != DBNull.Value)
                    {
                        string content = row["NewsContent"].ToString();
                        row["NewsContent"] = FilterContent(content);
                    }
                }

                NewsGridView.DataSource = dt;
                NewsGridView.DataBind();
            }
        }

        protected string FilterContent(string htmlContent)
        {
            // 移除所有 <figure> 標籤及其內容 (去掉圖片)
            string cleanedHtml = Regex.Replace(htmlContent, @"<figure[^>]*>.*?</figure>", string.Empty, RegexOptions.Singleline);
            // 移除所有 HTML 標籤
            string cleanedText = Regex.Replace(cleanedHtml, "<.*?>", string.Empty);
            // 使用正則表達式按空格分割單字
            var words = cleanedText.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            // 截取前 15 個單詞
            string limitedText = string.Join(" ", words.Take(15));
            // 如果字數超過 15，添加省略號
            if (words.Length > 15)
            {
                limitedText += "...";
            }
            return limitedText;
        }
    }
}
