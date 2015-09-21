using System.Collections.Generic;

namespace SportsEvents.Web.Models
{
    public class Organizer : ApplicationUser
    {
        public ICollection<Event> Events { get; set; }


    }
}