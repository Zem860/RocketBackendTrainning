using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestRecipe
{
    public partial class _Default : Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["RecipeTestConnectionstring"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    show();
                }
                else
                {
                    showDetail();
                }

            }
        }
        public void show()
        {
            RecipeMultiView.ActiveViewIndex = 0;
            string query = "SELECT * FROM Recipe";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                RecipeRepeater.DataSource = dt;
                RecipeRepeater.DataBind();

            }
        }

        private string ConvertToEmbedUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return "";
            }

            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                return "";
            }

            string videoId = "";

            // 解析 `watch?v=` 格式的 YouTube 連結
            if (uri.Host.Contains("youtube.com") && uri.Query.Contains("v="))
            {
                var query = HttpUtility.ParseQueryString(uri.Query);
                videoId = query["v"];
            }
            // 解析 `youtu.be/` 短連結
            else if (uri.Host.Contains("youtu.be"))
            {
                videoId = uri.AbsolutePath.Substring(1);
            }
            // 解析 `embed/` 影片網址
            else if (uri.Host.Contains("youtube.com") && uri.AbsolutePath.Contains("/embed/"))
            {
                videoId = uri.Segments.Last();
            }

            // 確保 videoId 不是空的
            if (string.IsNullOrEmpty(videoId))
            {
                return "";
            }

            // ✅ 回傳 `embed` 影片連結
            return $"https://www.youtube.com/embed/{videoId}";
        }
        public void showDetail()
        {
            RecipeMultiView.ActiveViewIndex = 1;
            string query = "SELECT R.Id AS Id, R.RecipeName AS RecipeName, RC.RecipeIntro AS Intro," +
                "RC.CookingTime AS CookingTime, RC.Portion AS Portion, RC.RecipeVideoLink AS Video, I.ImgUrl AS Img" +
                " FROM Recipe R INNER JOIN RecipeContent RC ON R.Id = RC.RecipeId INNER JOIN Imgs I ON R.Id = I.RecipeId  WHERE R.Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    RecipeName.Text = reader["RecipeName"].ToString();
                    Intro.Text = reader["Intro"].ToString();
                    CookingTime.Text = reader["CookingTime"].ToString() + "分鐘";
                    Portion.Text = reader["Portion"].ToString() + "人份";
                    Cover.ImageUrl = reader["Img"].ToString();

                    // 讀取影片網址並轉換
                    string rawVideoUrl = reader["Video"].ToString();
                    string embedUrl = ConvertToEmbedUrl(rawVideoUrl);

                    // 設定 startTime 和 endTime
                    int startTime = 10;
                    int endTime = 20;

                    if (!string.IsNullOrEmpty(embedUrl))
                    {
                        // ✅ 生成 `iframe`，並加上 `enablejsapi=1` 讓 JavaScript 控制
                        string changedUrl = $"<iframe id='youtubePlayer' width='912' height='513' src='{embedUrl}?enablejsapi=1' frameborder='0' allowfullscreen></iframe>";
                        WholeVideo.Text = changedUrl;
                    }
                    else
                    {
                        WholeVideo.Text = "<p>影片載入失敗，請檢查影片連結</p>";
                    }

                    // ✅ 設定隱藏欄位，讓 JavaScript 讀取 `startTime` 和 `endTime`
                    StartTimeHidden.Value = startTime.ToString();
                    EndTimeHidden.Value = endTime.ToString();
                }
            }
        }
    }
}
//給前端
//function convertToEmbedUrl(url)
//{
//    try
//    {
//        let videoId = "";

//        // 1️⃣ 建立 URL 物件來解析網址
//        let urlObj = new URL(url);
//        let hostname = urlObj.hostname;
//        let pathname = urlObj.pathname;
//        let searchParams = urlObj.searchParams;

//        // 2️⃣ ✅ 限制只能處理 YouTube 網址，防止開放式重定向攻擊
//        if (!hostname.includes("youtube.com") && !hostname.includes("youtu.be"))
//        {
//            return "";
//        }

//        // 3️⃣ 解析 `watch?v=` 格式
//        if (hostname.includes("youtube.com") && searchParams.has("v"))
//        {
//            videoId = searchParams.get("v"); // ✅ 取得 `v` 參數
//        }
//        // 4️⃣ 解析 `youtu.be/` 短連結
//        else if (hostname.includes("youtu.be"))
//        {
//            videoId = pathname.substring(1); // ✅ 移除 `/`
//        }
//        // 5️⃣ 解析 `embed/` 影片網址
//        else if (hostname.includes("youtube.com") && pathname.includes("/embed/"))
//        {
//            videoId = pathname.split("/").pop(); // ✅ 取得最後一段
//        }

//        // 6️⃣ ✅ 確保 `videoId` 有值，並回傳 `embed` 連結
//        return videoId ? `https://www.youtube.com/embed/${videoId}` : "";
//    }
//    catch (error)
//    {
//        return ""; // ❌ 如果網址格式錯誤，回傳空字串
//    }
//}

