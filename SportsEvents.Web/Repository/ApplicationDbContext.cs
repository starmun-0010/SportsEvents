using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SportsEvents.Web.Models;

namespace SportsEvents.Web.Repository
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Event> Enents { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Organizers> Organizers { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        public ApplicationDbContext()
            : base("SportsEvents", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}