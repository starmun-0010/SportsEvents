using System.Collections.Generic;

namespace SportsEvents.Web.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public List<Event> Events { get; set; }

    }
}