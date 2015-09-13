﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace SportsEvents.Web.Models
{
    public class Event
    {
        public int Id { get; set; }
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
        public DbGeography Coordinates { get; set; }
        public Organizer Organizer { get; set; }
        public List<Visitor> BookmarkerVisitors { get; set; }
        public List<Visitor> RegisterRequestVisitors { get; set; }
        public List<Visitor> RegisteredVisitors { get; set; }


    }
}
