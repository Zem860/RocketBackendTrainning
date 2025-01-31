using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.BackEnd
{
    public partial class Countries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
            }
        }

        public void show()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
            string query = @"SELECT Id, CountryName, CreatedAt, UpdatedAt FROM Countries";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                CountryList.DataSource = reader;
                CountryList.DataBind();
            }
        }

        protected void addCountry(object sender, EventArgs e)
        {

            int countryExist = checkCountry();
            bool hasCountry = countryExist > 0;
            if (hasCountry) {
                Response.Write("<script>alert('CountryName Already Exists')</script>");

                return;    
            }
            string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
            string query = @"INSERT INTO Countries (CountryName) VALUES (@country)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"country", CountryName.Text);
                cmd.ExecuteNonQuery();
                show();
            }
        }
        public int checkCountry()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
            string query = @"SELECT COUNT(*) FROM Countries WHERE CountryName = @country";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"country", CountryName.Text.Trim());
                return (int)cmd.ExecuteScalar();
            }
        }

        protected void showPanel(object sender, GridViewEditEventArgs e)
        {
            CountryList.EditIndex = e.NewEditIndex;
            show();
        }

        protected void updateCountry(object sender, GridViewUpdateEventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
            string query = @"UPDATE Countries SET CountryName = @country, UpdatedAt = GETDATE() WHERE Id = @Id";
            int id = Convert.ToInt32(CountryList.DataKeys[e.RowIndex].Value);
            GridViewRow row = CountryList.Rows[e.RowIndex];
            TextBox txtCountryName = (TextBox)row.FindControl("txtCountryName");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"Id", id );
                cmd.Parameters.AddWithValue(@"country", txtCountryName.Text.Trim());
                cmd.ExecuteNonQuery();
                CountryList.EditIndex = -1;
            }
            show();
        }

        protected void deleteCountry(object sender, GridViewDeleteEventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
            string query = @"DELETE FROM Countries WHERE Id = @Id";
            int id = Convert.ToInt32(CountryList.DataKeys[e.RowIndex].Value);
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