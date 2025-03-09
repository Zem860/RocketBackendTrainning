namespace HomeworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featMSGBoardHomework2Topics : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MsgBoards", "UserId", "dbo.MsgUsers");
            DropPrimaryKey("dbo.MsgUsers");
            CreateTable(
                "dbo.MsgTopics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MsgBoardId = c.Int(nullable: false),
                        Topic = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MsgBoards", t => t.MsgBoardId, cascadeDelete: true)
                .Index(t => t.MsgBoardId);
            
            AlterColumn("dbo.MsgUsers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MsgUsers", "Id");
            AddForeignKey("dbo.MsgBoards", "UserId", "dbo.MsgUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MsgBoards", "UserId", "dbo.MsgUsers");
            DropForeignKey("dbo.MsgTopics", "MsgBoardId", "dbo.MsgBoards");
            DropIndex("dbo.MsgTopics", new[] { "MsgBoardId" });
            DropPrimaryKey("dbo.MsgUsers");
            AlterColumn("dbo.MsgUsers", "Id", c => c.Int(nullable: false));
            DropTable("dbo.MsgTopics");
            AddPrimaryKey("dbo.MsgUsers", "Id");
            AddForeignKey("dbo.MsgBoards", "UserId", "dbo.MsgUsers", "Id", cascadeDelete: true);
        }
    }
}
