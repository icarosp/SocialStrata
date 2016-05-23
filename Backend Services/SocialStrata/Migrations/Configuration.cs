namespace SocialStrata.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SocialStrata.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SocialStrata.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SocialStrata.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Country.AddOrUpdate(c => c.Id,
                new Country() { Id = 1, Name = "Canada", Currency = "CAD" },
                new Country() { Id = 2, Name = "United States", Currency = "USS" },
                new Country() { Id = 3, Name = "Brazil", Currency = "BRL" });

            context.ResidenceTypes.AddOrUpdate(c => c.Id,
                new ResidenceType() { Id = 1, Description = "Apartement" },
                new ResidenceType() { Id = 2, Description = "Condon" },
                new ResidenceType() { Id = 3, Description = "Basement" });



        }
    }
}
