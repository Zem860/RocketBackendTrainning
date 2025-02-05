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
    public partial class AddDealer : System.Web.UI.Page
    {

        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getDropDown();
            }
        }

        public void getDropDown(string countryId = "1")
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT Id, CountryName FROM Countries";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                countrySwitch.DataSource = reader;
                countrySwitch.DataBind();
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT Id, City FROM Cities WHERE CountryId = @countryId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"countryId", countryId);
                SqlDataReader reader = cmd.ExecuteReader();
                citySwitch.DataSource = reader;
                citySwitch.DataBind();
            }
        }

        protected void ChangeCategory(object sender, EventArgs e)
        {
            string id = countrySwitch.SelectedValue;
            if (countrySwitch.Items.FindByValue(id) != null)
            {
                countrySwitch.SelectedValue = id;
            }
            getDropDown(id);
        }

        public string[] handlePhoto()
        {
            string[] ImageData = new string[3];
            string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
            string dealerImagePath = Server.MapPath("~/BackEnd/DealerImages/");
            HttpPostedFile Image = FileUpload1.PostedFile;
            string imageExtension = Path.GetExtension(Image.FileName).ToLower(); // 取得 單一檔案 檔名變數，並轉成小寫
            string FilePath = Path.Combine(dealerImagePath, Image.FileName);  // 取得 單一檔案 儲存路徑
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int FileMemory = Image.ContentLength;

                if (FileMemory > 1000000)
                {
                    Response.Write("<script>alert('檔案太大了')</script>");
                    return null;
                }
                else if (imageExtension != ".png" && imageExtension != ".jpg")
                {
                    Response.Write("<script>alert('圖片檔案格式不服')</script>");
                    return null;
                }
                else    // 4-3. 如果 單一檔案 吻合格式
                {
                    // 5. 進行 資料庫 寫入
                    string pathStore = "DealerImages/" + Image.FileName;
                    ImageData[0] = pathStore;
                    ImageData[1] = Image.FileName;
                    Image.SaveAs(FilePath);

                }

                return ImageData;
            }

        }

        protected void addData(object sender, EventArgs e)
        {
            string[] ImageData = handlePhoto();
            string dealerPhoto = "";
            if (ImageData == null)
            {
                Response.Write("<script>alert('你沒上傳檔案')</script>");
                return;
                //將原來路徑放回資料庫即可
            }
            else
            {
                dealerPhoto = ImageData[0];
            }
            int dealerId;
            string query2 = @"
                    INSERT INTO Dealers (DealerName, DealerPhoto, DealerEmail,DealerGender, Phone, Fax, Cell ) 
                        VALUES (@dealerName, @dealerPhoto, @dealerEmail,@dealerGender, @phone, @fax, @cell);
                    SELECT SCOPE_IDENTITY();"; // 取得剛剛插入的 Dealer ID

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query2, connection);
                cmd.Parameters.AddWithValue("@dealerName", DealerName.Text);
                cmd.Parameters.AddWithValue("@dealerPhoto", dealerPhoto);
                if (!String.IsNullOrEmpty(DealerEmail.Text))
                {
                    cmd.Parameters.AddWithValue("@dealerEmail", DealerEmail.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue(@"dealerEmail", DBNull.Value);

                }
                cmd.Parameters.AddWithValue(@"dealerGender", DealerGender.SelectedValue);
                if (!String.IsNullOrEmpty(DealerPhone.Text))
                {
                    cmd.Parameters.AddWithValue(@"phone", DealerPhone.Text);
                } else
                {
                    cmd.Parameters.AddWithValue(@"phone", DBNull.Value);

                }
                if (!String.IsNullOrEmpty(DealerFax.Text))
                {
                    cmd.Parameters.AddWithValue(@"fax", DealerFax.Text);
                } else
                {
                    cmd.Parameters.AddWithValue(@"fax", DBNull.Value);

                }
                if (!String.IsNullOrEmpty(DealerCell.Text))
                {
                    cmd.Parameters.AddWithValue(@"cell", DealerCell.Text);
                } else
                {
                    cmd.Parameters.AddWithValue(@"cell", DBNull.Value);

                }

                dealerId = Convert.ToInt32(cmd.ExecuteScalar()); // 取得插入的 Dealer ID
            }


            string query3 = @"INSERT INTO Companies (CityId, CompanyName, DealerId, Address, Link, SoftDelete )
                    VALUES(@cityId, @companyName,@dealerId, @address,@link,@softDelete)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query3, connection);
                cmd.Parameters.AddWithValue(@"cityId", citySwitch.SelectedValue);
                cmd.Parameters.AddWithValue(@"companyName", CompanyName.Text);
                cmd.Parameters.AddWithValue(@"dealerId", dealerId);
                cmd.Parameters.AddWithValue(@"address", Address.Text);
                cmd.Parameters.AddWithValue(@"link", CompanyLink.Text);
                cmd.Parameters.AddWithValue(@"SoftDelete", 0);
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("Dealers.aspx");

        }
    }
}