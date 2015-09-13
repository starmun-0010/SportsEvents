using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SportsEvents.Web.Models;

namespace SportsEvents.Web.Repository
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class SportsEventsDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Message> Messages { get; set; }
        public SportsEventsDbContext()
            : base("SportsEventsDb", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Visitor>().Map(e => e.ToTable("Visitors"));
            modelBuilder.Entity<Admin>().Map(e => e.ToTable("Admins"));
            modelBuilder.Entity<Organizer>().Map(e => e.ToTable("Organizers"));
            modelBuilder.ComplexType<Address>();
            modelBuilder.Entity<Event>().HasMany(e => e.RegisteredVisitors).WithMany(e => e.RegisteredEvents).Map(e => e.ToTable("RegisterdEventVisitors"));
            modelBuilder.Entity<Event>().HasMany(e => e.BookmarkerVisitors).WithMany(e => e.BookmarkedEvents).Map(e => e.ToTable("BookmarkerEventVisitors"));
            modelBuilder.Entity<Event>().HasMany(e => e.RegisterRequestVisitors).WithMany(e => e.RegisterRequestEvents).Map(e => e.ToTable("RegisterRequestEventVisitors"));


        }

        public static SportsEventsDbContext Create()
        {
            return new SportsEventsDbContext();
        }
    }
}