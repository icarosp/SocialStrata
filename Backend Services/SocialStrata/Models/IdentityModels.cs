using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web.UI.WebControls;
using System.Data.Common;

namespace SocialStrata.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        /// <summary>
        /// HACK: Fixed connectuon String  due to azure contraints dureing prototyping this MGS solution
        /// </summary>
        public ApplicationDbContext()
            : base("Data Source=social-strata-server.database.windows.net;Initial Catalog=SS;Integrated Security=False;User ID=social-strata-server;Password=P@ssw0rd;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", throwIfV1Schema: false)
        {
            
        }

        public string ConnectionString()
        {
            return base.Database.Connection.ConnectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Coment this lines with migration problem
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }



        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SocialStrata.Models.Event> Event { get; set; }
        public System.Data.Entity.DbSet<SocialStrata.Models.Chat> Chat { get; set; }
        public System.Data.Entity.DbSet<SocialStrata.Models.Country> Country { get; set; }
        public System.Data.Entity.DbSet<SocialStrata.Models.LostAndFound> LostAndFound { get; set; }
        public System.Data.Entity.DbSet<SocialStrata.Models.MaintainanceRequest> MaintainanceRequest { get; set; }
        public System.Data.Entity.DbSet<SocialStrata.Models.MaintainanceRequestImage> MaintainanceRequestImages { get; set; }
        public System.Data.Entity.DbSet<SocialStrata.Models.Notice> Notices { get; set; }
        public System.Data.Entity.DbSet<SocialStrata.Models.NoticeImage> NoticeImages { get; set; }
        public System.Data.Entity.DbSet<SocialStrata.Models.PersonCreditCard> PersonCreditCards { get; set; }
        public System.Data.Entity.DbSet<SocialStrata.Models.Person> People { get; set; }
        public System.Data.Entity.DbSet<SocialStrata.Models.Residence> Residences { get; set; }
        public System.Data.Entity.DbSet<SocialStrata.Models.ResidencePayments> ResidencePayments { get; set; }
        public System.Data.Entity.DbSet<SocialStrata.Models.ResidenceService> ResidenceServices { get; set; }
        public System.Data.Entity.DbSet<SocialStrata.Models.ResidenceType> ResidenceTypes { get; set; }
        public System.Data.Entity.DbSet<SocialStrata.Models.Service> Services { get; set; }
    }
}