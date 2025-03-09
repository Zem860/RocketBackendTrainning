using System;
using System.Data.Entity;
using System.Linq;
using HomeWork.Models;
using HomeworkCodeFirst.Migrations;

namespace HomeworkCodeFirst.Models
{
    public class Homework : DbContext
    {
        // 您的內容已設定為使用應用程式組態檔 (App.config 或 Web.config)
        // 中的 'Homework' 連接字串。根據預設，這個連接字串的目標是
        // 您的 LocalDb 執行個體上的 'HomeworkCodeFirst.Models.Homework' 資料庫。
        // 
        // 如果您的目標是其他資料庫和 (或) 提供者，請修改
        // 應用程式組態檔中的 'Homework' 連接字串。
        public Homework()
            : base("name=Homework")
        {
        }

        // 針對您要包含在模型中的每種實體類型新增 DbSet。如需有關設定和使用
        // Code First 模型的詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<AlbumImgs> AlbumImgs { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<FileCategory> FileCategories { get; set; }
        public virtual DbSet<Youtube> Youtubes { get; set; }
        public virtual DbSet<YoutubeCategory> YoutubeCategories { get; set; }
        public virtual DbSet<MsgUsers> MsgUsers { get; set; }
        public virtual DbSet<MsgBoard> MsgBoards {  get; set; }
        public virtual DbSet<MsgTopics>MsgTopics { get; set; }
        public virtual DbSet<MsgPosts> MsgPosts { get; set; }
        public virtual DbSet<AdCategory> AdCategories { get; set; }
        public virtual DbSet<Ad>Ads{ get; set; }
        public virtual DbSet<AdImgs> AdImgs { get; set; }
        public virtual DbSet<ProductsCategory> ProductsCategories { get; set; }
        public virtual DbSet<ProductsSubCategory>ProductsSubCategories { get; set; }
        public virtual DbSet<ProductsBrand>ProductsBrands { get; set; }
        public virtual DbSet<ProductsFiles>ProductsFiles { get; set; }
        public virtual DbSet<ProductsImgs>ProductsImgs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ 禁用 `MsgTopics.UserId` 的 `Cascade Delete`
            modelBuilder.Entity<MsgTopics>()
                .HasRequired(t => t.MsgUsers) // `MsgTopics` 對應 `User`
                .WithMany(u => u.MsgTopics)
                .HasForeignKey(t => t.UserId)
                .WillCascadeOnDelete(false); // ❌ 禁止 `Cascade Delete`

            // ✅ 禁用 `MsgBoard.UserId` 的 `Cascade Delete`
            modelBuilder.Entity<MsgBoard>()
                .HasRequired(b => b.MsgUsers) // `MsgBoard` 對應 `User`
                .WithMany(u => u.MsgBoards)
                .HasForeignKey(b => b.UserId)
                .WillCascadeOnDelete(false); // ❌ 禁止 `Cascade Delete`

            modelBuilder.Entity<MsgPosts>()
              .HasRequired(b => b.MsgUsers) // `MsgBoard` 對應 `User`
              .WithMany(u => u.MsgPosts)
              .HasForeignKey(b => b.UserId)
              .WillCascadeOnDelete(false); // ❌ 禁止 `Cascade Delete`
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}