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
        }
        public IRepository<Event> Events { get; set; }
        public IRepository<Advertisement> Advertisements { get; set; }
        public IRepository<Country> Countries { get; set; }
        public IRepository<City> Cities { get; set; }
    }
}