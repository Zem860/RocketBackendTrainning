using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using MailKit.Net.Imap;

namespace Yacht.BackEnd
{
    public partial class EditDealer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    Response.Redirect("Dealers.aspx");
                }

                getData();
            }
        }





        public void getData()
        {
            string companyId = Request.QueryString["Id"];
            string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string getCountryId = @"
                SELECT Cities.CountryId AS CountryId,
                Dealers.DealerEmail AS DealerEmail,
                Companies.CityId AS CityId,  
                Companies.CompanyName AS CompanyName, 
                Dealers.DealerName AS DealerName, Dealers.DealerPhoto AS DealerPhoto,
                Companies.Address AS CompanyAddress, Companies.Phone AS CompanyPhone, 
                Companies.Email AS CompanyEmail
                FROM Companies 
                INNER JOIN Cities ON Cities.Id = Companies.CityId 
                INNER JOIN Countries ON Countries.Id = Cities.CountryId
                INNER JOIN Dealers ON Dealers.Id = Companies.DealerId
                WHERE Companies.Id = @Id";

                SqlCommand cmd = new SqlCommand(getCountryId, connection);
                cmd.Parameters.AddWithValue(@"Id", companyId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string countryId = Convert.ToString(reader["CountryId"]);
                    string companyName = Convert.ToString(reader["CompanyName"]);
                    string dealerName = Convert.ToString(reader["DealerName"]);
                    string dealerPhoto = Convert.ToString(reader["DealerPhoto"]);
                    string dealerEmail = Convert.ToString(reader["DealerEmail"]);
                    string companyAddress = Convert.ToString(reader["CompanyAddress"]);
                    string companyPhone = Convert.ToString(reader["CompanyPhone"]);
                    string companyEmail = Convert.ToString(reader["CompanyEmail"]);
                    getDropDown(countryId);
                    DealerName.Text = dealerName;
                    Image1.ImageUrl = dealerPhoto;
                    CompanyName.Text = companyName;
                    Address.Text = companyAddress;
                    CompanyPhone.Text = companyPhone;
                    DealerEmail.Text = dealerEmail;
                    CompanyEmail.Text = companyEmail;
                    if (CountrySwitch.Items.FindByValue(countryId) != null)
                    {
                        CountrySwitch.SelectedValue = countryId;
                    }
                }
            }
        }

        public void getDropDown(string countryId ="1")
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT Id, CountryName FROM Countries";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                CountrySwitch.DataSource = reader;
                CountrySwitch.DataBind();
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT Id, City FROM Cities WHERE CountryId = @countryId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"countryId", countryId);
                SqlDataReader reader = cmd.ExecuteReader();
                CitySwitch.DataSource = reader;
                CitySwitch.DataBind();
            }
        }

        protected void CountrySwitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = CountrySwitch.SelectedValue;
            if (CountrySwitch.Items.FindByValue(id) != null)
            {
                CountrySwitch.SelectedValue = id;
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

        public string getDealerId()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
            string query = @"SELECT DealerId FROM Companies WHERE Id =@id";
            string dealerId = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue(@"Id", Request.QueryString["Id"]);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    dealerId = Convert.ToString(reader["DealerId"]);
                }
               
            }
            return dealerId;
        }

     
        protected void ConfirmEdit(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
            string[] ImageData = handlePhoto();
            string dealerPhoto = "";
            if (ImageData == null)
            {
                dealerPhoto = Image1.ImageUrl;
                //Response.Write("<script>alert('你沒上傳檔案')</script>");
                //將原來路徑放回資料庫即可
            }
            else
            {
                dealerPhoto = ImageData[0];
            }
            //Dealer
            string dealerId = getDealerId();
            string query = @"UPDATE Dealers SET DealerName = @dealerName, DealerPhoto =@dealerPhoto, DealerEmail =@dealerEmail WHERE Id = @dealerId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"dealerId", dealerId);
                cmd.Parameters.AddWithValue(@"dealerName", DealerName.Text);
                cmd.Parameters.AddWithValue(@"dealerPhoto", dealerPhoto);
                cmd.Parameters.AddWithValue(@"dealerEmail", DealerEmail.Text);
                cmd.ExecuteNonQuery();
            }
            //Company
            string countryCityUpdate = @"Update Companies SET CityId = @cityId, CompanyName = @companyName, Address = @address, Phone = @phone, Email = @email WHERE Id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(countryCityUpdate, connection);
                cmd.Parameters.AddWithValue(@"cityId", CitySwitch.SelectedValue);
                cmd.Parameters.AddWithValue(@"companyName", CompanyName.Text);
                cmd.Parameters.AddWithValue(@"email", CompanyEmail.Text);
                cmd.Parameters.AddWithValue(@"address", Address.Text);
                cmd.Parameters.AddWithValue(@"Phone", CompanyPhone.Text);
                cmd.Parameters.AddWithValue(@"id", Request.QueryString["Id"]);
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("/Dealers.aspx");
        }
    }
}