namespace HomeworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featFileHomework : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cate = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        FileName = c.String(nullable: false),
                        FileDescription = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FileCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "CategoryId", "dbo.FileCategories");
            DropIndex("dbo.Files", new[] { "CategoryId" });
            DropTable("dbo.Files");
            DropTable("dbo.FileCategories");
        }
    }
}
