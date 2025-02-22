using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yacht.BackEnd
{
    public partial class AddYachtSpec : System.Web.UI.Page
    {
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                defaultDataBind();
            }
        }

        public void defaultDataBind()
        {
            YachtDropDown.DataBind();  // 確保 DropDownList 綁定
            if (YachtDropDown.Items.Count > 0) // 確保有數據
            {
                YachtDropDown.SelectedIndex = 0; // 選擇第一個
                getSpecType();
            }
        }

        protected void addSpecType(object sender, EventArgs e)
        {
            string query = @"INSERT INTO SpecificationType (SpecType, YachtId) VALUES (@spectype, @yachtId)";
            string id = YachtDropDown.SelectedValue;
            string spectype = SpecType.Text;
            using (SqlConnection connection = new SqlConnection(connectionString)) { 
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"spectype", spectype);
                cmd.Parameters.AddWithValue(@"yachtId", id);
                cmd.ExecuteNonQuery();         
            }
            getSpecType();
        }

        public void getSpecType()
        {
            string id = YachtDropDown.SelectedValue;
            string query = @"SELECT Id, SpecType, YachtId FROM SpecificationType WHERE yachtId = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                SpecHeadGridView.DataSource = reader;
                SpecHeadGridView.DataBind();

            }
                
        }

        protected void YachtDropDown_TextChanged(object sender, EventArgs e)
        {
            getSpecType();
        }

        protected void SpecHeadGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            SpecHeadGridView.EditIndex = e.NewEditIndex;
            getSpecType(); // 重新載入資料，讓選中的行進入編輯模式

        }

        protected void SpecHeadGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            SpecHeadGridView.EditIndex = -1;
            getSpecType(); // 重新載入，恢復原來的狀態
        }

        protected void SpecHeadGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // 取得 ID
            int id = Convert.ToInt32(SpecHeadGridView.DataKeys[e.RowIndex].Value);

            // 取得編輯後的 SpecType
            TextBox txtSpecType = (TextBox)SpecHeadGridView.Rows[e.RowIndex].FindControl("txtSpecType");
            string newSpecType = txtSpecType.Text;

            string query = "UPDATE SpecificationType SET SpecType = @specType, UpdatedAt = GETDATE() WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@specType", newSpecType);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            SpecHeadGridView.EditIndex = -1; // 離開編輯模式
            getSpecType(); // 重新載入數據
        }
        protected void SpecHeadGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(SpecHeadGridView.DataKeys[e.RowIndex].Value);
            string query = "DELETE FROM SpecificationType WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            getSpecType(); // 重新載入數據
        }
    }

}

   