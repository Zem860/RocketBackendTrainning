using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkCodeFirst.Models
{
    public class ProductsBrand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="編號")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName ="nvarchar")]

        [Display(Name ="商品品牌")]
        public string Brand {  get; set; }
        [Required]
        [DatabaseGenerated (DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:yyyy-MM-dd}")]
        [Column(TypeName ="datetime2")]
        [Display(Name ="創建時間")]
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:yyyy-MM-dd}")]
        [Column(TypeName ="datetime2")]
        [Display(Name ="更新時間")]

        public DateTime UpdatedAt {  get; set; }=DateTime.Now;
        public virtual ICollection<Products> Products { get; set; }


    }
}