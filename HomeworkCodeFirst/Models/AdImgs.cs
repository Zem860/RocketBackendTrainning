using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HomeworkCodeFirst.Models
{
    public class AdImgs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="編號")]
        public int Id {  get; set; }
        [Required]
        public int AdId { get; set; }
        [JsonIgnore]
        [ForeignKey("AdId")]
        public virtual Ad Ad { get; set; }
        [Required]
        [Column(TypeName ="nvarchar")]
        [Display(Name ="圖片連結")]
        public string ImgUrl {  get; set; }
        [Required]
        [Column(TypeName ="bit")]
        [Display(Name ="是否為封面")]
        public bool IsCover {  get; set; }
        [Required]
        [DatabaseGenerated (DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:yyyy-MM-dd}")]
        [Column(TypeName="datetime2")]
        [Display(Name ="創建時間")]
        public DateTime CreatedAt { get; set; }=DateTime.Now;

        [Required]

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:yyyy-MM-dd}")]
        [Column(TypeName ="datetime2")]

        [Display(Name ="更新時間")]
        public DateTime UpdatedAt { get; set; }=DateTime.Now;
    }
}