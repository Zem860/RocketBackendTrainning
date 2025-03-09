using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.ComponentModel;

namespace HomeworkCodeFirst.Models
{
    public class Ad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="編號")]
        public int Id { get; set; }

        [Required]
        public int CateId { get; set; }
        [JsonIgnore]
        [ForeignKey("CateId")]
        public virtual AdCategory AdCategory { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(max)")]
        [Display(Name="廣告連結")]
        public string AdLink {  get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName ="nvarchar")]
        [Display(Name ="廣告名稱")]
       public string AdTitle { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(TypeName = "datetime2")]
        [Display(Name = "創建時間")]

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:yyyy-MM-dd}")]
        [Column(TypeName ="datetime2")]
        [Display(Name ="更新時間")]
        public DateTime UpdatedAt { get; set;} = DateTime.Now;

        public virtual ICollection<AdImgs> AdImgs { get; set; }
    }
}