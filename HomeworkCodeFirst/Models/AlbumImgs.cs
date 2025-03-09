using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HomeWork.Models
{
    public class AlbumImgs
    {
        [Key]
        [Display(Name = "編號")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        [Display(Name = "相簿")]
        public int AlbumId { get; set; }
        [JsonIgnore]
        [ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "位置")]
        public string ImgUrl { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        [Display(Name = "是否為封面")]
        public bool IsCover { get; set; } = false;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "創建時間")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "更新時間")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}