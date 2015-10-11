using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsEvents.Web.Models
{
    public class Address
    {
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public int CityId { get; set; }

        public string Zip { get; set; }
        public string State { get; set; }

    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public ICollection<Event> Events { get; set; }
        public int CountryId { get; set; }
    }

    public class Country

    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}