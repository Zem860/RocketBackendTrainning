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
using Yacht.BackEnd;
namespace Yacht.FrontEnd
{
    public partial class Yachts : System.Web.UI.Page
    {

        public class SpecData
        {
            public string Title { get; set; }
            public List<string> Details { get; set; }
        }

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
                getFiles();
                ShipName.Text = Request.QueryString["model"];
            }
        }

        public void getFiles()
        {
            string query = @"SELECT FileName FROM OverviewFiles WHERE YachtId = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", getId());

                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows) // 不消耗 reader，只檢查是否有資料
                {
                    fileBox.Visible = false;
                }
                else
                {
                    FileRepeater.DataSource = reader;
                    FileRepeater.DataBind();
                }
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
                if (reader.Read())
                {

                    curId = reader["Id"].ToString();

                }
                else
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
            string newTag = "";
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

                if (reader.Read())
                {
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

        public void getSailPlanImg()
        {
            string query = "SELECT DimensionSailImg FROM OverviewImg WHERE YachtId = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"Id", getId());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (String.IsNullOrEmpty(reader["DimensionSailImg"].ToString()))
                    {
                        imgsection.Visible = false;
                    }
                    else
                    {
                        imgsection.Visible = true;
                        SailPlanImg.ImageUrl = reader["DimensionSailImg"].ToString();

                    }
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

        //public void getSpecs1()
        //{
        //    string query = @"
        //SELECT st.SpecType AS Title, sd.Detail 
        //FROM SpecificationType st 
        //JOIN SpecDetails sd ON st.Id = sd.SpecId 
        //WHERE YachtId = @id 
        //ORDER BY sd.CreatedAt;";

        //    Dictionary<string, List<string>> specs = new Dictionary<string, List<string>>();

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    using (SqlCommand cmd = new SqlCommand(query, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@id", getId());
        //        conn.Open();
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                string title = reader["Title"].ToString();
        //                string detail = reader["Detail"].ToString();

        //                if (!specs.ContainsKey(title))
        //                {
        //                    specs[title] = new List<string>();
        //                }

        //                specs[title].Add(detail);
        //            }
        //        }
        //    }

        //    // 轉換成 List<dynamic> 來綁定 Repeater
        //    var specList = specs.Select(kvp => new { Title = kvp.Key, Details = kvp.Value }).ToList();
        //    SpecRepeater.DataSource = specList;
        //    SpecRepeater.DataBind();
        //}

        public void getSpec2()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT SpecContent FROM Specification2 WHERE YachtId = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", getId());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // 從 reader 中取得 SpecContent 欄位的資料，並轉換成字串
                    Literal2.Text = reader["SpecContent"].ToString();
                }
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
                    getSailPlanImg();
                    break;
                case "layout":
                    MultiView1.SetActiveView(Layout);
                    getDeckPlanImg();
                    break;
                case "spec":
                    MultiView1.SetActiveView(Spec);
                    //getSpecs1();
                    getSpec2();
                    break;
                default:
                    MultiView1.SetActiveView(Overview);

                    break;
            }
        }
    }


}