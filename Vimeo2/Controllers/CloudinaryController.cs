using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Configuration;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;

namespace CloudinaryAPI.Controllers
{
    [RoutePrefix("api/Cloudinary")]
    public class CloudinaryController : ApiController
    {
        private readonly CloudinaryDotNet.Cloudinary _cloudinary;

        public CloudinaryController()
        {
            // 從 Web.config 讀取 Cloudinary 設定
            var cloudName = ConfigurationManager.AppSettings["CloudinaryCloudName"];
            var apiKey = ConfigurationManager.AppSettings["CloudinaryApiKey"];
            var apiSecret = ConfigurationManager.AppSettings["CloudinaryApiSecret"];

            if (string.IsNullOrEmpty(cloudName) || string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret))
            {
                throw new Exception("Cloudinary 設定錯誤，請檢查 Web.config");
            }

            var account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new CloudinaryDotNet.Cloudinary(account);
        }

        // 測試 API 是否正常
        [HttpGet]
        [Route("hello")]
        public IHttpActionResult GetHello()
        {
            return Ok(new { message = "Cloudinary API 運作正常" });
        }

        // 📌 修正 UploadVideo
        [HttpPost]
        [Route("Upload")]
        public async Task<IHttpActionResult> UploadVideo()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                    return Content(HttpStatusCode.BadRequest, new { message = "請使用 Multipart 表單上傳影片" });

                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
                var file = provider.Contents.FirstOrDefault();

                if (file == null)
                    return Content(HttpStatusCode.BadRequest, new { message = "未接收到影片檔案" });

                var fileStream = await file.ReadAsStreamAsync();
                var uploadParams = new VideoUploadParams()
                {
                    File = new FileDescription("video", fileStream),
                    Folder = "assets"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                // ✅ 印出 Cloudinary 回應，檢查錯誤
                Console.WriteLine("Upload Response: " + uploadResult.JsonObj);

                if (uploadResult?.SecureUrl == null)
                {
                    return Content(HttpStatusCode.BadRequest, new
                    {
                        message = "影片上傳失敗",
                        error = uploadResult.Error?.Message
                    });
                }

                return Ok(new
                {
                    message = "影片上傳成功",
                    url = uploadResult.SecureUrl
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    

        // 透過 PublicId 取得影片資訊
        [HttpGet]
        [Route("GetVideoById")]
        public async Task<IHttpActionResult> GetVideoById(string publicId)
        {
            try
            {
                var resource = await _cloudinary.GetResourceAsync(new GetResourceParams(publicId)
                {
                    ResourceType = ResourceType.Video
                });

                if (resource == null)
                    return NotFound();

                return Ok(new
                {
                    public_id = resource.PublicId,
                    url = resource.SecureUrl,
                    format = resource.Format
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // 取得所有影片（最多 10 筆）
        [HttpGet]
        [Route("GetVideos")]
        public async Task<IHttpActionResult> GetVideos(int maxResults = 10)
        {
            try
            {
                var result = await _cloudinary.ListResourcesAsync(new ListResourcesParams()
                {
                    Type = "upload",
                    ResourceType = ResourceType.Video,
                    MaxResults = maxResults
                });

                if (result.Resources == null || !result.Resources.Any())
                    return Ok(new { message = "沒有找到任何影片，請確認是否已上傳！" });

                var videos = result.Resources.Select(v => new
                {
                    v.PublicId,
                    v.SecureUrl
                }).ToList();

                return Ok(new { videos });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
