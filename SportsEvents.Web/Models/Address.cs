using System.Collections.Generic;

namespace SportsEvents.Web.Models
{
    public class Address
    {
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string CityId { get; set; }

    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public Country Country { get; set; }
        public ICollection<Event> Events { get; set; }
    }

    public class Country

    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}