using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace SportsEvents.Web.Models
{
    public class Visitor : ApplicationUser
    {
        public List<Event> BookmarkedEvents { get; set; }
        public List<Event> RegisteredEvents { get; set; }
        public List<Event> RegisterRequestEvents { get; set; }
        public DbGeography Coordinates { get; set; }
    }
}