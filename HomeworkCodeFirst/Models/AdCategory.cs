using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkCodeFirst.Models
{
    public class AdCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="廣告Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        [Column(TypeName ="nvarchar")]
        [Display(Name ="廣告分類")]
        public string AdCate {  get; set; }
        [Required]
        [DatabaseGenerated (DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}")]
        [Column(TypeName ="datetime2")]
        [Display(Name ="創建時間")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [DatabaseGenerated (DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:yyyy-MM-dd}")]
        [Column(TypeName ="datetime2")]
        [Display(Name ="更新時間")]
        public DateTime UpdatedAt { get; set;}

        public virtual ICollection<Ad>Ads { get; set; }

    }
}