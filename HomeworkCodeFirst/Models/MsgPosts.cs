using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HomeworkCodeFirst.Models
{
    public class MsgPosts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [JsonIgnore]
        [ForeignKey("UserId")]
        public virtual MsgUsers MsgUsers { get; set; }

        [Required]
        public int TopicId { get; set; }
        [JsonIgnore]
        [ForeignKey("TopicId")]
        public virtual MsgTopics MsgTopics { get; set; }

        [Required]
        [MaxLength(500)]
        [Column(TypeName ="nvarchar")]
        [Display(Name ="貼文")]
        public string Post {  get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(TypeName = "datetime2")]
        [Display(Name = "創建時間")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:yyyy-MM-dd}")]
        [Column(TypeName="datetime2")]
        [Display(Name ="更新時間")]
        public DateTime UpdatedAt { get; set;} = DateTime.Now;

    }
}