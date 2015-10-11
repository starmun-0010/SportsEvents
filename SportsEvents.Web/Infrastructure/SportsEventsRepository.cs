using System.Web.WebSockets;
using SportsEvents.Web.Models;
using SportsEvents.Web.Repository;

namespace SportsEvents.Web.Infrastructure
{

    public class SportsEventsRepository
    {
        public SportsEventsRepository(SportsEventsDbContext dbContext)
        {
            Events = new EFRpository<Event>(dbContext);
            Countries = new EFRpository<Country>(dbContext);
            Advertisements = new EFRpository<Advertisement>(dbContext);
            Cities = new EFRpository<City>(dbContext);
            EventTypes = new EFRpository<EventType>(dbContext);
            Sports = new EFRpository<Sport>(dbContext);
            ContactDetails = new EFRpository<ContactDetails>(dbContext);
        }
        public IRepository<Event> Events { get; set; }
        public IRepository<Advertisement> Advertisements { get; set; }
        public IRepository<Country> Countries { get; set; }
        public IRepository<City> Cities { get; set; }
        public IRepository<EventType> EventTypes { get; set; }
        public IRepository<Sport> Sports { get; set; }
        public IRepository<ContactDetails> ContactDetails { get; set; }
    }
}