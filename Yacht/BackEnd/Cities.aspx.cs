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

        protected void CityGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            CityGridView.EditIndex = e.NewEditIndex;
            showCities();
        }

        protected void CityGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            CityGridView.EditIndex = -1;
            showCities();
        }

        protected void CityGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string id = CityGridView.DataKeys[rowIndex].Value.ToString();
            string query = @"UPDATE Cities SET City = @city WHERE Id = @id";
            TextBox changedText = CityGridView.Rows[rowIndex].FindControl("TxtCity") as TextBox;
            string editedCity = changedText.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"city", editedCity);
                cmd.Parameters.AddWithValue(@"id", id);
                cmd.ExecuteNonQuery();
            }
            CityGridView.EditIndex = -1;

            showCities();
        }

        protected void CityGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string id = CityGridView.DataKeys[rowIndex].Value.ToString();
            string query = @"DELETE FROM Cities WHERE Id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"Id", id);
                cmd.ExecuteNonQuery();
            }
            showCities();
        }
    }
}