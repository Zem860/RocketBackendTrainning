using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.BackEnd
{
    public partial class Dashboard1 : System.Web.UI.MasterPage
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    //權限關門判斷 (Cookie)
        //    if (!HttpContext.Current.User.Identity.IsAuthenticated)
        //    {
        //        Response.Redirect("Login.aspx"); //導回登入頁
        //    }
        //    else
        //    {

        //        FormsIdentity identity = HttpContext.Current.User.Identity as FormsIdentity;
        //        FormsAuthenticationTicket ticket = identity.Ticket;

        //        // 從票證中取得儲存的 UserData (這裡就是使用者帳號)
        //        string userAccount = ticket.UserData;

        //        // 將使用者帳號顯示在 Label 上
        //        UserName.Text = userAccount;
        //    }

        //}

        //protected void Logout_Click(object sender, EventArgs e)
        //{
        //    // 清除 Forms 認證的 Cookie
        //    FormsAuthentication.SignOut();

        //    // 清除 Session
        //    Session.Clear();
        //    Session.Abandon();

        //    // 清除認證 Cookie
        //    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "")
        //    {
        //        Expires = DateTime.Now.AddDays(-1), // 立即過期
        //        HttpOnly = true
        //    };
        //    Response.Cookies.Add(authCookie);

        //    // 重新導向回登入頁
        //    Response.Redirect("~/Login.aspx");
        //}
    }
}