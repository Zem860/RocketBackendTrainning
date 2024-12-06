using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Web.Routing;

namespace JsonHomeWork
{
    public partial class HW2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "https://file.notion.so/f/f/50d1ed12-2c0e-4192-ba1a-6d1fd846f4b2/c776e4d3-d63b-4856-b1a0-14c4e66c03bc/Route.json?table=block&id=95c34c4a-2511-429f-869d-d4848e4a6e43&spaceId=50d1ed12-2c0e-4192-ba1a-6d1fd846f4b2&expirationTimestamp=1733544000000&signature=qCBiPdnuORzyJp5ZYarsNm7xs0YnJ4brU9AoI0rThxU&downloadName=Route.json";
            string content = getJsonChunk(url);
            Class1[] data = JsonConvert.DeserializeObject<Class1[]>(content);






            string head = "<table>" + " <thead>" +
                "<tr>" +
                "<th rowspan=\"2\" style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">RouteUID</th>" +
                " <th rowspan=\"2\" style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">RouteID</th>\r\n" +
                "<th rowspan=\"2\" style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">HasSubRoutes</th>\r\n" +
                "<th colspan=\"5\" style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">Operators</th>\r\n" +
                "<th colspan=\"6\" style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">SubRoutes</th>"+
                "<tr>"+
                "<th style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">OperatorID</th>"+
                "<th style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">OperatorName</th>"+
                "<th style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">OperatorCode</th>"+
                "<th style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">OperatorNo</th>"+
                "<th style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">AuthorityID</th>"+
                "<th style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">SubRouteUID</th>"+
                "<th style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">SubRouteID</th>"+
                "<th style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">OperatorIDs</th>"+
                "<th style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">SubRouteName</th>"+
                "<th style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">HeadSign</th>"+
                "<th style=\"border: 1px solid #000; padding: 8px; background-color: #f4f4f4;\">Direction</th>"
                + "</thead>"
                ;



            string body = "<tbody>" + "<tr>";
            string bodyContent="";

            foreach (Class1 d in data)
            {
                bodyContent +=
                    $"<td rowspan=\"2\" style=\"border: 1px solid #000; padding: 8px;\">{d.RouteUID}</td>" +
                    $"<td rowspan=\"2\" style=\"border: 1px solid #000; padding: 8px;\">{d.RouteID}</td>" +
                    $"<td rowspan=\"2\" style=\"border: 1px solid #000; padding: 8px;\">{d.HasSubRoutes}</td>" +
                    $"<td style=\"border: 1px solid #000; padding: 8px;\">{d.Operators[0].OperatorID}</td>" +
                    $"<td style=\"border: 1px solid #000; padding: 8px;\">" +
                    $"<table style=\"width: 100%; border-collapse: collapse;\">" +
                    $"<tr>" +
                    $"<td style=\"border: none; padding: 4px;\">Zh_tw: {d.Operators[0].OperatorName.Zh_tw}</td>" +
                    $"<tr>" +
                    $"<td style=\"border: none; padding: 4px;\">En: {d.Operators[0].OperatorName.En}</td>" +
                    $"</tr>" + "</table>" + "</td>" +
                    $"<td style=\"border: 1px solid #000; padding: 8px;\">{d.Operators[0].OperatorCode}</td>" +
                    $" <td style=\"border: 1px solid #000; padding: 8px;\">{d.Operators[0].OperatorNo}</td>" +
                    $"<td style=\"border: 1px solid #000; padding: 8px;\">{d.AuthorityID}</td>" +
                    $"<td style=\"border: 1px solid #000; padding: 8px;\">{d.SubRoutes[0].SubRouteUID}</td>" +
                    $"<td style=\"border: 1px solid #000; padding: 8px;\">{d.SubRoutes[0].SubRouteID}</td>" +
                    $"<td style=\"border: 1px solid #000; padding: 8px;\">{d.SubRoutes[0].OperatorIDs[0]} </td>" +
                    $"<td style=\"border: 1px solid #000; padding: 8px;\">" +
                    $"<table style=\"width: 100%; border-collapse: collapse;\">" +
                    "<tr>" + $"<td style=\"border: none; padding: 4px;\">Zh_tw: {d.SubRoutes[0].SubRouteName.Zh_tw}</td>" +
                    "</tr>" + "<tr>" + $"<td style=\"border: none; padding: 4px;\">En: {d.SubRoutes[0].SubRouteName.En}</td>" +
                    "</tr>" + "</table>" + "</td>" +
                    $" <td style=\"border: 1px solid #000; padding: 8px;\">{d.SubRoutes[0].Headsign}</td>" +
                    $"<td style=\"border: 1px solid #000; padding: 8px;\">{d.SubRoutes[0].Direction}</td>" +
                    " </tr></tbody>";
            }
            string result = head + body + bodyContent;
            Response.Write(result);
        }


        private string getJsonChunk(string url)
        {
            string targetUrl = url;
            var request = WebRequest.Create(targetUrl);
            request.ContentType = "application/json";
            var response = request.GetResponse();

            string text;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                text = reader.ReadToEnd();
            }

            return text;
        }
    }
}



public class Rootobject
{
    public Class1[] Property1 { get; set; }
}

public class Class1
{
    public string RouteUID { get; set; }
    public string RouteID { get; set; }
    public bool HasSubRoutes { get; set; }
    public Operator[] Operators { get; set; }
    public string AuthorityID { get; set; }
    public string ProviderID { get; set; }
    public Subroute[] SubRoutes { get; set; }
    public int BusRouteType { get; set; }
    public Routename RouteName { get; set; }
    public string DepartureStopNameZh { get; set; }
    public string DepartureStopNameEn { get; set; }
    public string DestinationStopNameZh { get; set; }
    public string DestinationStopNameEn { get; set; }
    public string RouteMapImageUrl { get; set; }
    public string City { get; set; }
    public string CityCode { get; set; }
    public DateTime UpdateTime { get; set; }
    public int VersionID { get; set; }
}

public class Routename
{
    public string Zh_tw { get; set; }
    public string En { get; set; }
}

public class Operator
{
    public string OperatorID { get; set; }
    public Operatorname OperatorName { get; set; }
    public string OperatorCode { get; set; }
    public string OperatorNo { get; set; }
}

public class Operatorname
{
    public string Zh_tw { get; set; }
    public string En { get; set; }
}

public class Subroute
{
    public string SubRouteUID { get; set; }
    public string SubRouteID { get; set; }
    public string[] OperatorIDs { get; set; }
    public Subroutename SubRouteName { get; set; }
    public string Headsign { get; set; }
    public int Direction { get; set; }
}

public class Subroutename
{
    public string Zh_tw { get; set; }
    public string En { get; set; }
}
