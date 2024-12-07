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
    public partial class HW3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string result = getJsonChunk("https://file.notion.so/f/f/50d1ed12-2c0e-4192-ba1a-6d1fd846f4b2/513bf788-333f-445f-963b-58316671e1c5/Realtime.json?table=block&id=64731531-1246-452e-a4f1-1e366a29e20b&spaceId=50d1ed12-2c0e-4192-ba1a-6d1fd846f4b2&expirationTimestamp=1733558400000&signature=SuCUdVNRYRvZq7YHkgYsSkKPh8DSj-UHneHuJOb7EeY&downloadName=Realtime.json");
            Car[] data = JsonConvert.DeserializeObject<Car[]>(result);


            StringBuilder form = new StringBuilder();
            form.AppendLine("<table>");
            form.AppendLine("<thead>");
            form.AppendLine("<tr>");
            form.AppendLine("<th rowspan=\"2\">PlatNum</th>");
            form.AppendLine("<th rowspan=\"2\">OperatorID</th>");
            form.AppendLine("<th rowspan=\"2\">OperatorNo</th>");
            form.AppendLine("<th rowspan=\"2\">RouteUID</th>");
            form.AppendLine("<th rowspan=\"2\">RouteID</th>");
            form.AppendLine("<th colspan=\"2\">RouteName</th>");
            form.AppendLine("<th rowspan=\"2\">SubRouteUID</th>");
            form.AppendLine("<th rowspan=\"2\">SubRouteID</th>");
            form.AppendLine("<th colspan=\"2\">SubRouteName</th>");
            form.AppendLine("<th rowspan=\"2\">Direction</th>");
            form.AppendLine("<th rowspan=\"2\">StopUID</th>");
            form.AppendLine("<th rowspan=\"2\">StopID</th>");
            form.AppendLine("<th colspan=\"2\">StopName</th>");
            form.AppendLine("<th rowspan=\"2\">StopSequence</th>");
            form.AppendLine("<th rowspan=\"2\">MessageType</th>");
            form.AppendLine("<th rowspan=\"2\">DutyStatus</th>");
            form.AppendLine("<th rowspan=\"2\">BusStatus</th>");
            form.AppendLine("<th rowspan=\"2\">A2EventType</th>");
            form.AppendLine(" <th rowspan=\"2\">GPSTime</th>");
            form.AppendLine("<th rowspan=\"2\">SrcRecTime</th>");
            form.AppendLine("<th rowspan=\"2\">SrcTransTime</th>");
            form.AppendLine("<th rowspan=\"2\">UpdateTime</th>");
            form.AppendLine("</tr>");
            form.AppendLine("<tr>");
            form.AppendLine("<th>Zh_tw</th>");
            form.AppendLine("<th>En</th>");
            form.AppendLine("<th>Zh_tw</th>");
            form.AppendLine("<th>En</th>");
            form.AppendLine("<th>Zh_tw</th>");
            form.AppendLine("<th>En</th>");
            form.AppendLine("</tr>");
            form.AppendLine("</thead>");
            form.AppendLine("<tbody>");
            foreach (var d in data)
            {
                form.AppendLine("<tr>");
                form.AppendLine($"<td>{d.PlateNumb}</td>");
                form.AppendLine($"<td>{d.OperatorID}</td>");
                form.AppendLine($"<td>{d.OperatorNo}</td>");
                form.AppendLine($"<td>{d.RouteUID}</td>");
                form.AppendLine($"<td>{d.RouteID}</td>");
                form.AppendLine($"<td>{d.RouteName.Zh_tw}</td>");
                form.AppendLine($"<td>{d.RouteName.En}</td>");
                form.AppendLine($"<td>{d.SubRouteUID}</td>");
                form.AppendLine($"<td>{d.SubRouteID}</td>");
                form.AppendLine($"<td>{d.SubRouteName.Zh_tw}</td>");
                form.AppendLine($"<td>{d.SubRouteName.En}</td>");
                form.AppendLine($"<td>{d.Direction}</td>");
                form.AppendLine($"<td>{d.StopUID}</td>");
                form.AppendLine($"<td>{d.StopID}</td>");
                form.AppendLine($"<td>{d.StopName.Zh_tw}</td>");
                form.AppendLine($"<td>{d.StopName.En}</td>");
                form.AppendLine($"<td>{d.StopSequence}</td>");
                form.AppendLine($"<td>{d.MessageType}</td>");
                form.AppendLine($"<td>{d.DutyStatus}</td>");
                form.AppendLine($"<td>{d.BusStatus}</td>");
                form.AppendLine($"<td>{d.A2EventType}</td>");
                form.AppendLine($"<td>{d.GPSTime}</td>");
                form.AppendLine($"<td>{d.SrcRecTime}</td>");
                form.AppendLine($"<td>{d.SrcTransTime}</td>");
                form.AppendLine($"<td>{d.UpdateTime}</td>");
                form.AppendLine($"</tr>");
            }



            string tabelEnd = $"<tbody>" +
                $"</tbody>" +
                $"</table>";



            string headContent = "";

            Response.Write(data.Length);
            Response.Write(form.ToString());



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

    public class RO
    {
        public Car[] Property1 { get; set; }
    }
    public class Car
    {
        public string PlateNumb { get; set; }
        public string OperatorID { get; set; }
        public string OperatorNo { get; set; }
        public string RouteUID { get; set; }
        public string RouteID { get; set; }
        public Routename RouteName { get; set; }
        public string SubRouteUID { get; set; }
        public string SubRouteID { get; set; }
        public Subroutename SubRouteName { get; set; }
        public int Direction { get; set; }
        public string StopUID { get; set; }
        public string StopID { get; set; }
        public Stopname StopName { get; set; }
        public int StopSequence { get; set; }
        public int MessageType { get; set; }
        public int DutyStatus { get; set; }
        public int BusStatus { get; set; }
        public int A2EventType { get; set; }
        public DateTime GPSTime { get; set; }
        public DateTime SrcRecTime { get; set; }
        public DateTime SrcTransTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    public class Routename
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }

    public class Subroutename
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }
    public class Stopname
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }

}









