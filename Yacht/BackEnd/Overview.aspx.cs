using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Yacht.BackEnd
{

    public partial class Overview : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDropDown();
                getOverviewText();
                getDimensions();
            }
        }

        public void getDropDown()
        {
            string query = @"SELECT Id, Model FROM YachtsModel";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                YachtModel.DataSource = reader;
                YachtModel.DataTextField = "Model";  // 設定 Model 為顯示的名稱
                YachtModel.DataValueField = "Id";    // 設定 Id 為選擇的值
                YachtModel.DataBind();
            }
        }

        public void addOverviewText()
        {
            string editorContent = Request.Unvalidated.Form["editor1"];
            string query = @"UPDATE OverviewText SET Text = @text WHERE YachtId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", editorContent);
                cmd.ExecuteNonQuery();
            }
        }
        public void getOverviewText()
        {

            string query = @"SELECT Text FROM OverviewText WHERE YachtId = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", YachtModel.SelectedValue);
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

        protected void YachtModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            getOverviewText();
            getDimensions();
        }

        protected void addOverviewText(object sender, EventArgs e)
        {
            string editorContent = Request.Unvalidated.Form["editor1"];
            string query = @"
        IF EXISTS (SELECT 1 FROM OverviewText WHERE YachtId = @id)
            UPDATE OverviewText SET Text = @text WHERE YachtId = @id
        ELSE
            INSERT INTO OverviewText (YachtId, Text) VALUES (@id, @text)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", YachtModel.SelectedValue);
                cmd.Parameters.AddWithValue(@"text", editorContent);
                cmd.ExecuteNonQuery();
            }
        }


        private Dictionary<string, string> getDimension(string yachtId)
        {
            string query = "SELECT DimensionDetails FROM OverviewDimensions WHERE YachtId = @YachtId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@YachtId", yachtId);
                    var result = cmd.ExecuteScalar()?.ToString(); // 確保 `null` 轉換成 `string`

                    // 如果結果為 null 或空字串，則回傳空的 Dictionary
                    if (string.IsNullOrEmpty(result))
                    {
                        return new Dictionary<string, string>();
                    }

                        return JsonConvert.DeserializeObject<Dictionary<string, string>>(result) ?? new Dictionary<string, string>();
                   
                }
            }
        }

        protected void submitDimension(object sender, EventArgs e)
        {
            string title = dimensionTitle.Text.Trim();     // 前端輸入的標題 (key)
            string content = dimensionContent.Text.Trim(); // 前端輸入的內容 (value)
            string id = YachtModel.SelectedValue;
            Dictionary<string, string> dimensions = getDimension(id);
            dimensions[title] = content;
            string json = JsonConvert.SerializeObject(dimensions, Formatting.Indented);
            updateDimensionDetails(YachtModel.SelectedValue, json);
        }

        public void getDimensions()
        {
            string query = "SELECT DimensionDetails FROM OverviewDimensions WHERE YachtId = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", YachtModel.SelectedValue);

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
                DimensionGridView.DataSource = dt;
                DimensionGridView.DataBind();
            }
        }


        public bool checkEmpty(string yachtid)
        {
            int count;
            string query = "SELECT COUNT(*) FROM OverviewDimensions WHERE YachtId = @YachtId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue(@"YachtId", yachtid);
                count = Convert.ToInt32(cmd.ExecuteScalar());
                
            }
            if (count == 0)
            {
                return true;
            } else
            {
                return false;
            }
            
        }

        private void updateDimensionDetails(string yachtId, string json)
        {
            string query = @"
        MERGE INTO OverviewDimensions AS target
        USING (SELECT @YachtId AS YachtId, @Json AS Json) AS source
        ON target.YachtId = source.YachtId
        WHEN MATCHED THEN
            UPDATE SET DimensionDetails = source.Json
        WHEN NOT MATCHED THEN
            INSERT (YachtId, DimensionDetails) VALUES (source.YachtId, source.Json);";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@YachtId", yachtId);
                    cmd.Parameters.AddWithValue("@Json", json);
                    cmd.ExecuteNonQuery();
                }
            }

            getDimensions();
        }


        protected void DimensionGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DimensionGridView.EditIndex = -1;
            getDimensions(); // 重新載入資料
        }

        protected void DimensionGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DimensionGridView.EditIndex = e.NewEditIndex;
            getDimensions(); // 重新綁定資料
        }


        protected void DimensionGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // 取得原始 Key（DataKeys 確保 Key 唯一）
            string oldKey = DimensionGridView.DataKeys[e.RowIndex].Value.ToString();

            // 取得新的 Key 和 Value
            TextBox txtKey = (TextBox)DimensionGridView.Rows[e.RowIndex].FindControl("txtKey");
            TextBox txtValue = (TextBox)DimensionGridView.Rows[e.RowIndex].FindControl("txtValue");

            string newKey = txtKey.Text.Trim();
            string newValue = txtValue.Text.Trim();

            // 取得目前存的 JSON (Dictionary)
            string yachtId = YachtModel.SelectedValue;
            Dictionary<string, string> dimensions = getDimension(yachtId);

            // 確保 Key 不能為空
            if (string.IsNullOrEmpty(newKey))
            {
                // 這裡可以用 Label 顯示錯誤訊息
                Console.WriteLine("Key 不能為空！");
                return;
            }

            // 如果 Key 改變了，需要刪除舊 Key 並插入新 Key
            if (oldKey != newKey)
            {
                // 確保新 Key 不重複
                if (dimensions.ContainsKey(newKey))
                {
                    Console.WriteLine("新 Key 已存在，請使用不同的名稱！");
                    return;
                }

                // 刪除舊 Key，插入新 Key
                dimensions.Remove(oldKey);
                dimensions[newKey] = newValue;
            }
            else
            {
                // 如果 Key 沒變，則只更新 Value
                dimensions[oldKey] = newValue;
            }

            // 轉換為 JSON
            string json = JsonConvert.SerializeObject(dimensions, Formatting.Indented);

            // 更新到資料庫
            updateDimensionDetails(yachtId, json);

            // 取消編輯模式
            DimensionGridView.EditIndex = -1;

            // 重新綁定 GridView，顯示更新後的資料
            getDimensions();
        }

        protected void DimensionGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // 取得 Key（DataKeys 確保 Key 唯一）
            string keyToDelete = DimensionGridView.DataKeys[e.RowIndex].Value.ToString();

            // 取得目前存的 JSON (Dictionary)
            string yachtId = YachtModel.SelectedValue;
            Dictionary<string, string> dimensions = getDimension(yachtId);

            // 如果 Key 存在則移除
            if (dimensions.ContainsKey(keyToDelete))
            {
                dimensions.Remove(keyToDelete);
            }

            // 轉換為 JSON
            string json = JsonConvert.SerializeObject(dimensions, Formatting.Indented);

            // 更新到資料庫
            updateDimensionDetails(yachtId, json);

            // 重新綁定 GridView，顯示更新後的資料
            getDimensions();
        }


    }

}