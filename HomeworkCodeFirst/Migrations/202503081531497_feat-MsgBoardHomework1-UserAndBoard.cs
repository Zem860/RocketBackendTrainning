namespace HomeworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featMsgBoardHomework1UserAndBoard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MsgBoards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BoardName = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MsgUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MsgUsers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 100),
                        PasswordHash = c.String(nullable: false, maxLength: 255),
                        IsMod = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MsgBoards", "UserId", "dbo.MsgUsers");
            DropIndex("dbo.MsgBoards", new[] { "UserId" });
            DropTable("dbo.MsgUsers");
            DropTable("dbo.MsgBoards");
        }
    }
}
