using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Recaptcha;

namespace Yacht
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void checkRobot(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(RecaptchaWidget1.Response))
            {
                Label1.Visible = true;

                Label1.Text = "Captcha cannot be empty.";
            }
            else
            {
                var result = RecaptchaWidget1.Verify();
                if (result.Success)
                {
                    Response.Redirect("Contact.aspx");
                }
                else
                {
                    Label1.Text = "Error(s): ";
                    foreach (var err in result.ErrorCodes)
                    {
                        Label1.Text = Label1.Text + err;
                    }
                }
            }
        }
    }
}