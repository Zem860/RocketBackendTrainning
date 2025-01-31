using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;
using static Yacht.ProjectHelper;



namespace Yacht
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void addUser(object sender, EventArgs e)
        {
            ProjectHelper helper = new ProjectHelper();
            bool validPwd = helper.checkPassword(Password.Text);
            if (!validPwd)
            {
                Error.Visible = true;
                Error.Text = "密碼須符合大寫、小寫、數字、特殊字符，且長度至少 8 個字符";
                return;

            }
            string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
            string checkUserExist = @"SELECT COUNT(*) FROM Admins WHERE Account =@account";
            int existAccount;
            string addAdmin = @"INSERT INTO Admins (Account, HashPwd, Salt) VALUES (@account, @password, @salt)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(checkUserExist, connection);
                cmd.Parameters.AddWithValue(@"account", Account.Text);
                existAccount = (int)cmd.ExecuteScalar();
                if (existAccount!=0)
                {
                    Error.Text = "This Account Already Exists";
                    Error.Visible = true;
                    Account.Text = "";
                    Password.Text = "";
                    return;
                }
            }
            if (existAccount == 0)
            {
                byte[] salt = helper.CreateSalt(16);
                string saltForDb = Convert.ToBase64String(salt);
                string hashPassword = Convert.ToBase64String(helper.HashPassword(Password.Text, salt));
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(addAdmin, connection);
                    cmd.Parameters.AddWithValue(@"account", Account.Text);
                    cmd.Parameters.AddWithValue(@"password", hashPassword);
                    cmd.Parameters.AddWithValue(@"salt", saltForDb);
                    cmd.ExecuteNonQuery();
                }
                Response.Write("~/Register.aspx");
            }
            
        }
    }
}