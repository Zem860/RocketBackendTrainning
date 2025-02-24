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

        public string HandleCkImgs(int id, string editorContent)
        {
            string localPathHeading = Server.MapPath("~/Test/");

            // 確保 /Test/ 資料夾存在
            if (!Directory.Exists(localPathHeading))
            {
                Directory.CreateDirectory(localPathHeading);
            }

            // 取得所有圖片的原始 URL（未被修改的 `src`）
            string imgPattern = @"<img\s+[^>]*?src=['""](https?:\/\/[^'""]+)['""][^>]*?>";
            MatchCollection matches = Regex.Matches(editorContent, imgPattern);

            if (matches.Count == 0)
            {
                return editorContent; // 沒有圖片則直接返回原內容
            }

            string query = @"INSERT INTO NewsContentImgs (NewsId, NewsContentImg) VALUES (@id, @img)";
            int count = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                foreach (Match match in matches)
                {
                    string imageUrl = match.Groups[1].Value; // 原始圖片網址
                    string imgName = Path.GetFileName(new Uri(imageUrl).LocalPath); // 取得圖片名稱
                    string localPath = Path.Combine(localPathHeading, imgName); // 儲存圖片的路徑
                    string imgMappingPath = "/Test/" + imgName; // 新的本地 URL

                    try
                    {
                        // 下載圖片
                        using (var client = new System.Net.WebClient())
                        {
                            client.DownloadFile(imageUrl, localPath);
                        }

                        // **儲存圖片資訊到資料庫**
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue(@"id", id);
                        cmd.Parameters.AddWithValue(@"img", imgMappingPath);
                        cmd.Parameters.AddWithValue(@"cover", 0); 

                        cmd.ExecuteNonQuery();
                        count++;

                        // **更新 `editorContent`，替換 `src`**
                        editorContent = editorContent.Replace(imageUrl, imgMappingPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"圖片下載失敗: {imageUrl}, 錯誤: {ex.Message}");
                    }
                }
            }

            return editorContent; // **回傳更新後的內容**
        }



        public int HandleWords()
        {
            if (String.IsNullOrEmpty(NewsTitle.Text))
            {
                NewsTitle.Text = "";
                Response.Write("<script>alert('Need a title for the News')</script>");
                return 0;
            }

            string editorContent = Request.Unvalidated.Form["editor1"];

            // 儲存新聞內容（此時 `editorContent` 仍包含原始的外部圖片 URL）
            string query = @"INSERT INTO News (Title, NewsContent) VALUES (@title, @content); SELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@title", NewsTitle.Text);
                cmd.Parameters.AddWithValue("@content", editorContent);

                object result = cmd.ExecuteScalar();
                NewsTitle.Text = "";

                int newsId = (result != null) ? Convert.ToInt32(result) : 0;

                // **處理 Ckeditor 內的圖片**
                string updatedEditorContent = HandleCkImgs(newsId, editorContent);

                // **更新已修改圖片 URL 的 `editorContent` 回資料庫**
                string updateQuery = @"UPDATE News SET NewsContent = @content WHERE Id = @id";
                SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                updateCmd.Parameters.AddWithValue("@content", updatedEditorContent);
                updateCmd.Parameters.AddWithValue("@id", newsId);
                updateCmd.ExecuteNonQuery();

                return newsId;
            }
        }




        //public int HandleWords()
        //{
        //    if (String.IsNullOrEmpty(NewsTitle.Text))
        //    {
        //        NewsTitle.Text = "";
        //        Response.Write("<script>alert('Need a title for the News')</script>");
        //        return 0;
        //    }
        //    if (!FileUpload1.HasFile)
        //    {
        //        NewsTitle.Text = "";
        //        Response.Write("<script>alert('Need at least one photo as CoverPhoto')</script>");
        //        return 0;
        //    }
        //    string editorContent = Request.Unvalidated.Form["editor1"];

        //    // 修正圖片標籤，使其包含 src
        //    string imgPattern = @"<img\s+[^>]*?src=['""](\/NewsImgs\/[^'""]+)['""][^>]*?>";
        //    editorContent = Regex.Replace(editorContent, imgPattern, match =>
        //    {
        //        string oldSrc = match.Groups[1].Value;

        //        // 這裡不改變副檔名，只確保 src 保持一致
        //        string newSrc = "/NewsImgs/" + Path.GetFileName(oldSrc);

        //        return match.Value.Replace(oldSrc, newSrc);
        //    });

        //    string query = @"INSERT INTO News (Title, NewsContent) VALUES (@title, @content); SELECT SCOPE_IDENTITY();";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand cmd = new SqlCommand(query, connection);
        //        cmd.Parameters.AddWithValue("@title", NewsTitle.Text);
        //        cmd.Parameters.AddWithValue("@content", editorContent);

        //        object result = cmd.ExecuteScalar();
        //        NewsTitle.Text = "";

        //        return (result != null) ? Convert.ToInt32(result) : 0;
        //    }
        //}

    }
}
