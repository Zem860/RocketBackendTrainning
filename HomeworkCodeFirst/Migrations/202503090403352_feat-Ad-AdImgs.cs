namespace HomeworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featAdAdImgs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdImgs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdId = c.Int(nullable: false),
                        ImgUrl = c.String(nullable: false, maxLength: 4000),
                        IsCover = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ads", t => t.AdId, cascadeDelete: true)
                .Index(t => t.AdId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdImgs", "AdId", "dbo.Ads");
            DropIndex("dbo.AdImgs", new[] { "AdId" });
            DropTable("dbo.AdImgs");
        }
    }
}
