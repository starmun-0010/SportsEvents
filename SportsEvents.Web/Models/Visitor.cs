using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace SportsEvents.Web.Models
{
    public class Visitor : ApplicationUser
    {
        public ICollection<Event> BookmarkedEvents { get; set; }
        public ICollection<Event> RegisteredEvents { get; set; }
        public ICollection<Event> RegisterRequestEvents { get; set; }
        public DbGeography Coordinates { get; set; }
    }
}