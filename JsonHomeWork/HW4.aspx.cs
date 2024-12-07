using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JsonHomeWork
{
    public partial class HW4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mainLink = "https://localhost:44317/HW4.aspx";
            string url = "https://iplay.sa.gov.tw/api/GymSearchAllList?$format=application/json";
            StringBuilder gymForm = new StringBuilder();

            string res = getJsonChunk(url);
            Gyms[] data = JsonConvert.DeserializeObject<Gyms[]>(res);
            string queryId = Request.QueryString["gymid"];
            bool hasQuery = queryId != null;

            if (hasQuery)
            {
                gymForm.AppendLine("<table>");
                gymForm.AppendLine("<thead>");
                gymForm.AppendLine("<tr>");
                gymForm.AppendLine("<th>GymID</th>");
                gymForm.AppendLine("<th>Address</th>");
                gymForm.AppendLine("<th>Name</th>");
                gymForm.AppendLine("<th>GymFuncList</th>");
                gymForm.AppendLine("<th>OperationTel</th>");
                gymForm.AppendLine("</tr>");
                gymForm.AppendLine("</thead>");
                gymForm.AppendLine("<tbody>");

            } else
            {
                gymForm.AppendLine("<table>");
                gymForm.AppendLine("<thead>");
                gymForm.AppendLine("<tr>");
                gymForm.AppendLine("<th>GymID</th>");
                gymForm.AppendLine("<th>Name</th>");
                gymForm.AppendLine("<th>OperationTel</th>");
                gymForm.AppendLine("<th>Address</th>");
                gymForm.AppendLine("<th>Rate</th>");
                gymForm.AppendLine("<th>RateCount</th>");
                gymForm.AppendLine("<th>Distance</th>");
                gymForm.AppendLine("<th>GymFuncList</th>");
                gymForm.AppendLine("<th>Photo1</th>");
                gymForm.AppendLine("<th>LatLng</th>");
                gymForm.AppendLine("<th>RentState</th>");
                gymForm.AppendLine("<th>OpenState</th>");
                gymForm.AppendLine("<th>Declaration</th>");
                gymForm.AppendLine("<th>LandAttrName</th>");
                gymForm.AppendLine("</tr>");
                gymForm.AppendLine("</thead>");
                gymForm.AppendLine("<tbody>");
            }

            foreach (var d in data)
            {
                if (hasQuery && queryId!= d.GymID.ToString())
                {
                    continue;
                }
                if (hasQuery)
                {
                    gymForm.AppendLine("<tr>");
                    gymForm.AppendLine($"<td><a href={mainLink}?gymid={d.GymID}>{d.GymID}</a></td>");
                    gymForm.AppendLine($"<td>{d.Address}</td>");
                    gymForm.AppendLine($"<td>{d.Name}</td>");
                    gymForm.AppendLine($"<td>{d.GymFuncList}</td>");
                    gymForm.AppendLine($"<td>{d.OperationTel}</td>");
                    gymForm.AppendLine($"</tr>");
                } else
                {
                    gymForm.AppendLine("<tr>");
                    gymForm.AppendLine($"<td><a href={mainLink}?gymid={d.GymID}>{d.GymID}</a></td>");
                    gymForm.AppendLine($"<td>{d.Name}</td>");
                    gymForm.AppendLine($"<td>{d.OperationTel}</td>");
                    gymForm.AppendLine($"<td>{d.Address}</td>");
                    gymForm.AppendLine($"<td>{d.Rate}</td>");
                    gymForm.AppendLine($"<td>{d.RateCount}</td>");
                    gymForm.AppendLine($"<td>{d.Distance}</td>");
                    gymForm.AppendLine($"<td>{d.GymFuncList}</td>");
                    gymForm.AppendLine($"<td>{d.Photo1}</td>");
                    gymForm.AppendLine($"<td>{d.LatLng}</td>");
                    gymForm.AppendLine($"<td>{d.RentState}</td>");
                    gymForm.AppendLine($"<td>{d.OpenState}</td>");
                    gymForm.AppendLine($"<td>{d.Declaration}</td>");
                    gymForm.AppendLine($"<td>{d.LandAttrName}</td>");
                    gymForm.AppendLine($"</tr>");
                } 
            }
            gymForm.AppendLine($"</tbody>");
            gymForm.AppendLine($"</table>");
            Literal1.Text = gymForm.ToString();            
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
