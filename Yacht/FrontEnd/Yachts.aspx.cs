using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

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
                getBreadCrumb(model, pos);
                getReaptPhotos();
                ShipName.Text = Request.QueryString["model"];
            }
        }

        public void getBreadCrumb(string model, string pos)
        {
            breadCrumbText.Text = model;
            breadCrumb.NavigateUrl = $"~/FrontEnd/Yachts.aspx?model={model}&pos={pos}";
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
            string query = @"SELECT ImgPath As Imgs FROM YachtImgs WHERE YachtId = @id ORDER BY Cover Desc";
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
               YachtsDesign.DesignType AS DesignTag           
        FROM YachtsModel
        INNER JOIN YachtsDesign ON YachtsDesign.Id = YachtsModel.DesignId

";

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
            string newTag="";
            switch (isNew)
            {
                case "New Building":
                    newTag = " (New Building)";
                    break;
                case "New Design":
                    newTag = " (New Design)";
                    break;
                default:
                    newTag = "";
                    break;
            }

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

        public void getDeckPlanImg()
        {
            string id = getId();
            string query = @"SELECT Id, ImgPath FROM LayoutImg WHERE YachtId = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                DeckPlan.DataSource = reader;
                DeckPlan.DataBind();    


            }
        }

        public void getOverviewText()
        {

            string query = @"SELECT Text FROM OverviewText WHERE YachtId = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", getId());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string contentFromDb = HttpUtility.HtmlDecode(reader["Text"]?.ToString() ?? "");
                    Literal1.Text = HttpUtility.HtmlDecode(contentFromDb); // 用 Literal 設定 HTML
                }
                else
                {
                    Literal1.Text = "";
                }


            }
        }
        public void getDimensions()
        {
            string query = "SELECT DimensionDetails FROM OverviewDimensions WHERE YachtId = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", getId());

                var result = cmd.ExecuteScalar()?.ToString(); // 取出 JSON

                Dictionary<string, string> dimensions;
                if (string.IsNullOrEmpty(result))
                {
                    dimensions = new Dictionary<string, string>(); // 若 JSON 為 null，則回傳空字典
                }
                else
                {
                    try
                    {
                        dimensions = JsonConvert.DeserializeObject<Dictionary<string, string>>(result) ?? new Dictionary<string, string>();
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine("JSON 解析錯誤: " + ex.Message);
                        dimensions = new Dictionary<string, string>(); // 若 JSON 格式錯誤，避免錯誤
                    }
                }

                // 轉換 Dictionary 為 DataTable
                DataTable dt = new DataTable();
                dt.Columns.Add("Key");
                dt.Columns.Add("Value");

                foreach (var kvp in dimensions)
                {
                    dt.Rows.Add(kvp.Key, kvp.Value);
                }

                // 綁定到 GridView
                DimensionRepeater.DataSource = dt;
                DimensionRepeater.DataBind();
            }
        }
        protected void SetActiveView(string pos)
        {
            switch (pos)
            {
                case "overview":
                    MultiView1.SetActiveView(Overview);
                    getOverviewText();
                    getDimensions();
                    break;
                case "layout":
                    MultiView1.SetActiveView(Layout);
                    getDeckPlanImg();
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