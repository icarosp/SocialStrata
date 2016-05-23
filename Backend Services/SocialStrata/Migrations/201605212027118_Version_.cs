namespace SocialStrata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Currency = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonCreditCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        CardNumber = c.String(nullable: false, maxLength: 12),
                        SecurityCode = c.String(nullable: false, maxLength: 6),
                        Name = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            AddColumn("dbo.People", "PayPalAccount", c => c.String(nullable: false));
            DropColumn("dbo.People", "MidleName");
            DropColumn("dbo.People", "SIN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "SIN", c => c.String(nullable: false));
            AddColumn("dbo.People", "MidleName", c => c.String(maxLength: 20));
            DropForeignKey("dbo.PersonCreditCards", "CountryId", "dbo.Countries");
            DropIndex("dbo.PersonCreditCards", new[] { "CountryId" });
            DropColumn("dbo.People", "PayPalAccount");
            DropTable("dbo.PersonCreditCards");
            DropTable("dbo.Countries");
        }
    }
}
