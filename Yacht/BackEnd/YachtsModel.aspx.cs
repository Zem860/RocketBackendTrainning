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
    public partial class YachtsModel : System.Web.UI.Page
    {

        public class YachtModel
        {
            public int Id { get; set; }
            public string YachtName { get; set; } // 船名 (去掉數字)
            public string Model { get; set; } // 只保留數字型號
        }
        protected string connectionString = WebConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // 確保只有首次載入時執行
            {
                getModel();
            }
        }


        private string GetModelName(string model)
        {
            int lastSpaceIndex = model.LastIndexOf(' ');
            return (lastSpaceIndex != -1) ? model.Substring(0, lastSpaceIndex) : model;
        }
        private string GetModelNumber(string model)
        {
            int lastSpaceIndex = model.LastIndexOf(' ');
            return (lastSpaceIndex != -1) ? model.Substring(lastSpaceIndex + 1) : "";
        }
        public void getModel()
        {
            string query = "SELECT Id, Model FROM YachtsModel";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                List<YachtModel> yachts = new List<YachtModel>();

                while (reader.Read())
                {
                    string fullModel = reader["Model"].ToString().Trim(); // 取得完整名稱
                    string yachtName = GetModelName(fullModel); // 取得名稱部分
                    string modelNumber = GetModelNumber(fullModel); // 取得型號部分

                    yachts.Add(new YachtModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        YachtName = yachtName,   // 只保留船名
                        Model = modelNumber      // 只保留數字型號
                    });
                }

                reader.Close(); // 關閉 reader，防止資料庫連線佔用
                YachtsGridView.DataSource = yachts;
                YachtsGridView.DataBind();
            }
        }

        protected void YachtsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            YachtsGridView.EditIndex = e.NewEditIndex;
            getModel();
        }

        protected void YachtsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            YachtsGridView.EditIndex = -1;
            getModel();
        }

        protected void YachtsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(YachtsGridView.DataKeys[e.RowIndex].Value);
            TextBox modelname = (TextBox)YachtsGridView.Rows[e.RowIndex].FindControl("NameText");

            TextBox modelmodel = (TextBox)YachtsGridView.Rows[e.RowIndex].FindControl("ModelText");
            string query = @"UPDATE YachtsModel SET Model = @model WHERE Id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"model", modelname.Text + " " + modelmodel.Text);
                cmd.Parameters.AddWithValue(@"yachtName", modelmodel.Text);
                cmd.Parameters.AddWithValue(@"id", id);
                cmd.ExecuteNonQuery();
                YachtsGridView.EditIndex = -1;
                getModel();
            }
        }

        protected void YachtsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(YachtsGridView.DataKeys[e.RowIndex].Value);
            string query = @"DELETE FROM YachtsModel WHERE Id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue(@"id", id);
                cmd.ExecuteNonQuery();
            }
            getModel();
        }
    }
}