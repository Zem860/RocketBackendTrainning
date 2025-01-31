using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Yacht.ProjectHelper;

namespace Yacht.BackEnd
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckLogin(object sender, EventArgs e)
        {
            ProjectHelper helper = new ProjectHelper();
            string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
            string checkUserExist = @"SELECT * FROM Admins WHERE Account =@account";
            string salt = "";
            string hash = "";
            string userData="";
            string userId = "";
            bool foundUser = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(checkUserExist,connection);
                cmd.Parameters.AddWithValue(@"account", Account.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                   hash = reader["HashPwd"].ToString();
                   salt = reader["Salt"].ToString();
                   userId = reader["Id"].ToString();     // 安全地轉換 `Id` 為字串
                    foundUser = true;
                }

                if (foundUser)
                {
                    bool passwordMatch = VerifyHash(salt, hash, Password.Text);
                    if (passwordMatch) {
                        SetAuthenTicket(userData, userId);
                        Response.Redirect("~/BackEnd/Dashboard.aspx");               
                    } 
                }
            }

        }

        //驗證函數
        public void SetAuthenTicket(string userData, string userId)
        {
            //宣告一個驗證票
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,                        //票證的版本號碼, 用於未來可能的版本控制
                userId,                   //與票證相關的使用者名稱, 會被用來辨識是哪一個使用者的票證
                DateTime.Now,             //核發此票證時的本機日期和時間, 票證的開始時間      
                DateTime.Now.AddHours(3), //票證到期的本機日期和時間, 票證何時失效
                false,                    //是否將票證持續存放於Cookie中
                                          //如果設為 true，即使使用者關閉瀏覽器，票證也會保存在Cookie中直到到期時間。如果設為 false，票證會在瀏覽器關閉時失效。
                userData                  //要與票證一起存放的使用者特定資料
            );
            //加密驗證票
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            //建立Cookie
            HttpCookie authenticationcookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //將Cookie寫入回應
            Response.Cookies.Add(authenticationcookie);

        }


        public bool VerifyHash(string salt, string hash, string newPwd)
        {
            ProjectHelper helper = new ProjectHelper();
            byte[] checkSalt = Convert.FromBase64String(salt);
            byte[] checkHash = Convert.FromBase64String(hash);
            byte[] compareHash = helper.HashPassword(newPwd, checkSalt);
            bool isMatch = checkHash.SequenceEqual(compareHash);
            return isMatch;
        }
    }
}