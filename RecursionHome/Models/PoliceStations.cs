using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecursionHome.Models
{
    public class PoliceStations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Police Station ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "中文名稱")]
        public string NameZh { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "英文名稱")]
        public string NameEn { get; set; }
        [StringLength(10)]
        [Display(Name = "郵遞區號")]
        public string ZipCode { get; set; }

        [StringLength(200)]
        [Display(Name = "地址")]
        public string Address { get; set; }
        [StringLength(50)]
        [Display(Name = "電話")]
        public string Phone { get; set; }

        [Display(Name ="X 座標")]
        public decimal? PointX { get; set; }

        [Display(Name = "Y 座標")]

        public decimal? PointY { get; set; }

        [Display(Name ="父單位 ID")]
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual PoliceStations Parent { get; set; }
        public virtual ICollection<PoliceStations> Children { get; set; }

    }
}