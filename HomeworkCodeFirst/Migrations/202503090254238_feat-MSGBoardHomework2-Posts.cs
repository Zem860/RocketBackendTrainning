namespace HomeworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featMSGBoardHomework2Posts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MsgPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        Post = c.String(nullable: false, maxLength: 500),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MsgTopics", t => t.TopicId, cascadeDelete: true)
                .ForeignKey("dbo.MsgUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TopicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MsgPosts", "UserId", "dbo.MsgUsers");
            DropForeignKey("dbo.MsgPosts", "TopicId", "dbo.MsgTopics");
            DropIndex("dbo.MsgPosts", new[] { "TopicId" });
            DropIndex("dbo.MsgPosts", new[] { "UserId" });
            DropTable("dbo.MsgPosts");
        }
    }
}
