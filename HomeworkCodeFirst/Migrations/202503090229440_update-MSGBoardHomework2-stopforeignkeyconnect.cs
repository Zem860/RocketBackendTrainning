namespace HomeworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMSGBoardHomework2stopforeignkeyconnect : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MsgBoards", "UserId", "dbo.MsgUsers");
            AddColumn("dbo.MsgTopics", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.MsgTopics", "UserId");
            AddForeignKey("dbo.MsgTopics", "UserId", "dbo.MsgUsers", "Id");
            AddForeignKey("dbo.MsgBoards", "UserId", "dbo.MsgUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MsgBoards", "UserId", "dbo.MsgUsers");
            DropForeignKey("dbo.MsgTopics", "UserId", "dbo.MsgUsers");
            DropIndex("dbo.MsgTopics", new[] { "UserId" });
            DropColumn("dbo.MsgTopics", "UserId");
            AddForeignKey("dbo.MsgBoards", "UserId", "dbo.MsgUsers", "Id", cascadeDelete: true);
        }
    }
}
