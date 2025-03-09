namespace HomeworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featProductsProductsImgs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductsImgs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ImgUrl = c.String(nullable: false),
                        ImgDescription = c.String(nullable: false, maxLength: 255),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductsImgs", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductsImgs", new[] { "ProductId" });
            DropTable("dbo.ProductsImgs");
        }
    }
}
