namespace SocialStrata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notices", "Public", c => c.Boolean(nullable: false));
            AddColumn("dbo.Residences", "Description", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Residences", "ActiveContractId", c => c.String(maxLength: 30));
            AlterColumn("dbo.Notices", "Title", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Notices", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Residences", "Address", c => c.String(maxLength: 80));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Residences", "Address", c => c.String());
            AlterColumn("dbo.Notices", "Description", c => c.String());
            AlterColumn("dbo.Notices", "Title", c => c.String());
            DropColumn("dbo.Residences", "ActiveContractId");
            DropColumn("dbo.Residences", "Description");
            DropColumn("dbo.Notices", "Public");
        }
    }
}
