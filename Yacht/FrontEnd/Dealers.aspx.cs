using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.FrontEnd
{
    public partial class Dealers : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected int pageSize = 5;
        protected int totalPages;
        protected int offset = 0;
        protected string countryName = "United States";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    getData();
                }

            }

        }




        public void getData()
        {
            int currentPage = Convert.ToInt32(Request.QueryString["page"]);
            offset = currentPage > 0 ? (currentPage - 1) * pageSize : 0;

            countryName = Request.QueryString["country"];

            if (String.IsNullOrEmpty(Request.QueryString["country"]))
            {
                countryName = "United States";
            }
            string getThatCountryDealers = @"
SELECT Cities.City AS CityName, Companies.CompanyName AS CompanyName,
       Dealers.DealerGender AS DealerGender, Dealers.DealerName AS DealerName,
       Dealers.DealerPhoto AS DealerPhoto,
       Companies.Address AS CompanyAddress, Dealers.Phone AS DealerPhone,
       Dealers.DealerEmail AS DealerEmail, Companies.Link AS CompanyLink
FROM Companies
INNER JOIN Cities ON Cities.Id = Companies.CityId
INNER JOIN Countries ON Countries.Id = Cities.CountryId 
INNER JOIN Dealers ON Companies.DealerId = Dealers.Id
WHERE (Countries.Id =(SELECT Id FROM Countries WHERE CountryName = @country))
ORDER BY Companies.Id
 OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY;
                    ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(getThatCountryDealers, connection);
                cmd.Parameters.AddWithValue(@"country", countryName);
                cmd.Parameters.AddWithValue(@"offset", offset);
                cmd.Parameters.AddWithValue(@"pageSize", pageSize);
                SqlDataReader reader = cmd.ExecuteReader();
                Repeater2.DataSource = reader;
                Repeater2.DataBind();
            }
            showPage(countryName);
        }
    

     public void showPage(string countryName)
        {

            string query = @"SELECT COUNT(*) FROM Companies 
                            INNER JOIN Cities ON Cities.Id = Companies.CityId
                            INNER JOIN Countries ON Cities.CountryId = Countries.Id
                            WHERE (Countries.Id =(SELECT Id FROM Countries WHERE CountryName = @country))
                            ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"country", countryName);

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
    }
}