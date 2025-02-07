using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.FrontEnd
{
    public partial class Dealers : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
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
            string countryName = Request.QueryString["country"];


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

                    ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(getThatCountryDealers, connection);
                cmd.Parameters.AddWithValue(@"country", countryName);
                SqlDataReader reader = cmd.ExecuteReader();
                Repeater2.DataSource = reader;
                Repeater2.DataBind();
            }

        }
    }


}