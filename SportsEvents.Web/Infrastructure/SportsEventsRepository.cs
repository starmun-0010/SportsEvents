using SportsEvents.Web.Models;
using SportsEvents.Web.Repository;

namespace SportsEvents.Web.Infrastructure
{

    public class SportsEventsRepository
    {
        public SportsEventsRepository(SportsEventsDbContext dbContext)
        {
            Events = new EFRpository<Event>(dbContext);
        }
        public IRepository<Event> Events { get; set; }
    }
}