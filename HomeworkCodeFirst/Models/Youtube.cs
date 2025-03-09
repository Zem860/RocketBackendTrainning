using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HomeworkCodeFirst.Models
{
    public class Youtube
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { get; set; }
        [Required]
        [Display(Name ="分類")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        [ForeignKey("CategoryId")]
        public virtual YoutubeCategory YoutubeCategory { get; set; }

        [Required]
        [StringLength(255)]
        [Column(TypeName = "nvarchar")]
        [Display(Name ="YT名稱")]
        public string YoutubeTitle {  get; set; }
        [Required]
        [Column (TypeName ="nvarchar(max)")]
        [Display(Name ="Youtube縮圖")]
        public string YoutubeThumbnaill {  get; set; }
        [Required]
        [DatabaseGenerated (DatabaseGeneratedOption.Computed)]
        [Column (TypeName ="datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name ="創建時間")]
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        [Required]
        [DatabaseGenerated (DatabaseGeneratedOption.Computed)]
        [Column(TypeName ="datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name ="更新時間")]
        public DateTime UpdatedAt {  get; set; }= DateTime.Now;

    }
}