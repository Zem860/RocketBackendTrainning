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
    public partial class DeckPlan : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // 只在首次載入時執行
            {
                getDropDown();
                getDeckImg(); // 載入預設的船型圖片
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
                        getDeckImg();

                    }
                }
                else
                {
                    Response.Write("<script>alert('Please add at least one photo')</script>");
                }
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

        public void getDeckImg()
        {
            string query = @"SELECT Id, ImgPath FROM LayoutImg WHERE YachtId = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", YachtModel.SelectedValue);
                SqlDataReader reader = cmd.ExecuteReader();
                DeckGridView.DataSource = reader;
                DeckGridView.DataBind();

            }
        }

        protected void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (GridViewRow row in DeckGridView.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                    HiddenField hiddenId = (HiddenField)row.FindControl("hiddenId");

                    if (chk != null && chk.Checked && hiddenId != null)
                    {
                        int id = Convert.ToInt32(hiddenId.Value);
                        string query = @"DELETE FROM LayoutImg WHERE Id = @Id";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                getDeckImg();
            }
        }

        protected void YachtModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDeckImg();
        }
    }
}