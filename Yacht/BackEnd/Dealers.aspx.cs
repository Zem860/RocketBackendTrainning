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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // ✅ 只在首次載入時綁定
            {
                show();
            }
        }

        public void show()
        {
            DbHelper helper = new DbHelper();
            int pageSize = 5;
            int currentPage = 1;
            int offset =  currentPage > 0 ? (currentPage - 1) * pageSize : 0;
            string query =
                @"SELECT Com.Id AS Id, Com.CompnayName AS CName, Co.CountryName As CountryName, Ci.City AS City, D.DealerName AS DName,
                D.DealerPhoto AS DPhoto, D.DealerEmail AS DEmail, Com.Address AS Address, Com.Phone AS Phone, Com.Email AS CompanyEmail
                FROM Companies Com
                INNER JOIN Cities Ci ON Com.CityId = Ci.Id
                INNER JOIN Countries Co ON Co.Id = Ci.CountryId
                INNER JOIN Dealers D ON Com.DealerId = D.Id
                WHERE SoftDelete = 0
                ORDER BY Ci.CountryId
                OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;
                ";
            DataTable dt = helper.readCompanyData(query, offset, pageSize);
            DealersGrid.DataSource = dt;
            DealersGrid.DataBind();
        }

        protected void ChangeCategory(object sender, EventArgs e)
        {
            string query =
                @"SELECT Com.Id AS Id, Com.CompnayName AS CName, Co.CountryName As CountryName, Ci.City AS City, D.DealerName AS DName,
                D.DealerPhoto AS DPhoto, D.DealerEmail AS DEmail, Com.Address AS Address, Com.Phone AS Phone, Com.Email AS CompanyEmail
                FROM Companies Com
                INNER JOIN Cities Ci ON Com.CityId = Ci.Id
                INNER JOIN Countries Co ON Co.Id = Ci.CountryId
                INNER JOIN Dealers D ON Com.DealerId = D.Id
                WHERE SoftDelete = 0 AND Co.Id = @cityId
                ";
            if (countrySwitch.SelectedValue == "0")
            {
                query =
                @"SELECT Com.Id AS Id, Com.CompnayName AS CName, Co.CountryName As CountryName, Ci.City AS City, D.DealerName AS DName,
                D.DealerPhoto AS DPhoto, D.DealerEmail AS DEmail, Com.Address AS Address, Com.Phone AS Phone, Com.Email AS CompanyEmail
                FROM Companies Com
                INNER JOIN Cities Ci ON Com.CityId = Ci.Id
                INNER JOIN Countries Co ON Co.Id = Ci.CountryId
                INNER JOIN Dealers D ON Com.DealerId = D.Id
                WHERE SoftDelete = 0
                ";
            }
            DbHelper helper = new DbHelper();
            DataTable dt = helper.readCompanyData(query, Convert.ToInt32(countrySwitch.SelectedValue));
            DealersGrid.DataSource = dt;
            DealersGrid.DataBind();
        }

        protected void DealersGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string num = countrySwitch.SelectedValue;
            countrySwitch.SelectedValue = num;
            string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;

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