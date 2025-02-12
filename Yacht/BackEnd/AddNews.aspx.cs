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
            int newsId = HandleWords();
            if (newsId > 0)
            {
                handleImgs(newsId); // 將 newsId 傳遞給 handleImgs()
                handlePdf(newsId);
            }
        }
        public void handlePdf(int id)
        {
            if (FileUpload2.HasFile)
            {
                string localPathHeading = Server.MapPath("~/NewsFiles/");
                string query = @"INSERT INTO NewsFiles (NewsId, FileName, FilePath) VALUES (@id, @name,@path)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    foreach (var file in FileUpload2.PostedFiles)
                    {
                        int fileMemory = file.ContentLength;
                        string fileName = Path.GetFileName(file.FileName);
                        string imgExtension = Path.GetExtension(file.FileName).ToLower();
                        string localPath = Path.Combine(localPathHeading, fileName);
                        if (fileMemory > 1000000)
                        {
                            continue;
                        }
                        else if (imgExtension != ".pdf" && imgExtension != ".txt")
                        {
                            continue;
                        }
                        else
                        {
                            string fileMappingPath = "/NewsFiles/" + fileName;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue(@"id", id);
                            cmd.Parameters.AddWithValue(@"path", fileMappingPath);
                            cmd.Parameters.AddWithValue(@"name", fileName);
                            file.SaveAs(localPath);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public void handleImgs(int id)
        {
            if (FileUpload1.HasFile)
            {
                string localPathHeading = Server.MapPath("~/NewsImgs/");
                string query = @"INSERT INTO NewsImgs (NewsId, ImagePath, Cover) VALUES (@id, @img,@cover)";
                int count = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    foreach(var img in FileUpload1.PostedFiles)
                    {
                        int imgMemory = img.ContentLength;
                        string imgName = Path.GetFileName(img.FileName);
                        string imgExtension = Path.GetExtension(img.FileName).ToLower();
                        string localPath = Path.Combine(localPathHeading, imgName);
                        if (imgMemory > 1000000)
                        {
                            continue;
                        } else if (imgExtension != ".png" && imgExtension != ".jpg")
                        {
                            continue;
                        } else
                        {
                            string imgMappingPath = "/NewsImgs/" + imgName;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue(@"id", id);
                            cmd.Parameters.AddWithValue(@"img", imgMappingPath);
                            if (count == 0)
                            {
                                cmd.Parameters.AddWithValue(@"Cover", 1);

                            } else
                            {
                                cmd.Parameters.AddWithValue(@"Cover",0 );

                            }
                            img.SaveAs(localPath);

                            cmd.ExecuteNonQuery();
                            count++;
                        }
                    }


                }
            } 
           
        }

        public int HandleWords()
        {
            if (String.IsNullOrEmpty(NewsTitle.Text))
            {
                NewsTitle.Text = "";
                Response.Write("<script>alert('Need a title for the News')</script>");
                return 0;
            }
            if (!FileUpload1.HasFile)
            {
                NewsTitle.Text = "";
                Response.Write("<script>alert('Need at least one photo as CoverPhoto')</script>");
                return 0;
            }
            string editorContent = Request.Unvalidated.Form["editor1"];

            // 修正圖片標籤，使其包含 src
            string pattern = @"<img[^>]*?data-ck-upload-id=""([^""]+)""[^>]*?>";
            editorContent = Regex.Replace(editorContent, pattern, match =>
            {
                string uploadId = match.Groups[1].Value;
                string newSrc = "/NewsImgs/" + uploadId + ".jpg";

                return $"<img src=\"{newSrc}\" />";
            });

            string query = @"INSERT INTO News (Title, NewsContent) VALUES (@title, @content); SELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@title", NewsTitle.Text);
                cmd.Parameters.AddWithValue("@content", editorContent);

                object result = cmd.ExecuteScalar();
                NewsTitle.Text = "";

                return (result != null) ? Convert.ToInt32(result) : 0;
            }
        }
        
    }
}
