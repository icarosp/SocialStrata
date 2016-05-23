namespace SocialStrata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromId = c.Int(nullable: false),
                        ToId = c.Int(nullable: false),
                        PublishiedDate = c.DateTime(nullable: false),
                        Private = c.Boolean(nullable: false),
                        Mensage = c.String(nullable: false, maxLength: 127),
                        IsRead = c.Boolean(nullable: false),
                        From_PersonId = c.Int(),
                        To_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.From_PersonId)
                .ForeignKey("dbo.People", t => t.To_PersonId)
                .Index(t => t.From_PersonId)
                .Index(t => t.To_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chats", "To_PersonId", "dbo.People");
            DropForeignKey("dbo.Chats", "From_PersonId", "dbo.People");
            DropIndex("dbo.Chats", new[] { "To_PersonId" });
            DropIndex("dbo.Chats", new[] { "From_PersonId" });
            DropTable("dbo.Chats");
        }
    }
}
