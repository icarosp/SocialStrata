namespace SocialStrata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustes : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Notice", newName: "Notices");
            }
        
        public override void Down()
        {
            
            DropIndex("dbo.NoticeImages", new[] { "NoticeId" });
            DropColumn("dbo.NoticeImages", "NoticeId");
            RenameTable(name: "dbo.Notices", newName: "Notice");
        }
    }
}
