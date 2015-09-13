using System.Collections.Generic;

namespace SportsEvents.Web.Models
{
    public class Organizer : ApplicationUser
    {
        public List<Event> Events { get; set; }


    }
}