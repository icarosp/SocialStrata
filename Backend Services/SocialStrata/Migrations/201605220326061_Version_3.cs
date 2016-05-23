namespace SocialStrata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResidencePayments", "PersonCreditCardId", c => c.Int(nullable: false));
            AddColumn("dbo.ResidencePayments", "PayPalToken", c => c.String());
            CreateIndex("dbo.ResidencePayments", "PersonCreditCardId");
            AddForeignKey("dbo.ResidencePayments", "PersonCreditCardId", "dbo.PersonCreditCards", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResidencePayments", "PersonCreditCardId", "dbo.PersonCreditCards");
            DropIndex("dbo.ResidencePayments", new[] { "PersonCreditCardId" });
            DropColumn("dbo.ResidencePayments", "PayPalToken");
            DropColumn("dbo.ResidencePayments", "PersonCreditCardId");
        }
    }
}
