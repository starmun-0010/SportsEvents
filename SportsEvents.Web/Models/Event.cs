using System;
using System.Collections.Generic;

namespace SportsEvents.Web.Models
{
    public class Event
    {
        public Sport Sport { get; set; }
        public EventType EventType { get; set; }
        public double? StartingPrice { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string IconLink { get; set; }
        public List<string> PictureLinks { get; set; }
        public string VideoLink { get; set; }
        public string ExternalLink { get; set; }

    }
}
