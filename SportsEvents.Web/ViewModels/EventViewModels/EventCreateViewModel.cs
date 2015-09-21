using System;
using System.Collections.Generic;

namespace SportsEvents.Web.ViewModels.EventViewModels
{
    public class EventCreateViewModel
    {
        public string Sport { get; set; }
        public string EventType { get; set; }
        public double? StartingPrice { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public byte[] Icon { get; set; }
        public List<byte[]> Picture { get; set; }
        public string VideoLink { get; set; }
        public string ExternalLink { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
