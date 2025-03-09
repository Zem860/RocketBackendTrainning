using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HomeworkCodeFirst.Models
{
    public class ProductsImgs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="編號")]
        public int Id { get; set; }
        [Required]
        public int ProductId {  get; set; }
        [JsonIgnore]
        [ForeignKey("ProductId")]
        public virtual Products Products { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(max)")]
        [Display(Name ="圖片位置")]
        public string ImgUrl {  get; set; }
        [Required]
        [MaxLength(255)]
        [Column(TypeName ="nvarchar")]
        [Display(Name ="圖片描述")]
        public string ImgDescription {  get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:yyyy-MM-dd}")]
        [Column(TypeName ="datetime2")]
        [Display(Name ="創建時間")]
        public DateTime CreatedAt { get; set; }= DateTime.Now;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}")]
        [Column(TypeName ="datetime2")]
        [Display(Name ="更新時間")]
        public DateTime UpdatedAt { get; set;} = DateTime.Now;

    }
}