using System.Collections.Generic;

namespace SportsEvents.Web.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Enents { get; set; }

    }
}