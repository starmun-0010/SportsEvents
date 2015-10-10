using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using SportsEvents.Web.Models;

namespace SportsEvents.Web.ViewModels
{
    public class PostEventViewModel
    {
        public string UserName { get; set; }
        public List<Sport> Sports { get; set; }
        public List<EventType> EventTypes { get; set; }
        public List<City> Cities { get; set; }
        public List<Country> Countries { get; set; }
        public int EventTypeId { get; set; }
        public int SportId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public HttpPostedFileBase Icon { get; set; }
        public string Link { get; set; }
        public List<HttpPostedFileBase> Pictures { get; set; }
        public string VideoLink { get; set; }
        public string SocialMediaLink { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public bool IsReoccuring { get; set; }

        
        public List<Reoccurence> Reoccurences { get; set; }
        public string Zip { get; set; }

        public class Reoccurence
        {
            public string AddressLineOne { get; set; }
            public string AddressLineTwo { get; set; }
            public int CityId { get; set; }
            public int CountryId { get; set; }
            public DateTime BeginDate { get; set; }
            public DateTime EndDate { get; set; }
            public DateTime BeginTime { get; set; }
            public DateTime EndTime { get; set; }
        }
    }


}