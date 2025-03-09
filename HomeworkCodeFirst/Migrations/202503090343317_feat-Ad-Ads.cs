namespace HomeworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featAdAds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CateId = c.Int(nullable: false),
                        AdLink = c.String(nullable: false),
                        AdTitle = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdCategories", t => t.CateId, cascadeDelete: true)
                .Index(t => t.CateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ads", "CateId", "dbo.AdCategories");
            DropIndex("dbo.Ads", new[] { "CateId" });
            DropTable("dbo.Ads");
        }
    }
}
