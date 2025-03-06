using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vimeo2.Models
{
    public class CloudinaryVideo
    {
        public string PublicId { get; set; } // Cloudinary 影片的 ID
        public string Url { get; set; } // 影片的 URL
        public DateTime UploadedAt { get; set; } // 上傳時間
    }
}
