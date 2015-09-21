using System.Collections.Generic;
using SportsEvents.Web.Models;

namespace SportsEvents.Web.ViewModels
{
    public class EventsViewModel
    {
        public List<Event> Events { get; set; }
        public int Count { get; set; }
        public int CurrentSkip { get; set; }
        public int CurrentTake { get; set; }
    }
}