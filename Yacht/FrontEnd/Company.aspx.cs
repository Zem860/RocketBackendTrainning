using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.FrontEnd
{
    public partial class Company : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // 只有第一次載入時才執行
            {

                SetBreadCrumb();

            }
        }


        public void SetBreadCrumb()
        {
            string pos = Request.QueryString["pos"]; // 取得 ?page=xxx
            SetActiveView(pos);
            if (String.IsNullOrEmpty(Request.QueryString["pos"]))
            {
                Layer3Label.Text = "About";
            }
            else {

                Layer3Label.Text = pos;
                Layer3Link.NavigateUrl = $"/FrontEnd/Company?pos={pos}";


            }
        }

        protected void SetActiveView(string pos)
        {
            switch (pos)
            {
                case "about":
                    MultiView1.SetActiveView(ViewAboutUs);
                    break;
                case "certificate":
                    MultiView1.SetActiveView(ViewCertificate);
                    break;
                default:
                    MultiView1.SetActiveView(ViewAboutUs);
                    break;
            }
        }

        protected void btnAbout_Click(object sender, EventArgs e)
        {
            Response.Redirect("/FrontEnd/Company?pos=about");
        }

        protected void btnCertificate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/FrontEnd/Company?pos=certificate");
        }

    }
}