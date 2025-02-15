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
    public partial class Yachts : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected string defaultModel = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // 避免回傳時重置 View
            {
                getModels();
                string model = Request.QueryString["model"];
                string pos = Request.QueryString["pos"];
                if (string.IsNullOrEmpty(pos))
                {
                    getDefaultList();
                    pos = "overview"; // 預設顯示 overview
                    model = defaultModel;
                    Response.Redirect($"~/FrontEnd/Yachts.aspx?model={model}&pos=overview");
                    return; // 確保導向後不繼續執行
                }
                btnOverview.NavigateUrl = $"~/FrontEnd/Yachts.aspx?model={model}&pos=overview";
                btnLayout.NavigateUrl = $"~/FrontEnd/Yachts.aspx?model={model}&pos=layout";
                btnSpec.NavigateUrl = $"~/FrontEnd/Yachts.aspx?model={model}&pos=spec";
                SetActiveView(pos);
                
            }
        }

        public void getModels()
        {
            string query = @"SELECT Model FROM YachtsModel";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                ModelRepeater.DataSource = reader;
                ModelRepeater.DataBind();

            }
        }

        public void getDefaultList()
        {
            string query = @"SELECT TOP 1 Model FROM YachtsModel";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) {
                    defaultModel = reader["Model"].ToString();
                }
            }
        }

        protected void SetActiveView(string pos)
        {
            switch (pos)
            {
                case "overview":
                    MultiView1.SetActiveView(Overview);
                    break;
                case "layout":
                    MultiView1.SetActiveView(Layout);
                    break;
                case "spec":
                    MultiView1.SetActiveView(Spec);
                    break;
                default:
                    MultiView1.SetActiveView(Overview);
                    break;
            }
        }
    }

  
    }