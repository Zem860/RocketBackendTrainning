using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Newtonsoft.Json;

namespace HomeworkCodeFirst.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="編號")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName ="nvarchar")]
        [Display(Name ="商品")]
        public string ProductsName {  get; set; }
        [Required]
        [Column(TypeName ="decimal")]
        [Range(0,999999.99)]
        [Display(Name ="售價")]
        public decimal Price {  get; set; }=decimal.Zero;

        [Required]
        public int BrandId { get; set; }
        [JsonIgnore]
        [ForeignKey("BrandId")]
        public virtual ProductsBrand ProductsBrand{ get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        [JsonIgnore]
        [ForeignKey("SubCategoryId")]
        public virtual ProductsSubCategory ProductsSubCategory{ get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName ="nvarchar")]
        [Display(Name ="規格")]
        public string Size { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}")]
        [Column(TypeName ="datetime2")]
        [Display(Name ="創建時間")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}")]
        [Column(TypeName ="datetime2")]
        [Display(Name="創建時間")]
        public DateTime UpdatedAt { get; set;} = DateTime.Now;
        public virtual ICollection<ProductsFiles>ProductFiles { get; set; }
        public virtual ICollection<ProductsImgs> ProductsImgs { get; set; }
    }
}