using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using HomeworkCodeFirst.Models;
namespace HomeWork.Models
{
    public class File
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { get; set; }


        [Required]
        [Display(Name = "檔案分類")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        [ForeignKey("CategoryId")]
        public virtual FileCategory FileCategory { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "檔案名稱")]
        public string FileName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "檔案描述")]
        public string FileDescription { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0,yyyy-MM-dd}")]
        [Display(Name = "創建時間")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0,yyyy-MM-dd}")]
        [Display(Name = "更新時間")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}