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
    public partial class AddDeckPlan : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDropDown();
            }
        }

        public void getDropDown()
        {
            string query = @"SELECT Id, Model FROM YachtsModel";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                YachtModel.DataSource = reader;
                YachtModel.DataTextField = "Model";  // 設定 Model 為顯示的名稱
                YachtModel.DataValueField = "Id";    // 設定 Id 為選擇的值
                YachtModel.DataBind();
            }
        }

        protected void addImg(object sender, EventArgs e)
        {
            string localPath = Server.MapPath("~/DeckPlanImgs/");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                if (ImgUpload.HasFiles)
                {
                    foreach (var img in ImgUpload.PostedFiles)
                    {
                        int imgMemory = img.ContentLength;
                        string FileName = Path.GetFileName(img.FileName);
                        string imgExtension = Path.GetExtension(img.FileName);
                        string localStorePath = Path.Combine(localPath, FileName);
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
                            string localMappingPath = "/DeckPlanImgs/" + FileName;
                            string query = @"INSERT INTO LayoutImg (yachtId, ImgPath) VALUES (@yachtId, @ImgPath)";
                            SqlCommand cmd = new SqlCommand(query, connection);
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue(@"yachtId", YachtModel.SelectedValue);
                            cmd.Parameters.AddWithValue(@"ImgPath", localMappingPath);
                            cmd.ExecuteNonQuery();
                            img.SaveAs(localStorePath);
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please add at least one photo')</script>");
                }
            }
        }
    }
}