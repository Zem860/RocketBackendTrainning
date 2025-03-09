namespace HomeworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featAlbumHomework : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumImgs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlbumId = c.Int(nullable: false),
                        ImgUrl = c.String(nullable: false),
                        IsCover = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlbumName = c.String(nullable: false, maxLength: 50),
                        News = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlbumImgs", "AlbumId", "dbo.Albums");
            DropIndex("dbo.AlbumImgs", new[] { "AlbumId" });
            DropTable("dbo.Albums");
            DropTable("dbo.AlbumImgs");
        }
    }
}
