namespace RecursionHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class policeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PoliceStations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameZh = c.String(nullable: false, maxLength: 100),
                        NameEn = c.String(nullable: false, maxLength: 100),
                        ZipCode = c.String(maxLength: 10),
                        Address = c.String(maxLength: 200),
                        Phone = c.String(maxLength: 50),
                        PointX = c.Decimal(precision: 18, scale: 2),
                        PointY = c.Decimal(precision: 18, scale: 2),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PoliceStations", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PoliceStations", "ParentId", "dbo.PoliceStations");
            DropIndex("dbo.PoliceStations", new[] { "ParentId" });
            DropTable("dbo.PoliceStations");
        }
    }
}
