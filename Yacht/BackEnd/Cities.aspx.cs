using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.BackEnd
{
    public partial class Cities : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showCountries();
            }
        }

        public void showCountries()
        {
            string query = @"SELECT Id, CountryName FROM Countries";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                Countries.DataSource = reader;
                Countries.DataTextField = "CountryName";
                Countries.DataValueField = "Id";
                Countries.SelectedValue = "1";
                Countries.DataBind();
            }
            showCities();


        }
        public void showCities()
        {    
            string query = @"SELECT Id, City FROM Cities WHERE CountryId = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"Id", Countries.SelectedValue);
                SqlDataReader reader = cmd.ExecuteReader();
                CityGridView.DataSource = reader;
                CityGridView.DataBind();
            }
        }

        protected void Countries_SelectedIndexChanged(object sender, EventArgs e)
        {
            showCities();
        }

        protected void addCity(object sender, EventArgs e)
        {
            string query = @"INSERT INTO Cities (CountryId, City) VALUES(@countryId,@city)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"countryId", Countries.SelectedValue);
                cmd.Parameters.AddWithValue(@"city", CityName.Text);
                cmd.ExecuteNonQuery();
            }
            showCities();
        }
    }
}