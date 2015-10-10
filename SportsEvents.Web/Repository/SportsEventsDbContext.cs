using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SportsEvents.Web.Migrations;
using SportsEvents.Web.Models;

namespace SportsEvents.Web.Repository
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class SportsEventsDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Country> Countries { get; set; }

        public SportsEventsDbContext()
            : base("SportsEventsDb", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.ComplexType<Address>();
            modelBuilder.Entity<Event>().HasMany(e => e.RegisteredVisitors).WithMany(e => e.RegisteredEvents).Map(e => e.ToTable("RegisterdEventVisitors"));
            modelBuilder.Entity<Event>().HasMany(e => e.BookmarkerVisitors).WithMany(e => e.BookmarkedEvents).Map(e => e.ToTable("BookmarkerEventVisitors"));
            modelBuilder.Entity<Event>().HasMany(e => e.RegisterRequestVisitors).WithMany(e => e.RegisterRequestEvents).Map(e => e.ToTable("RegisterRequestEventVisitors"));
            

        }

        public static SportsEventsDbContext Create()
        {
            var context = new SportsEventsDbContext();


            return context;
        }
    }
}