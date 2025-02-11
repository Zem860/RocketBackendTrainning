using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.BackEnd
{
    public partial class EditNewsPhoto : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected string Id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Id = Request.QueryString["id"];
                if (String.IsNullOrEmpty(Id))
                {
                    Response.Redirect("News.aspx");
                }
                show();
            }
        }

        public void UploadNewsImgs()
        {
            string localPath = Server.MapPath("~/NewsImgs/");
            string query = @"INSERT INTO NewsImgs (NewsId, ImagePath, Cover) VALUES (@id, @imgPath, @cover)";
            if (FileUpload1.HasFiles)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    foreach (var img in FileUpload1.PostedFiles)
                    {
                        int imgMemory = img.ContentLength;
                        string imgFileName = Path.GetFileName(img.FileName);
                        string imgExtension = Path.GetExtension(img.FileName).ToLower();
                        string imgLocalPath = Path.Combine(localPath, imgFileName);
                        string imgMappingPath = "/NewsImgs/"+imgFileName;
                        if (imgMemory > 1000000)
                        {
                            continue;
                        } else if (imgExtension!=".jpg" && imgExtension != ".png")
                        {
                            continue;
                        } else
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue(@"id", Request.QueryString["Id"]);
                            cmd.Parameters.AddWithValue(@"imgPath", imgMappingPath);
                            cmd.Parameters.AddWithValue(@"cover", 0);
                            cmd.ExecuteNonQuery();
                            img.SaveAs(imgLocalPath);
                        }
                    }
                    show();

                   
            }
            }
           

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
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Cover", selectedCover);
                    cmd.Parameters.AddWithValue("@Id", Request.QueryString["Id"]);
                    cmd.ExecuteNonQuery();
                }

            }
            PreviewImage.ImageUrl = AllImages.SelectedValue; // 更新顯示的圖片
        }

        public void show()
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
                STRING_AGG(NewsImgs.Id, ',') AS ImgId,  -- 所有圖片
                (SELECT TOP 1 imagePath FROM NewsImgs WHERE newsId = News.Id AND Cover = 1) AS PinUp, -- 取得封面圖
                News.NewsContent, 
                CONVERT(NVARCHAR, News.CreatedAt, 111) AS CreatedAt
                FROM News
                INNER JOIN NewsImgs ON NewsImgs.newsId = News.Id
                WHERE News.Id =@Id 
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
                        string[] imgId = reader["ImgId"].ToString().Split(',');
                        int getIdIndex = 0;
                        foreach (string i in imgs)
                        {
                            ListItem img = new ListItem($"<img src='{i}' style='object-fit:cover; width:100px; height:75px;'>", i);
                            AllImages.Items.Add(img);
                            ListItem imgforDelete = new ListItem($"<img src='{i}' style='object-fit:cover; width:100px; height:75px;'>", imgId[getIdIndex]);
                            DeleteImagesList.Items.Add(imgforDelete);
                            if (reader["PinUp"].ToString() == i)
                            {
                                img.Selected = true;
                                PreviewImage.ImageUrl = i;
                            }
                            getIdIndex++;
                        }
                    }
                }
            }
        }

        protected void DeleteSelectedImages(object sender, EventArgs e)
        {
            if (DeleteImagesList.Items.Count == 1)
            {
                Response.Write("<script>alert('You only have 1 image left!')</script>");
                return;
            } 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (ListItem item in DeleteImagesList.Items)
                {
                    if (item.Selected)
                    {
                       if (!checkIfPinedUp(item.Value))
                        {
                            Response.Write("<script>alert('Cover Photo cannot be deleted')</script>");
                            return;
                        }

                        SqlCommand cmd = new SqlCommand("DELETE FROM NewsImgs WHERE Id = @ImgId", connection);
                        cmd.Parameters.AddWithValue("@ImgId", item.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            show();
        }


        public bool checkIfPinedUp(string id)
        {
            string query = @"SELECT Cover FROM NewsImgs WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Cover"].ToString() == "1")
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        protected void UploadImgs(object sender, EventArgs e)
        {
            UploadNewsImgs();
        }
    }
}