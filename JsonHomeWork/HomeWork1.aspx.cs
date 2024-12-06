using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static JsonHomeWork.HomeWork1;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace JsonHomeWork
{
    public partial class HomeWork1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "https://www.ris.gov.tw/rs-opendata/api/v1/datastore/ODRP059/108";
            string content = GetJsonContent(url);
            //Response.Write(content);
            // 反序列化为 Rootobject
            //Rootobject data = JsonConvert.DeserializeObject<Rootobject>(content);

            Rootobject data = JsonConvert.DeserializeObject<Rootobject>(content);

            }
        private string GetJsonContent(string url)// 這是一個名為GetJsonContent的私有方法，它需要一個名為url的參數，返回一個string
        {
            string targeturl = url;
            // 使用WebRequest.Create方法創建一個新的WebRequest對象，該對象會向指定的URL發送請求
            var request = WebRequest.Create(targeturl);
            // 將請求的ContentType設置為"application/json: charset=utf-8"，這意味著我們期望從服務器接收JSON數據
            request.ContentType = "application/json: charset=utf-8";
            // 發送請求並獲取WebRespons對象，該對象包含了服務器的響應
            var response = request.GetResponse();
            string text;
            using (var sr = new StreamReader(response.GetResponseStream()))// StreamReader用於讀取響應的數據流。在using語句結束時，StreamReader對象將被自動關閉並釋放資源
            {
                text = sr.ReadToEnd();// 讀取整個數據流並將其存儲在text變數中
            }
            return text;// 將讀取到的文本返回
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


