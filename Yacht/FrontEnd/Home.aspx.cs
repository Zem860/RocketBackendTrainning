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
        public class YachtModel
        {
            public int Id { get; set; }
            public string YachtName { get; set; } // 船名 (去掉數字)
            public string Model { get; set; } // 只保留數字型號
            public string ImageUrl { get; set; } // 圖片路徑

            public string isNew { get; set; }

        }
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;

        private string GetModelName(string model)
        {
            int lastSpaceIndex = model.LastIndexOf(' ');
            return (lastSpaceIndex != -1) ? model.Substring(0, lastSpaceIndex) : model;
        }
        private string GetModelNumber(string model)
        {
            int lastSpaceIndex = model.LastIndexOf(' ');
            return (lastSpaceIndex != -1) ? model.Substring(lastSpaceIndex + 1) : "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getHomePhoto();
                getNews();

            }
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

        public void getHomePhoto()
        {
            string query = @"
        SELECT 
            Y.Id AS Id, 
            Y.Model AS Model, 
            I.ImgPath AS ImageUrl,
            Y.IsNew AS IsNew
        FROM YachtsModel Y 
        INNER JOIN YachtImgs I ON Y.Id = I.YachtId 
        WHERE I.Cover = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                List<YachtModel> yachts = new List<YachtModel>();

                while (reader.Read())
                {
                    string fullModel = reader["Model"].ToString().Trim(); // 取得完整名稱
                    string yachtName = GetModelName(fullModel); // 取得名稱部分
                    string modelNumber = GetModelNumber(fullModel); // 取得型號部分
                    string imageUrl = reader["ImageUrl"].ToString(); // 圖片 URL
                    string isNew = reader["IsNew"].ToString(); ; // 正確讀取 bit 值

                    yachts.Add(new YachtModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        YachtName = yachtName,   // 只保留船名
                        Model = modelNumber,     // 只保留數字型號
                        ImageUrl = imageUrl,      // 圖片路徑
                        isNew = isNew ,  // 轉換 bit 為 "1" 或 "0"
                    });
                }

                reader.Close(); // 關閉 reader，防止資料庫連線佔用
                rptBoats.DataSource = yachts;
                rptBoats.DataBind();

                rptThumbnails.DataSource = yachts; // ✅ 讓小圖與大圖共用相同的數據
                rptThumbnails.DataBind();
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