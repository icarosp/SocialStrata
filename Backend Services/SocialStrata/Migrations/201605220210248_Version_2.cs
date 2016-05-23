namespace SocialStrata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LostAndFounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item = c.String(nullable: false, maxLength: 25),
                        Description = c.String(nullable: false, maxLength: 500),
                        IsLost = c.Boolean(nullable: false),
                        WasFound = c.Boolean(nullable: false),
                        ImageURL = c.String(nullable: false),
                        GeoLocalization = c.String(nullable: false),
                        WasLostForId = c.Int(nullable: false),
                        WasFoundForId = c.Int(nullable: false),
                        WasFoundFor_PersonId = c.Int(),
                        WasLostFor_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.WasFoundFor_PersonId)
                .ForeignKey("dbo.People", t => t.WasLostFor_PersonId)
                .Index(t => t.WasFoundFor_PersonId)
                .Index(t => t.WasLostFor_PersonId);
            
            CreateTable(
                "dbo.MaintainanceRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                        Date = c.DateTime(nullable: false),
                        ResidenceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Residences", t => t.ResidenceId, cascadeDelete: true)
                .Index(t => t.ResidenceId);
            
            CreateTable(
                "dbo.MaintainanceRequestImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaintainanceRequestId = c.Int(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaintainanceRequests", t => t.MaintainanceRequestId, cascadeDelete: true)
                .Index(t => t.MaintainanceRequestId);
            
            CreateTable(
                "dbo.ResidencePayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResidenceId = c.Int(nullable: false),
                        PayamentDate = c.DateTime(nullable: false),
                        PaidValue = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Residences", t => t.ResidenceId, cascadeDelete: true)
                .Index(t => t.ResidenceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResidencePayments", "ResidenceId", "dbo.Residences");
            DropForeignKey("dbo.MaintainanceRequests", "ResidenceId", "dbo.Residences");
            DropForeignKey("dbo.MaintainanceRequestImages", "MaintainanceRequestId", "dbo.MaintainanceRequests");
            DropForeignKey("dbo.LostAndFounds", "WasLostFor_PersonId", "dbo.People");
            DropForeignKey("dbo.LostAndFounds", "WasFoundFor_PersonId", "dbo.People");
            DropIndex("dbo.ResidencePayments", new[] { "ResidenceId" });
            DropIndex("dbo.MaintainanceRequestImages", new[] { "MaintainanceRequestId" });
            DropIndex("dbo.MaintainanceRequests", new[] { "ResidenceId" });
            DropIndex("dbo.LostAndFounds", new[] { "WasLostFor_PersonId" });
            DropIndex("dbo.LostAndFounds", new[] { "WasFoundFor_PersonId" });
            DropTable("dbo.ResidencePayments");
            DropTable("dbo.MaintainanceRequestImages");
            DropTable("dbo.MaintainanceRequests");
            DropTable("dbo.LostAndFounds");
        }
    }
}
