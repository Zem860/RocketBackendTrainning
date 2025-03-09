using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeworkCodeFirst.Models
{
    public class MsgUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "用戶姓名")]
        public string UserName { get; set; }
        [Required]
        [StringLength(255)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "密碼")]
        public string PasswordHash { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        [Display(Name = "是否為管理者")]
        public bool IsMod { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(TypeName = "datetime2")]
        [Display(Name = "創建時間")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(TypeName = "datetime2")]
        [Display(Name = "更新時間")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [InverseProperty("MsgUsers")]

        public virtual ICollection<MsgBoard>MsgBoards { get; set; }
        [InverseProperty("MsgUsers")]

        public virtual ICollection<MsgTopics> MsgTopics { get; set; }

        public virtual ICollection<MsgPosts> MsgPosts { get; set; }
    }
}