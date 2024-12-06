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
            Literal1.Text = GetJsonContent("https://iplay.sa.gov.tw/api/GymSearchAllList?$format=application/json");
        }

        private string GetJsonContent(string url, string type = "application/json: charset=utf-8")// 這是一個名為GetJsonContent的私有方法，它需要一個名為url的參數，返回一個string
        {
            string targeturl = url;
            // 使用WebRequest.Create方法創建一個新的WebRequest對象，該對象會向指定的URL發送請求
            var request = WebRequest.Create(targeturl);
            // 將請求的ContentType設置為"application/json: charset=utf-8"，這意味著我們期望從服務器接收JSON數據
            request.ContentType = type;
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
}

