namespace HomeworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featProductsProductsFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductsFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        FileName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 255),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductsFiles", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductsFiles", new[] { "ProductId" });
            DropTable("dbo.ProductsFiles");
        }
    }
}
