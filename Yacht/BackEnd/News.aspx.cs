﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
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
            var words = content.Take(100);
            string limitedText = string.Join("", words);

            // 7. 如果超過 25 字，加上 "..."
            if (content.Length > 100)
            {
                limitedText += "...";
            }

            return limitedText;
        }

        protected void Delete(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(NewsGridView.DataKeys[e.RowIndex].Value);
            string query = @"DELETE FROM News WHERE Id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", id);
                cmd.ExecuteNonQuery();
                showNews();
            }
        }
    }
}
