using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Yacht.DbHelper;
namespace Yacht.BackEnd
{

    public partial class Dealers : System.Web.UI.Page
    {
        protected int pageSize = 5;
        protected int currentPage = 1;
        protected int totalPages;
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // ✅ 只在首次載入時綁定
            {
                getDropDown("0");
                show();
            }
        }

        public void getDropDown(string countryId)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT Id, CountryName FROM Countries";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                countrySwitch.Items.Add(new ListItem("All", "0"));

                // 綁定資料
                while (reader.Read())
                {
                    countrySwitch.Items.Add(new ListItem(reader["CountryName"].ToString(), reader["Id"].ToString()));
                }
                countrySwitch.SelectedValue = countryId;
            }


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT Id, City FROM Cities";
                if (countryId != "0")
                {
                    query += " WHERE CountryId = @countryId";
                }
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"countryId", countryId);
                SqlDataReader reader = cmd.ExecuteReader();
                citySwitch.DataSource = reader;
                citySwitch.DataBind();
            }
        }


        public void showPage()
        {
            string selectedCountryId = countrySwitch.SelectedValue;
            string query = @"SELECT COUNT(*) FROM Companies";
            if (selectedCountryId != "0")
            {
                query = @"SELECT COUNT(*) FROM Companies 
                            INNER JOIN Cities ON Cities.Id = Companies.CityId
                            INNER JOIN Countries ON Cities.CountryId = Countries.Id
                            WHERE Cities.CountryId = @countryId";
            }
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"countryId", selectedCountryId);
                int dataAmount = (int)cmd.ExecuteScalar();

                totalPages = (int)Math.Ceiling((double)dataAmount / pageSize);
            }

            List<int> pages = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pages.Add(i);
            }

            PageRepeater.DataSource = pages;
            PageRepeater.DataBind();

        }
        public void show()
        {
            showPage();
            DbHelper helper = new DbHelper();
            currentPage = Convert.ToInt32(Request.QueryString["page"]);
            int offset =  currentPage > 0 ? (currentPage - 1) * pageSize : 0;
            string query =
                @"SELECT Com.Id AS Id, Com.CompanyName AS CName, Co.CountryName As CountryName, Ci.City AS City, D.DealerName AS DName,
                D.DealerPhoto AS DPhoto, D.DealerEmail AS DEmail,
                Com.Address AS Address, D.Phone AS Phone, D.Fax As Fax, D.Cell AS Cell, Com.Link AS CompanyLink
                FROM Companies Com
                INNER JOIN Cities Ci ON Com.CityId = Ci.Id
                INNER JOIN Countries Co ON Co.Id = Ci.CountryId
                INNER JOIN Dealers D ON Com.DealerId = D.Id
                WHERE SoftDelete = 0 AND (@countryId = 0 OR Ci.CountryId = @countryId)
                ORDER BY Ci.CountryId
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;
                ";
            DataTable dt = helper.readCompanyData(query, countrySwitch.SelectedValue,offset, pageSize);
            DealersGrid.DataSource = dt;
            DealersGrid.DataBind();
        }

        protected void ChangeCategory(object sender, EventArgs e)
        {
            string selectedCountry = countrySwitch.SelectedValue; // 先保存選中的國家
            string query =
                @"SELECT Com.Id AS Id, Com.CompanyName AS CName, Co.CountryName As CountryName, Ci.City AS City, D.DealerName AS DName,
                D.DealerPhoto AS DPhoto, D.DealerEmail AS DEmail, Com.Address AS Address, D.Phone AS Phone, D.Fax As Fax, D.Cell AS Cell, Com.Link AS CompanyLink
                FROM Companies Com
                INNER JOIN Cities Ci ON Com.CityId = Ci.Id
                INNER JOIN Countries Co ON Co.Id = Ci.CountryId
                INNER JOIN Dealers D ON Com.DealerId = D.Id
                WHERE SoftDelete = 0 AND (@countryId=0 OR Co.Id = @countryId)
                ";

            DbHelper helper = new DbHelper();
            DataTable dt = helper.readCompanyData(query, countrySwitch.SelectedValue);
            // 先清空 DropDownList 內容
            countrySwitch.Items.Clear();
            getDropDown(selectedCountry);
            DealersGrid.DataSource = dt;
            DealersGrid.DataBind();
            showPage();
            show();
        }

        protected void DealersGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string num = countrySwitch.SelectedValue;
            countrySwitch.SelectedValue = num;
            string query = @"UPDATE Companies SET SoftDelete= 1, UpdatedAt = GETDATE() WHERE Id = @id";
            string id = DealersGrid.DataKeys[e.RowIndex].Value.ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"Id", id);
                cmd.ExecuteNonQuery();
            }
            show();
        }
    }
}