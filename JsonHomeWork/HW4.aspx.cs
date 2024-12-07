using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JsonHomeWork
{
    public partial class HW4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "https://iplay.sa.gov.tw/api/GymSearchAllList?$format=application/json";
            string res = getJsonChunk(url);
            Response.Write(res);
        }

        private string getJsonChunk(string url)
        {
            string targetUrl = url;
            var request = WebRequest.Create(targetUrl);
            request.ContentType = "application/json";
            var response = request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}


public class GymData
{
    public Gyms[] Gym { get; set; }
}

public class Gyms
{
    public int GymID { get; set; }
    public string Name { get; set; }
    public string OperationTel { get; set; }
    public string Address { get; set; }
    public float Rate { get; set; }
    public int RateCount { get; set; }
    public float Distance { get; set; }
    public string GymFuncList { get; set; }
    public string Photo1 { get; set; }
    public string LatLng { get; set; }
    public string RentState { get; set; }
    public string OpenState { get; set; }
    public string Declaration { get; set; }
    public string LandAttrName { get; set; }
}
