using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using SportsEvents.Web.CustomAttirbutes;
using SportsEvents.Web.Models;

namespace SportsEvents.Web.ViewModels
{
    public class PostEventViewModel
    {
        public List<Sport> Sports { get; set; }
        public List<EventType> EventTypes { get; set; }
        public List<City> Cities { get; set; }
        public List<Country> Countries { get; set; }

        [Display(Name = "Event Type")]
        [Required(ErrorMessage = "Event Type is required.")]
        public int? EventTypeId { get; set; }

        [Display(Name = "Sport")]
        [Required(ErrorMessage = "Sport is required.")]
        public int? SportId { get; set; }

        [Display(Name = "Event Title")]
        [Required(ErrorMessage = "Event Title is required.")]
        [MinLength(5, ErrorMessage = "Eveint Title requires minimum 5 characters.")]
        [MaxLength(40, ErrorMessage = "Maximum 40 characters are allowed for event title.")]
        public string Title { get; set; }

        [Display(Name = "Event Description")]
        [Required(ErrorMessage = "Event Description is required.")]
        [MinLength(10, ErrorMessage = "Eveint Description requires minimum 5 characters.")]
        [MaxLength(500, ErrorMessage = "Maximum 500 characters are allowed for event Description.")]
        public string Description { get; set; }

        [Display(Name = "Event Price")]
        [Required(ErrorMessage = "Event Price is required.")]
        [Range(0.0, 100000.0, ErrorMessage = "Price can be between 0 and 100000")]
        public double Price { get; set; }

        [Display(Name = "Event Begin Date")]
        [Required(ErrorMessage = "Event Begin Date is required.")]
        [DataType(DataType.Date)]

        public DateTime BeginDate { get; set; }

        [Display(Name = "Event End Date")]
        [Required(ErrorMessage = "Event End Date is required.")]
        [DataType(DataType.Date)]
        [GreaterOrEqualDate("BeginDate", "End date value should be larger or equal to Start date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Event Start Time")]
        [Required(ErrorMessage = "Event Start Time is required.")]
        [DataType(DataType.Time)]

        public DateTime BeginTime { get; set; }

        [Display(Name = "Event End Time")]
        [Required(ErrorMessage = "Event End Time is required.")]
        [DataType(DataType.Time)]
        [GreaterOrEqualTime("BeginDate", "End Time value should be larger or equal to Start Time")]

        public DateTime EndTime { get; set; }

        [MaxFileSize(1024 * 1024)]
        public HttpPostedFileBase Icon { get; set; }

        [Display(Name = "Event's Pictures")]
        public List<HttpPostedFileBase> Pictures { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        [Display(Name = "Event Related Video Link")]
        public string VideoLink { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        [Display(Name = "Event's Socail Medial Link")]
        public string SocialMediaLink { get; set; }

        [Required(ErrorMessage = "Address Line One is required")]
        [MaxLength(120, ErrorMessage = "Maximum 120 Characters Allowed")]
        [Display(Name = "Address Line One")]
        [MinLength(10)]
        public string AddressLineOne { get; set; }

        [MaxLength(120, ErrorMessage = "Maximum 120 Characters Allowed")]
        [Display(Name = "Address Line Two")]
        [MinLength(10)]
        public string AddressLineTwo { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public int? CityId { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        [Required(ErrorMessage = "Zip Code is required.")]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }
    }
}

public class Reoccurence
{
    public List<Reoccurence> Reoccurences { get; set; }
    public string AddressLineOne { get; set; }
    public string AddressLineTwo { get; set; }
    public int CityId { get; set; }
    public int CountryId { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime BeginTime { get; set; }
    public DateTime EndTime { get; set; }
}