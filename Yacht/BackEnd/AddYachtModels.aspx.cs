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
    public partial class YachtModels : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void addShipModel()
        {
            if (!FileUpload1.HasFiles)
            {
                Response.Write("<script>alert('Please upload at least one photo');</script>");
                return;
            }
            else if (String.IsNullOrEmpty(YachtModel.Text))
            {
                Response.Write("<script>alert('Please enter a Yacht Model');</script>");
                return;
            }

            // 確認是否為最新船型（CheckBox）
            //int isNewValue = IsNewModel.Checked ? 1 : 0;

            string query = @"INSERT INTO YachtsModel (Model, DesignId) 
                             VALUES (@model, @designId); 
                             SELECT SCOPE_IDENTITY();";

            int dataId;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"model", YachtName.Text + " " + YachtModel.Text);
                cmd.Parameters.AddWithValue(@"designId", ModelDesign.SelectedValue);

                object shipId = cmd.ExecuteScalar();
                dataId = (shipId != null) ? Convert.ToInt32(shipId) : 0;
            }

            // 新增照片
            addPhotos(dataId);
        }

        public void addPhotos(int shipId)
        {
            string localPath = Server.MapPath("~/ShipImages/");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int count = 0;
                foreach (var img in FileUpload1.PostedFiles)
                {
                    int imgMemory = img.ContentLength;
                    string imgName = Path.GetFileName(img.FileName);
                    string imgExtension = Path.GetExtension(img.FileName);
                    string localSavingPath = Path.Combine(localPath, imgName);

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
                        string mappingPath = "/ShipImages/" + imgName;
                        string query = @"INSERT INTO YachtImgs (YachtId, Cover, ImgPath, CreatedAt) 
                                         VALUES (@shipId, @cover, @imgPath, GETDATE())";

                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue(@"shipId", shipId);
                        if (count == 0)
                        {
                            cmd.Parameters.AddWithValue(@"cover", 1);

                        } else
                        {
                            cmd.Parameters.AddWithValue(@"cover", 0);

                        }
                        cmd.Parameters.AddWithValue(@"imgPath", mappingPath);
                        cmd.ExecuteNonQuery();

                        img.SaveAs(localSavingPath);
                        count++;
                    }
                }

                Response.Redirect("YachtsModel.aspx");
            }
        }

        protected void addModel(object sender, EventArgs e)
        {
            addShipModel();
        }

        protected void rblLatestModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
