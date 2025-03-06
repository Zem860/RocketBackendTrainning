using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography;
using System.Text;

namespace Cloudinary.Controllers
{
    [RoutePrefix("api/Cloudinary")] // 設定 API 前綴
    public class CloudinaryController : ApiController
    {
        private readonly string cloudName = ConfigurationManager.AppSettings["CloudinaryCloudName"];
        private readonly string apiKey = ConfigurationManager.AppSettings["CloudinaryApiKey"];
        private readonly string apiSecret = ConfigurationManager.AppSettings["CloudinaryApiSecret"];

        private readonly string cloudinaryBaseUrl = "https://api.cloudinary.com/v1_1/";

        // 測試 API 是否正常運作
        [HttpGet]
        [Route("hello")]
        public IHttpActionResult GetHello()
        {
            Console.WriteLine($"CloudName: {cloudName}, ApiKey: {apiKey}, ApiSecret: {apiSecret}");

            return Ok(new { message = $"CloudName: {cloudName}, ApiKey: {apiKey}, ApiSecret: {apiSecret}" });
        }

        // 取得 Cloudinary 影片列表
        //[HttpGet]
        //[Route("GetVideos")]
        //public async Task<IHttpActionResult> GetVideos(int maxResults = 10)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        string apiUrl = $"{cloudinaryBaseUrl}{cloudName}/resources/video?max_results={maxResults}&api_key={apiKey}";

        //        HttpResponseMessage response = await client.GetAsync(apiUrl);
        //        string responseContent = await response.Content.ReadAsStringAsync();

        //        Console.WriteLine($"Response Content: {responseContent}"); // Debug

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            return BadRequest($"無法取得影片: {response.ReasonPhrase}");
        //        }

        //        JObject json = JObject.Parse(responseContent);
        //        return Ok(json["resources"]);
        //    }
        //}



        [HttpGet]
        [Route("GetVideos")]
        public async Task<IHttpActionResult> GetVideos(int maxResults = 10)
        {
            using (var client = new HttpClient())
            {
                long timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                string signatureString = $"max_results={maxResults}&timestamp={timestamp}{apiSecret}";
                string signatureHash = ComputeSHA1Hash(signatureString);

                var content = new FormUrlEncodedContent(new[]
                {
            new KeyValuePair<string, string>("api_key", apiKey),
            new KeyValuePair<string, string>("timestamp", timestamp.ToString()),
            new KeyValuePair<string, string>("max_results", maxResults.ToString()),
            new KeyValuePair<string, string>("type", "upload"),  // 確保查詢的是已上傳的影片
            new KeyValuePair<string, string>("signature", signatureHash),
        });

                string apiUrl = $"{cloudinaryBaseUrl}{cloudName}/resources/video";

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                string responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Response Content: {responseContent}"); // Debug

                if (!response.IsSuccessStatusCode)
                {
                    return BadRequest($"無法取得影片: {response.ReasonPhrase}");
                }

                JObject json = JObject.Parse(responseContent);
                return Ok(json["resources"]);
            }
        }


        // 計算 SHA1 簽名
        private static string ComputeSHA1Hash(string input)
    {
        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }




    // 上傳影片到 Cloudinary（透過 URL）
    [HttpPost]
        [Route("UploadVideo")]
        public async Task<IHttpActionResult> UploadVideo([FromBody] JObject request)
        {
            if (request == null || !request.ContainsKey("videoUrl"))
                return BadRequest("請提供影片 URL");

            string videoUrl = request["videoUrl"].ToString();
            string apiUrl = $"{cloudinaryBaseUrl}{cloudName}/video/upload";

            using (var client = new HttpClient())
            {
                var content = new MultipartFormDataContent
                {
                    { new StringContent(apiKey), "api_key" },
                    { new StringContent(videoUrl), "file" }
                };

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return BadRequest($"上傳失敗: {response.ReasonPhrase}");
                }

                JObject jsonResponse = JObject.Parse(responseContent);
                return Ok(jsonResponse);
            }
        }
    }
}
