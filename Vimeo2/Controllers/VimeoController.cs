using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http; 
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Vimeo.Controllers
{
    public static class HttpMethodExtensions
    {
        public static readonly HttpMethod Patch = new HttpMethod("PATCH");
    }

    [RoutePrefix("api/Vimeo")] // 設定 API 前綴
    public class VimeoController : ApiController
    {
        private readonly string vimeoAccessToken = ""; // 替換為你的 Vimeo API Key

        // 取得 Vimeo 影片列表
        [HttpGet]
        [Route("hello")]
        public async Task<IHttpActionResult> GetHello()
        {
            return Ok(new { message = "Hello, world!" });


        }
        [HttpGet]
        [Route("GetVideos")]
        public async Task<IHttpActionResult> GetVideos(int page = 1, int perPage = 10)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vimeoAccessToken);
                //有header
                string apiUrl = $"https://api.vimeo.com/me/videos?page={page}&per_page={perPage}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return BadRequest($"無法取得影片: {response.ReasonPhrase}");
                }

                JObject json = JObject.Parse(responseContent);
                return Ok(new { videos = json["data"], pagination = json["paging"] });
            }
        }

        [HttpPost]
        [Route("UploadVideoFile")]
        public async Task<IHttpActionResult> UploadVideoFile()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                    return BadRequest("請使用 Multipart 表單上傳影片");
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
                var file = provider.Contents.FirstOrDefault();
                if (file == null)
                    return BadRequest("未收到影片檔案");
                var fileStream = await file.ReadAsStreamAsync();
                var fileSize = fileStream.Length;
                Console.WriteLine($"影片大小: {fileSize} bytes");
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vimeoAccessToken);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // 1️⃣ `POST` 取得 `upload.upload_link`
                    var requestBody = new
                    {
                        upload = new
                        {
                            approach = "tus",
                            size = fileSize
                        }
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                    var createVideoResponse = await client.PostAsync("https://api.vimeo.com/me/videos", content);
                    string errorResponse = await createVideoResponse.Content.ReadAsStringAsync();

                    if (!createVideoResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Vimeo API 錯誤 (POST): {errorResponse}");
                        return BadRequest($"無法創建 Vimeo 上傳: {errorResponse}");
                    }

                    var createVideoContent = await createVideoResponse.Content.ReadAsStringAsync();
                    JObject createVideoJson = JObject.Parse(createVideoContent);
                    string uploadUrl = createVideoJson["upload"]["upload_link"]?.ToString();
                    string videoUri = createVideoJson["uri"]?.ToString();
                    if (string.IsNullOrEmpty(uploadUrl))
                        return BadRequest("未能取得 Vimeo 上傳 URL");
                    Console.WriteLine($"上傳 URL: {uploadUrl}");
                    // 進行 `PATCH` 上傳影片檔案的同時，加入進度檢查
                    using (var uploadClient = new HttpClient())
                    {
                        var uploadRequest = new HttpRequestMessage(HttpMethodExtensions.Patch, uploadUrl)
                        {
                            Content = new StreamContent(fileStream)
                        };
                        uploadRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/offset+octet-stream");
                        uploadRequest.Headers.Add("Tus-Resumable", "1.0.0");
                        uploadRequest.Headers.Add("Upload-Offset", "0");

                        var uploadResponse = await uploadClient.SendAsync(uploadRequest);
                        if (!uploadResponse.IsSuccessStatusCode)
                        {
                            string uploadError = await uploadResponse.Content.ReadAsStringAsync();
                            Console.WriteLine($"影片上傳失敗: {uploadError}");
                            return BadRequest($"影片上傳失敗: {uploadError}");
                        }

                        // 檢查影片是否已完成上傳
                        var headRequest = new HttpRequestMessage(HttpMethod.Head, uploadUrl);
                        headRequest.Headers.Add("Tus-Resumable", "1.0.0");

                        var headResponse = await uploadClient.SendAsync(headRequest);
                        if (headResponse.IsSuccessStatusCode)
                        {
                            var uploadOffset = headResponse.Headers.GetValues("Upload-Offset").FirstOrDefault();
                            var uploadLength = headResponse.Headers.GetValues("Upload-Length").FirstOrDefault();

                            if (uploadOffset == uploadLength)
                            {
                                Console.WriteLine("影片上傳完成");
                                return Ok(new { message = "影片上傳成功", videoUri });
                            }
                            else
                            {
                                Console.WriteLine("影片仍在上傳中，繼續上傳...");
                                return BadRequest("影片尚未上傳完成，請稍後再試");
                            }
                        }
                    }


                    return Ok(new { message = "影片上傳成功", videoUri });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"內部錯誤: {ex.Message}");
                return InternalServerError(ex);
            }
        }




        internal class EnableCorsAttribute : Attribute
        {
            private string origins;
            private string headers;
            private string methods;

            public EnableCorsAttribute(string origins, string headers, string methods)
            {
                this.origins = origins;
                this.headers = headers;
                this.methods = methods;
            }
        }
    }
}
