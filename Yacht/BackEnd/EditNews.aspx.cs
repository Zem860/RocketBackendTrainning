using System;
using System.Collections.Generic;
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

        public void showEdit()
        {
            if (String.IsNullOrEmpty(Id))
            {
                Response.Redirect("News.aspx");
            }
            string query = @"
                SELECT
    News.Id AS Id, 
    News.Title AS NewsTitle, 
    STRING_AGG(NewsImgs.imagePath, ',') AS PinUpImgs,  -- 所有圖片
    (SELECT TOP 1 imagePath FROM NewsImgs WHERE newsId = News.Id AND Cover = 1) AS PinUp, -- 取得封面圖
    News.NewsContent, 
    CONVERT(NVARCHAR, News.CreatedAt, 111) AS CreatedAt
FROM News
INNER JOIN NewsImgs ON NewsImgs.newsId = News.Id
WHERE News.Id =1 
GROUP BY News.Id, News.Title, News.NewsContent, News.CreatedAt";

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

                    if (reader["PinUpImgs"] != DBNull.Value)
                    {
                        string[] imgs = reader["PinUpImgs"].ToString().Split(',');

                        foreach (string i in imgs)
                        {
                            ListItem img = new ListItem($"<img src='{i}' style='object-fit:cover; width:100px; height:75px;'>", i);
                            AllImages.Items.Add(img);
                            if (reader["PinUp"].ToString() == i)
                            {
                                img.Selected = true;
                                PreviewImage.ImageUrl = i;
                            }
                        }
                    }
                }
            }
        }
        protected void sendEdit(object sender, EventArgs e)
        {

        }

        protected void changePinUp(object sender, EventArgs e)
        {
            if (AllImages.SelectedValue != "")
            {
                string selectedCover = AllImages.SelectedValue;


                string query = @"
            UPDATE NewsImgs SET Cover = 0 WHERE newsId = @Id; -- 先清除所有封面
            UPDATE NewsImgs SET Cover = 1 WHERE newsId = @Id AND imagePath = @Cover; -- 設定新的封面";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Cover", selectedCover);
                    cmd.Parameters.AddWithValue("@Id", Request.QueryString["Id"]);
                    cmd.ExecuteNonQuery();
                }

            }
            PreviewImage.ImageUrl = AllImages.SelectedValue; // 更新顯示的圖片
        }
    }
}