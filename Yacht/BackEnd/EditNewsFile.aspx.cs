using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.BackEnd
{
    public partial class EditNewsFile : System.Web.UI.Page
    {
        protected string Id = string.Empty;
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Id = Request.QueryString["Id"];
                if (String.IsNullOrEmpty(Id))
                {
                    Response.Redirect("News.aspx");
                }
                show();
            }
        }
        protected void AddFiles(object sender, EventArgs e)
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
                            cmd.Parameters.AddWithValue(@"id", Request.QueryString["Id"]);
                            cmd.Parameters.AddWithValue(@"path", fileMappingPath);
                            cmd.Parameters.AddWithValue(@"name", fileName);
                            file.SaveAs(localPath);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    show();
                }
            }
            else
            {
                Response.Write("<script>alert('You need to attach at least one file!')</script>");
            }
        }

        public void getTitle()
        {
            string query = @"SELECT Title FROM News WHERE Id =@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", Id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    NewsTitle.Text = reader["Title"].ToString();
                }
            }
        }

        public void show()
            
        {

            string query = @"SELECT Id AS FileId, FileName AS FileName
                                FROM NewsFiles                             
                                WHERE NewsId = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", Request.QueryString["Id"]);
                SqlDataReader reader = cmd.ExecuteReader();
                FileGridView.DataSource = reader;
                FileGridView.DataBind();
            }
            getTitle();
        }

        protected void Delete(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(FileGridView.DataKeys[e.RowIndex].Value);
            string query = @"DELETE FROM NewsFiles WHERE Id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", id);
                cmd.ExecuteNonQuery();

            }
            show();
        }
    }
}