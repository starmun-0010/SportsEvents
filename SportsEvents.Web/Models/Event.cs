using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SportsEvents.Web.Models
{
    public class Event
    {
        public int Id { get; set; }
        public bool IsFeatured { get; set; }
        public double? StartingPrice { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string IconLink { get; set; }
        public List<Picture> Pictures { get; set; }
        public string VideoLink { get; set; }
        public string ExternalLink { get; set; }
        public DbGeography Coordinates { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
        public string AddressString { get; set; }
        public int SportId { get; set; }
        [ForeignKey("SportId")]
        public Sport Sport { get; set; }
        public string SportName { get; set; }

        public int EventTypeId { get; set; }
        [ForeignKey("EventTypeId")]
        public EventType EventType { get; set; }
        public string EventTypeName { get; set; }

        public string OrganizerId { get; set; }
        [ForeignKey("OrganizerId")]
        public ApplicationUser Organizer { get; set; }
        public string OrganizerName { get; set; }

        public ICollection<ApplicationUser> BookmarkerVisitors { get; set; }
        public ICollection<ApplicationUser> RegisterRequestVisitors { get; set; }
        public ICollection<ApplicationUser> RegisteredVisitors { get; set; }


    }
}
