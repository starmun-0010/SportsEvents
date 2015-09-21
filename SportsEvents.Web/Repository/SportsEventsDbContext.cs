using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
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
        public DbSet<Sport> Sports { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public SportsEventsDbContext()
            : base("SportsEventsDb", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = true;
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
            var context = new SportsEventsDbContext();

            if (!context.Events.Any())
            {
                var usermanager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Organizer"));
                var rand = new Random(DateTime.Now.Second);
                var advertisements = new List<Advertisement>();

                var events = new List<Event>();
                for (int i = 0; i < 20; i++)
                {
                    advertisements.Add(new Advertisement() { Image = "https://placehold.it/600x600?text=Add+" + Ipsum.GetWord(), Priority = rand.Next(1, 11), Prelogin = rand.Next(0, 2) == 1, Keywords = Ipsum.GetWord() });
                }
                for (int i = 0; i < 30; i++)
                {
                    var organizer = new Organizer()
                    {
                        UserName = Ipsum.GetWord(),
                        Email = Ipsum.GetWord() + "@" + Ipsum.GetWord() + ".com"
                    };
                    usermanager.Create(organizer);
                }
                context.Advertisements.AddRange(advertisements);
                var organizers = context.Organizers.ToList();
                for (var i = 0; i < 20; i++)
                {


                    var sport = new Sport { Name = Ipsum.GetPhrase(rand.Next(1, 4)) };
                    var eventType = new EventType { Name = Ipsum.GetPhrase(rand.Next(1, 4)) };
                    context.Sports.Add(sport);
                    context.EventTypes.Add(eventType);

                    for (var j = 0; j < 20; j++)
                    {
                        var pictures = new List<Picture>();
                        for (int k = 0; k < rand.Next(5); k++)
                        {
                            pictures.Add(new Picture() { Url = "https://placehold.it/1000x800?text=" + Ipsum.GetWord() });
                        }

                        var description = Ipsum.GetPhrase(rand.Next(10));
                        var beginDate = DateTime.Now.Date + TimeSpan.FromDays(rand.Next(1, 15));
                        var detail = Ipsum.GetPhrase(rand.Next(40, 200));
                        var endDate = beginDate + TimeSpan.FromDays(rand.Next(1, 15));
                        var address = new Address
                        {
                            LineOne = Ipsum.GetPhrase(rand.Next(10)),
                            LineTwo = Ipsum.GetPhrase(rand.Next(10))
                        };
                        if (!String.IsNullOrEmpty(description))
                        {
                            description = description.Substring(0, 1).ToUpper() + description.Substring(1);

                        }
                        if (!String.IsNullOrEmpty(detail))
                        {
                            detail = detail.Substring(0, 1).ToUpper() + detail.Substring(1);
                        }
                        var @event = new Event
                        {
                            BeginDate = beginDate,
                            Address = address,
                            Description = description,
                            Details = detail,
                            EndDate = endDate,
                            StartingPrice = rand.Next(0, 1000),
                            IconLink = "https://placeholdit.imgix.net/~text?txtsize=25&txt=Icon+" + Ipsum.GetWord() + "&w=100&h=100&+",
                            VideoLink = "https://placehold.it/600x400?text=" + Ipsum.GetWord(),
                            Pictures = pictures,
                            Sport = sport,
                            EventType = eventType,
                            Organizer = organizers[rand.Next(organizers.Count)]
                        };
                        events.Add(@event);
                    }
                }
                context.Events.AddRange(events);
                context.SaveChanges();
            }
            return context;
        }
    }
}