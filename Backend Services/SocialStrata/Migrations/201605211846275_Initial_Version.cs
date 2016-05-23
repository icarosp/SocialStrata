namespace SocialStrata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial_Version : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notice",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.Id);


            CreateTable(
                "dbo.NoticeImages",
                c => new
                {
                    NoticeImageId = c.Int(nullable: false, identity: true),
                    NoticeId = c.Int(nullable: false),
                    ImageUrl = c.String(nullable: false),
                    Description = c.String(nullable: false),
                })
                .PrimaryKey(t => t.NoticeImageId)
                .ForeignKey("dbo.Notice", t => t.NoticeId, cascadeDelete: true);

            CreateTable(
                "dbo.People",
                c => new
                {
                    PersonId = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    IsLandlord = c.Boolean(nullable: false),
                    FirstName = c.String(nullable: false, maxLength: 50),
                    MidleName = c.String(maxLength: 20),
                    LastName = c.String(nullable: false, maxLength: 50),
                    PhoneNumber = c.String(nullable: false),
                    emailAddess = c.String(nullable: false),
                    SIN = c.String(nullable: false),
                })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.IdentityUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.IdentityUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                    IdentityUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    LoginProvider = c.String(),
                    ProviderKey = c.String(),
                    IdentityUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    RoleId = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                    IdentityUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);

            CreateTable(
                "dbo.Residences",
                c => new
                {
                    ResidenceId = c.Int(nullable: false, identity: true),
                    LivingPersonInId = c.Int(nullable: false),
                    LandlordPersonId = c.Int(nullable: false),
                    Address = c.String(),
                    LivingLandlord = c.Boolean(nullable: false),
                    ResidenceTypeId = c.Int(nullable: false),
                    Rented = c.Boolean(nullable: false),
                    RentVal = c.Double(nullable: false),
                    LandlordPerson_PersonId = c.Int(),
                    LivingPersonIn_PersonId = c.Int(),
                })
                .PrimaryKey(t => t.ResidenceId)
                .ForeignKey("dbo.People", t => t.LandlordPerson_PersonId)
                .ForeignKey("dbo.People", t => t.LivingPersonIn_PersonId)
                .ForeignKey("dbo.ResidenceTypes", t => t.ResidenceTypeId, cascadeDelete: true)
                .Index(t => t.ResidenceTypeId)
                .Index(t => t.LandlordPerson_PersonId)
                .Index(t => t.LivingPersonIn_PersonId);

            CreateTable(
                "dbo.ResidenceTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Description = c.String(nullable: false, maxLength: 255),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ResidenceServices",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ResidenceId = c.Int(nullable: false),
                    ServiceId = c.Int(nullable: false),
                    IsPaid = c.Boolean(nullable: false),
                    FinalValue = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Residences", t => t.ResidenceId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ResidenceId)
                .Index(t => t.ServiceId);

            CreateTable(
                "dbo.Services",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    Price = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");


            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.Id)
                .Index(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ResidenceServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ResidenceServices", "ResidenceId", "dbo.Residences");
            DropForeignKey("dbo.Residences", "ResidenceTypeId", "dbo.ResidenceTypes");
            DropForeignKey("dbo.Residences", "LivingPersonIn_PersonId", "dbo.People");
            DropForeignKey("dbo.Residences", "LandlordPerson_PersonId", "dbo.People");
            DropForeignKey("dbo.People", "UserId", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.NoticeModelNoticeImages", "NoticeImage_NoticeImageId", "dbo.NoticeImages");
            DropForeignKey("dbo.NoticeModelNoticeImages", "NoticeModel_Id", "dbo.NoticeModels");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.NoticeModelNoticeImages", new[] { "NoticeImage_NoticeImageId" });
            DropIndex("dbo.NoticeModelNoticeImages", new[] { "NoticeModel_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ResidenceServices", new[] { "ServiceId" });
            DropIndex("dbo.ResidenceServices", new[] { "ResidenceId" });
            DropIndex("dbo.Residences", new[] { "LivingPersonIn_PersonId" });
            DropIndex("dbo.Residences", new[] { "LandlordPerson_PersonId" });
            DropIndex("dbo.Residences", new[] { "ResidenceTypeId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUsers", "UserNameIndex");
            DropIndex("dbo.People", new[] { "UserId" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.NoticeModelNoticeImages");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Services");
            DropTable("dbo.ResidenceServices");
            DropTable("dbo.ResidenceTypes");
            DropTable("dbo.Residences");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.IdentityUsers");
            DropTable("dbo.People");
            DropTable("dbo.NoticeModels");
            DropTable("dbo.NoticeImages");
        }
    }
}
