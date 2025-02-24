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

    public partial class EditShipPhotos : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected string Id = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Id = Request.QueryString["id"];

                show();
            }
        }

        public void show()
        {
            if (String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Response.Redirect("YachtsModel.aspx");
            }

            // 🔥 確保清空 ListBox，避免顯示舊資料
            AllImages.Items.Clear();
            DeleteImagesList.Items.Clear();

            string query = @"
        SELECT
            YachtsModel.Id AS Id, 
            YachtsModel.Model AS Title, 
            YachtImgs.ImgPath AS PinUpImgs,  
            YachtImgs.Id AS ImgId,  
            (SELECT TOP 1 ImgPath FROM YachtImgs WHERE YachtId = YachtsModel.Id AND Cover = 1) AS PinUp
        FROM YachtsModel
        INNER JOIN YachtImgs ON YachtImgs.YachtId = YachtsModel.Id
        WHERE YachtsModel.Id = @Id 
        ORDER BY YachtImgs.CreatedAt ASC;
    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", Request.QueryString["id"]);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Model.Text = reader["Title"].ToString();
                    string selectedCover = reader["PinUp"] != DBNull.Value ? reader["PinUp"].ToString() : "";

                    ListItem img = new ListItem($"<img src='{reader["PinUpImgs"]}' style='object-fit:cover; width:100px; height:75px;'>", reader["PinUpImgs"].ToString());
                    AllImages.Items.Add(img);

                    ListItem imgforDelete = new ListItem($"<img src='{reader["PinUpImgs"]}' style='object-fit:cover; width:100px; height:75px;'>", reader["ImgId"].ToString());
                    DeleteImagesList.Items.Add(imgforDelete);

                    if (selectedCover == reader["PinUpImgs"].ToString())
                    {
                        img.Selected = true;
                        PreviewImage.ImageUrl = selectedCover;
                    }
                }
            }
        }



        protected void changePinUp(object sender, EventArgs e)
        {
            if (AllImages.SelectedValue != "")
            {
                string selectedCover = AllImages.SelectedValue;


                string query = @"
            UPDATE YachtImgs SET Cover = 0 WHERE YachtId = @Id; -- 先清除所有封面
            UPDATE YachtImgs SET Cover = 1 WHERE YachtId = @Id AND ImgPath = @Cover; -- 設定新的封面";

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
                        if (checkIfPinedUp(item.Value))
                        {
                            Response.Write("<script>alert('Cover Photo cannot be deleted')</script>");
                            return;
                        }
                        //deleteLocalImg(item.Value);
                        SqlCommand cmd = new SqlCommand("DELETE FROM YachtImgs WHERE Id = @ImgId", connection);
                        cmd.Parameters.AddWithValue("@ImgId", item.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            show();
        }

        public bool checkIfPinedUp(string id)
        {
            string query = @"SELECT Cover FROM YachtImgs WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (Convert.ToInt32(reader["Cover"]) == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        protected void UploadImgs(object sender, EventArgs e)
        {
            string localPath = Server.MapPath("~/ShipImages/");
            string query = @"INSERT INTO YachtImgs (YachtId, ImgPath, Cover) VALUES (@id, @imgPath, @cover)";
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
                        string imgMappingPath = "/ShipImages/" + imgFileName;
                        if (imgMemory > 1000000)
                        {
                            continue;
                        }
                        else if (imgExtension != ".jpg" && imgExtension != ".png")
                        {
                            continue;
                        }
                        else
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue(@"id", Request.QueryString["Id"]);
                            cmd.Parameters.AddWithValue(@"imgPath", imgMappingPath);
                            cmd.Parameters.AddWithValue(@"cover", 0);
                            cmd.ExecuteNonQuery();
                            img.SaveAs(imgLocalPath);
                            show();
                        }
                    }

                }
            }
        }
    }
}