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
            string query = @"SELECT Com.Id AS Id, Com.CompnayName AS CName, Cou.CountryName As CountryName, D.DealerName AS DName, D.DealerPhoto AS DPhoto, D.DealerEmail AS DEmail, Com.City AS City, Com.Address AS Address, Com.Phone AS Phone, Com.Email AS CompanyEmail
                FROM Companies Com
                INNER JOIN Countries Cou ON Com.CountryId = Cou.Id
                INNER JOIN Dealers D ON Com.DealerId = D.Id
                WHERE SoftDelete = 0
                ";
            //string query = @"SELECT Id, DealerName AS DealerName, DealerPhoto, DealerEmail, DealerGender FROM Dealers";
            DataTable dt = helper.readCompanyData(query);
            DealersGrid.DataSource = dt;
            DealersGrid.DataBind();
            
        }

        protected void ChangeCategory(object sender, EventArgs e)
        {
            string query =
                @"SELECT Com.Id AS Id, Com.CompnayName AS CName, Cou.CountryName As CountryName, D.DealerName AS DName, D.DealerPhoto AS DPhoto, D.DealerEmail AS DEmail, Com.City AS City, Com.Address AS Address, Com.Phone AS Phone, Com.Email AS CompanyEmail
                FROM Companies Com
                INNER JOIN Countries Cou ON Com.CountryId = Cou.Id
                INNER JOIN Dealers D ON Com.DealerId = D.Id
                WHERE Com.SoftDelete = 0 AND Cou.Id = @countryId
                ";
            if (countrySwitch.SelectedValue == "0")
            {
                query =
                @"SELECT Com.Id AS Id, Com.CompnayName AS CName, Cou.CountryName As CountryName, D.DealerName AS DName, D.DealerPhoto AS DPhoto, D.DealerEmail AS DEmail, Com.City AS City, Com.Address AS Address, Com.Phone AS Phone, Com.Email AS CompanyEmail
                FROM Companies Com
                INNER JOIN Countries Cou ON Com.CountryId = Cou.Id
                INNER JOIN Dealers D ON Com.DealerId = D.Id
                WHERE Com.SoftDelete = 0
                ";
            }
            DbHelper helper = new DbHelper();
            DataTable dt = helper.readCompanyData(query, countrySwitch.SelectedValue);
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