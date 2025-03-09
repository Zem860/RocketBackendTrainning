namespace HomeworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featProductsCategoriesAndSubCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductsCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCate = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductsSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryName = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductsCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductsSubCategories", "CategoryId", "dbo.ProductsCategories");
            DropIndex("dbo.ProductsSubCategories", new[] { "CategoryId" });
            DropTable("dbo.ProductsSubCategories");
            DropTable("dbo.ProductsCategories");
        }
    }
}
