using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
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
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    Response.Redirect("Dealers.aspx");
                }
                getDropDown();
                getData();
            }
        }

        public void getCityDropDown(string countryId)
        {
            string query = "SELECT Id, City FROM Cities WHERE CountryId = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", countryId);
                SqlDataReader reader = cmd.ExecuteReader();

                // 先清空 CitySwitch 以免重複添加
                CitySwitch.Items.Clear();

                // 逐筆新增城市選項
                while (reader.Read())
                {
                    ListItem newItem = new ListItem(reader["City"].ToString(), reader["Id"].ToString());
                    CitySwitch.Items.Add(newItem);
                }

                // 確保資料綁定
            }
        }
        public void getData()
        {
            string companyId = Request.QueryString["Id"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string getCountryId = @"
                SELECT Cities.CountryId AS CountryId,
                Dealers.DealerEmail AS DealerEmail,
                Companies.CityId AS CityId,  
                Companies.CompanyName AS CompanyName, 
                Dealers.DealerName AS DealerName, 
                Dealers.DealerPhoto AS DealerPhoto,
                Dealers.Phone AS DealerPhone,
                Dealers.DealerGender As DealerGender,
                Dealers.Fax AS DealerFax,
                Dealers.Cell AS DealerCell,
                Companies.Address AS CompanyAddress, 
                Companies.Link AS CompanyLink
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
                    string cityId = Convert.ToString(reader["CityId"]);
                    string companyName = Convert.ToString(reader["CompanyName"]);
                    string dealerName = Convert.ToString(reader["DealerName"]);
                    string dealerPhoto = Convert.ToString(reader["DealerPhoto"]);
                    string dealerEmail = Convert.ToString(reader["DealerEmail"]);
                    string dealerPhone = Convert.ToString(reader["DealerPhone"]);
                    string dealerFax = Convert.ToString(reader["DealerFax"]);
                    string dealerCell = Convert.ToString(reader["DealerCell"]);
                    string companyAddress = Convert.ToString(reader["CompanyAddress"]);
                    string companyLink = Convert.ToString(reader["CompanyLink"]);
                    string dealerGender = reader["DealerGender"].ToString().ToLower(); // 轉小寫以確保一致性                    getDropDown(countryId);
                    DealerName.Text = dealerName;
                    Image1.ImageUrl = dealerPhoto;
                    CompanyName.Text = companyName;
                    Address.Text = companyAddress;
                    DealerPhone.Text = dealerPhone;
                    DealerFax.Text = dealerFax;
                    DealerCell.Text = dealerCell;
                    DealerEmail.Text = dealerEmail;
                    CompanyLink.Text = companyLink;
                    Gender.SelectedValue = (dealerGender == "true") ? "1" : "0";
                    if (CountrySwitch.Items.FindByValue(countryId) != null)
                    {
                        CountrySwitch.SelectedValue = countryId;
                    }
                }
            }
            getCityDropDown(CountrySwitch.SelectedValue);
        }
            

        public void getDropDown(string countryId ="1")
        {           
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

        public string[] handlePhoto()
        {
            if (!FileUpload1.HasFile)
            {
                return null;
            }
            string[] ImageData = new string[3];
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
                    //編輯的部分好像不需要這行
                    string pathStore = "DealerImages/" + Image.FileName;
                    ImageData[0] = pathStore;
                    ImageData[1] = Image.FileName;
                    Image.SaveAs(FilePath);
                }

                return ImageData;
            }

        }

        protected void ConfirmEdit(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
            string[] ImageData = handlePhoto();
            //handlephoto之後理論上圖片以檢查沒問題或是有問題的話會返回Null
            string dealerPhoto = "";
            if (ImageData == null)
            {
                dealerPhoto = Image1.ImageUrl;
                //return;
                //Response.Write("<script>alert('你沒上傳檔案')</script>");
                ////將原來路徑放回資料庫即可
            }
            else
            {
                dealerPhoto = ImageData[0];
            }
            //Dealer
            string dealerId = getDealerId();
            string query = @"UPDATE Dealers SET DealerName = @dealerName, DealerGender = @dealerGender, DealerPhoto =@dealerPhoto, DealerEmail =@dealerEmail,
                            Phone = @dealerPhone, Fax = @dealerFax, Cell=@dealerCell

                            WHERE Id = @dealerId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"dealerId", dealerId);
                cmd.Parameters.AddWithValue(@"dealerName", DealerName.Text);
                cmd.Parameters.AddWithValue(@"dealerPhoto", dealerPhoto);
                cmd.Parameters.AddWithValue(@"dealerEmail", DealerEmail.Text);
                cmd.Parameters.AddWithValue(@"dealerPhone", DealerPhone.Text);
                cmd.Parameters.AddWithValue(@"dealerFax", DealerFax.Text);
                cmd.Parameters.AddWithValue(@"dealerCell", DealerCell.Text);
                cmd.Parameters.AddWithValue(@"dealerGender", Gender.SelectedValue);

                cmd.ExecuteNonQuery();
            }
            //Company
            string countryCityUpdate = @"Update Companies SET CityId = @cityId, CompanyName = @companyName, Address = @address, Link = @link WHERE Id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(countryCityUpdate, connection);
                cmd.Parameters.AddWithValue(@"cityId", CitySwitch.SelectedValue);
                cmd.Parameters.AddWithValue(@"companyName", CompanyName.Text);
                cmd.Parameters.AddWithValue(@"link", CompanyLink.Text);
                cmd.Parameters.AddWithValue(@"address", Address.Text);
                cmd.Parameters.AddWithValue(@"id", Request.QueryString["Id"]);
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("Dealers.aspx");
        }

        protected void Preview(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
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
                        return;
                    }
                    else if (imageExtension != ".png" && imageExtension != ".jpg")
                    {
                        Response.Write("<script>alert('圖片檔案格式不服')</script>");
                        return;
                    }
                    else    // 4-3. 如果 單一檔案 吻合格式
                    {
                        // 5. 進行 資料庫 寫入

                        Image.SaveAs(FilePath);
                        Image1.ImageUrl = "DealerImages/"+ Image.FileName;
                    }
                }
            } else
            {
                Response.Write("<script>alert('must upload at least one photo!')</script>");
                return;
            }
        }
    }
}