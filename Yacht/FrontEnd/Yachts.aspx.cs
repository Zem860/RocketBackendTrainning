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
                getReaptPhotos();
            }
        }

        public string getId()
        {
            string query = @"SELECT Id FROM YachtsModel WHERE Model = @model";
            string curId;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"model", Request.QueryString["model"]);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) {

                    curId = reader["Id"].ToString();
                
                } else
                {
                    curId = "0";
                }

            }
            return curId;
        }

        public void getReaptPhotos()
        {
            string query = @"SELECT ImgPath As Imgs FROM YachtImgs WHERE YachtId = @id";
            string curId = getId();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", curId);
                SqlDataReader reader = cmd.ExecuteReader();
                ShipImagesRepeater.DataSource = reader;
                ShipImagesRepeater.DataBind();
            }
        }

        public void getModels()
        {
            string query = @"
        SELECT YachtsModel.Model AS Model, 
               YachtsModel.isNew AS DesignTag           
        FROM YachtsModel";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    ModelRepeater.DataSource = reader;
                    ModelRepeater.DataBind();
                }
            }
        }

        protected string filterType(object isNew)
        {
            string newTag = Convert.ToInt32(isNew) == 1 ? " (New Building)" : "";

            return newTag; // 如果 `isNew = 1`，則顯示 `(New)`
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