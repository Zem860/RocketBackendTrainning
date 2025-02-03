using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Yacht.DbHelper;
namespace Yacht.BackEnd
{
    public partial class Dealers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            show();
        }

        public void show()
        {
            DbHelper helper = new DbHelper();
            string query = @"SELECT Com.Id AS Id, Com.CompnayName AS CName, Cou.CountryName As CountryName, D.DealerName AS DName, D.DealerPhoto AS DPhoto, D.DealerEmail AS DEmail, Com.City AS City, Com.Address AS Address, Com.Phone AS Phone, Com.Email AS CompanyEmail
                FROM Companies Com
                INNER JOIN Countries Cou ON Com.CountryId = Cou.Id
                INNER JOIN Dealers D ON Com.DealerId = D.Id";
            //string query = @"SELECT Id, DealerName AS DealerName, DealerPhoto, DealerEmail, DealerGender FROM Dealers";
            DataTable dt = helper.readData(query);
            DealersGrid.DataSource = dt;
            DealersGrid.DataBind();
            
        }
    }
}