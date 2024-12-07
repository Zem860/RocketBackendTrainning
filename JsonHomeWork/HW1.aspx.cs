using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace JsonHomeWork
{
    public partial class HW1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "https://www.ris.gov.tw/rs-opendata/api/v1/datastore/ODRP059/108";
            string content = getJsonChunk(url);
            Rootobject data = JsonConvert.DeserializeObject<Rootobject>(content);

            string head = "<table style='width: 100%; border-collapse: collapse; border: 1px solid black;'>" +
                          "<thead>" +
                          "<tr>" +
                          "<tde style='border: 1px solid black; padding: 8px; text-align:center'>statistic_yyy</td>" +
                          "<td style='border: 1px solid black; padding: 8px; text-align:center'>according</td>" +
                          "<td style='border: 1px solid black; padding: 8px; text-align:center'>site_id</td>" +
                          "<td style='border: 1px solid black; padding: 8px; text-align:center'>birth_sex</td>" +
                          "<td style='border: 1px solid black; padding: 8px; text-align:center'>mother_nation</td>" +
                          "<td style='border: 1px solid black; padding: 8px; text-align:center'>mother_age</td>" +
                          "<td style='border: 1px solid black; padding: 8px; text-align:center'>mother_education</td>" +
                          "<td style='border: 1px solid black; padding: 8px; text-align:center'>birth_count</td>" +
                          "</tr>" +
                          "</thead>";
            string bodyStart = "<tbody>";
            string body = "";
            string bodyEnd = "</tbody>+</table>";

            foreach (Responsedata d in data.responseData)
            {
                body +=
                    "<tr>" +
                    $"<td style='border: 1px solid black; padding: 8px; text-align:center'>{d.statistic_yyy}</td>" +
                    $"<td style='border: 1px solid black; padding: 8px; text-align:center'>{d.according}</td>" +
                    $"<td style='border: 1px solid black; padding: 8px; text-align:center'>{d.site_id}</td>" +
                    $"<td style='border: 1px solid black; padding: 8px; text-align:center'>{d.birth_sex}</td>" +
                    $"<td style='border: 1px solid black; padding: 8px; text-align:center'>{d.mother_nation}</td>" +
                    $"<td style='border: 1px solid black; padding: 8px; text-align:center'>{d.mother_age}</td>" +
                    $"<td style='border: 1px solid black; padding: 8px; text-align:center'>{d.mother_education}</td>" +
                    $"<td style='border: 1px solid black; padding: 8px; text-align:center'>{d.birth_count}</td>" +
                    "</tr>";
            }

            Response.Write(head + bodyStart + body + bodyEnd);

        }

        private string getJsonChunk(string url)
        {
            string targeturl = url;
            var request = WebRequest.Create(targeturl);
            request.ContentType = "application/json";
            var respponse = request.GetResponse();
            string result = "";
            using (StreamReader reader = new StreamReader(respponse.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

                return result;
        }
    }



    public class Rootobject
    {
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
        public string totalPage { get; set; }
        public string totalDataSize { get; set; }
        public string page { get; set; }
        public string pageDataSize { get; set; }
        public Responsedata[] responseData { get; set; }
    }

    public class Responsedata
    {
        public string statistic_yyy { get; set; }
        public string according { get; set; }
        public string site_id { get; set; }
        public string birth_sex { get; set; }
        public string mother_nation { get; set; }
        public string mother_age { get; set; }
        public string mother_education { get; set; }
        public string birth_count { get; set; }
    }

}