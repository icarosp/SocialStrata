namespace SocialStrata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V41 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 500),
                        Time = c.DateTime(nullable: false),
                        CreatorPersonId = c.Int(nullable: false),
                        Public = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.CreatorPersonId, cascadeDelete: true)
                .Index(t => t.CreatorPersonId);
            
            AddColumn("dbo.NoticeImages", "Event_Id", c => c.Int());
            CreateIndex("dbo.NoticeImages", "Event_Id");
            AddForeignKey("dbo.NoticeImages", "Event_Id", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NoticeImages", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "CreatorPersonId", "dbo.People");
            DropIndex("dbo.NoticeImages", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "CreatorPersonId" });
            DropColumn("dbo.NoticeImages", "Event_Id");
            DropTable("dbo.Events");
        }
    }
}
