namespace HomeworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featProductsProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductsName = c.String(nullable: false, maxLength: 100),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BrandId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                        Size = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductsBrands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.ProductsSubCategories", t => t.SubCategoryId, cascadeDelete: true)
                .Index(t => t.BrandId)
                .Index(t => t.SubCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.ProductsSubCategories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.ProductsBrands");
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropTable("dbo.Products");
        }
    }
}
