namespace HomeworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featAdAdCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdCate = c.String(nullable: false, maxLength: 70),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdCategories");
        }
    }
}
