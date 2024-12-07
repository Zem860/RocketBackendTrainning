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
            string url = "https://file.notion.so/f/f/50d1ed12-2c0e-4192-ba1a-6d1fd846f4b2/c776e4d3-d63b-4856-b1a0-14c4e66c03bc/Route.json?table=block&id=95c34c4a-2511-429f-869d-d4848e4a6e43&spaceId=50d1ed12-2c0e-4192-ba1a-6d1fd846f4b2&expirationTimestamp=1733637600000&signature=Yb7tQVagfFseC6xT-C9NcjMVUBsHuoi5JsIhn5ZBCc8&downloadName=Route.json";
            string content = getJsonChunk(url);
            Class1[] data = JsonConvert.DeserializeObject<Class1[]>(content);
            string head1 = $"<table> <thead>" +
                $"<tr><th rowspan=\"3\">RouteUID</th>" +
                $"<th rowspan=\"3\">RouteID</th><" +
                $"th rowspan=\"3\">HashRoutes</th>" +
                $"<th colspan=\"3\">Operators</th>" +
                $"<th rowspan=\"3\">OperatorCode</th>" +
                $"<th rowspan=\"3\">OperatorNo</th>" +
                $"<th rowspan=\"3\">AuthorityID</th>" +
                $"<th rowspan=\"3\">ProviderID</th>" +

                $"<th colspan=\"7\">SubRoutes</th> " +
                $"<th colspan=\"7\">SubRoutes</th> " +
                $"<th rowspan=\"3\">BusRouteType</th>" +
                $" <th colspan=\"2\">RouteName</th> " +
                $"<th rowspan=\"3\">DepartureStopNameZh</th>" +
                $" <th rowspan=\"3\">DepartureStopNameEn</th>" +
                $"<th rowspan=\"3\">DestinationStopNameZh</th>" +
                $"<th rowspan=\"3\">DestinationStopNameEn</th>" +
                $"<th rowspan=\"3\">RouteMapImageUrl</th>" +
                $"<th rowspan=\"3\">City</th>" +
                $"<th rowspan=\"3\">CityCode</th>" +
                $"<th rowspan=\"3\">UpdateTime</th>" +
                $"<th rowspan=\"3\">VersionID</th>" +
                $"</tr>" +
                $"<tr>" +
                $"<th rowspan=\"2\">OperatorID</th>" +
                $"<th colspan=\"2\">OperatorName</th>" +
                $"<th rowspan=\"2\">SubRouteUID</th>" +
                $"<th rowspan=\"2\">SubRouteID</th>" +
                $"<th rowspan=\"2\">OperatorIDs</th>" +
                $"<th colspan=\"2\">SubRouteName</th>" +
                $"<th rowspan=\"2\">Headsign</th>" +
                $"<th rowspan=\"2\">Direction</th>" +
                $"<th rowspan=\"2\">SubRouteUID</th>" +
                $"<th rowspan=\"2\">SubRouteID</th>" +
                $"<th rowspan=\"2\">OperatorIDs</th>" +
                $"<th colspan=\"2\">SubRouteName</th>" +
                $"<th rowspan=\"2\">Headsign</th>" +
                $"<th rowspan=\"2\">Direction</th>"+
                $" <th rowspan=\"2\">Zh_tw</th>" +
                $"<th rowspan=\"2\">En</th>" +
                $" </tr>" +
                $"<tr>" +
                $"<th>Zh_tw</th>" +
                $"<th>En</th>" +
                $" <th>Zh_tw</th>" +
                $"<th>En</th>" +
                $"<th>Zh_tw</th>" +
                $"<th>En</th>" +
                $"</tr>" +
                $"</thead>";
            string body = "<tbody>";
            string bodyContent = "";
            string subCate = "";

            foreach (Class1 d in data)
            {
                bodyContent +=
                    "<tr>" +
                    $"<td>{d.RouteUID}</td>" +
                    $"<td>{d.RouteID}</td>" +
                    $"<td>{d.HasSubRoutes}</td>" +
                    $"<td>{d.Operators[0].OperatorID}</td>" +
                    $"<td > {d.Operators[0].OperatorName.Zh_tw}</td>" +
                    $"<td >{d.Operators[0].OperatorName.En}</td>" +
                    $"<td>{d.Operators[0].OperatorCode}</td>" +
                    $" <td>{d.Operators[0].OperatorNo}</td>" +
                    $"<td>{d.AuthorityID}</td>" +
                     $"<td>{d.ProviderID}</td>" +
                    $"<td>{d.SubRoutes[0].SubRouteUID}</td>" +
                    $"<td>{d.SubRoutes[0].SubRouteID}</td>" +
                    $"<td>{d.SubRoutes[0].OperatorIDs[0]} </td>" +
                   $"<td>{d.SubRoutes[0].SubRouteName.Zh_tw}</td>" +
                    $"<td>{d.SubRoutes[0].SubRouteName.En}</td>" +
                    $" <td>{d.SubRoutes[0].Headsign}</td>" +
                    $"<td>{d.SubRoutes[0].Direction}</td>";
                if (d.SubRoutes.Length > 1)
                {
                    subCate = $"<td>{d.SubRoutes[0].SubRouteUID}</td>" +
                    $"<td>{d.SubRoutes[1].SubRouteID}</td>" +
                    $"<td>{d.SubRoutes[1].OperatorIDs[0]} </td>" +
                   $"<td>{d.SubRoutes[1].SubRouteName.Zh_tw}</td>" +
                    $"<td>{d.SubRoutes[1].SubRouteName.En}</td>" +
                    $" <td>{d.SubRoutes[1].Headsign}</td>" +
                    $"<td>{d.SubRoutes[1].Direction}</td>";
                }
                else
                {
                    subCate = $"<td>{null}</td>" +
                    $"<td>{null}</td>" +
                    $"<td>{null} </td>" +
                   $"<td>{null}</td>" +
                    $"<td>{null}</td>" +
                    $" <td>{null}</td>" +
                    $"<td>{null}</td>";
                }
                bodyContent += subCate;
                bodyContent += $"<td>{d.BusRouteType}</td>" +
                    $"<td>{d.RouteName.Zh_tw}</td>" +
                    $"<td>{d.RouteName.En}</td>" +
                    $"<td>{d.DepartureStopNameZh}</td>" +
                    $"<td>{d.DepartureStopNameEn}</td>" +
                    $"<td>{d.DestinationStopNameZh}</td>" +
                    $"<td>{d.DestinationStopNameEn}</td>" +
                    $"<td>{d.RouteMapImageUrl}</td>" +
                    $"<td>{d.City}</td>" +
                    $"<td>{d.CityCode}</td>" +
                    $"<td>{d.UpdateTime}</td>" +
                    $"<td>{d.VersionID}</td>" + "</tr>";

            }
            string result = head1 + body + bodyContent + "</tbody>+</table>";
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
