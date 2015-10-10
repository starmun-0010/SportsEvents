using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Newtonsoft.Json.Serialization;
using SportsEvents.Web.CustomAttirbutes;
using SportsEvents.Web.Models;

namespace SportsEvents.Web.ViewModels
{
    public class RegisterOrganizerViewModel
    {
        public List<Country> Countries { get; set; }

        [Url(ErrorMessage = "Not a valid URL.")]
        [Display(Name = "Organization Website")]
        public string Link { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name can only have capital or small alphabets.")]
        [MaxLength(20, ErrorMessage = "Maximum 20 Characters Allowed.")]
        [Display(Name = "First Name")]
        [MinLength(3, ErrorMessage = "Minimum 3 characters required.")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name can only have capital or small alphabets.")]
        [MaxLength(20, ErrorMessage = "Maximum 20 Characters Allowed")]
        [MinLength(3, ErrorMessage = "Minimum 3 characters required.")]

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //address
        [MaxLength(120, ErrorMessage = "Maximum 120 Characters Allowed")]
        [Display(Name = "Line One")]
        [MinLength(10, ErrorMessage = "Minimum 10 characters required.")]

        public string LineOne { get; set; }
        [Display(Name = "Line Two")]

        [MaxLength(120, ErrorMessage = "Maximum 120 Characters Allowed")]
        public string LineTwo { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public List<City> Cities { get; set; }
        //Contact  Address
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Contact Name can only have alphabets and spaces.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 Characters Allowed")]
        [MinLength(3, ErrorMessage = "Minimum 3 characters required.")]

        [Display(Name = "First Name*")]
        public string ContactFirstName { get; set; }
        [Display(Name = "Last Name*")]
        [MinLength(3, ErrorMessage = "Minimum 3 characters required.")]

        public string ContactLastName { get; set; }
        [Required]
        [MaxLength(120, ErrorMessage = "Maximum 120 Characters Allowed")]
        [Display(Name = "Address Line One*")]
        [MinLength(10)]

        public string ContactLineOne { get; set; }

        [Required]
        [Display(Name = "Address Line Two*")]

        [MaxLength(120, ErrorMessage = "Maximum 120 Characters Allowed")]
        public string ContactLineTwo { get; set; }

        [Required]
        [Display(Name = "Country*")]

        public int ContactCountryId { get; set; }

        [Required]
        [Display(Name = "City*")]
        public int ContactCityId { get; set; }
        [Required]
        [Display(Name = "State")]
        public string ContactState { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email*")]
        public string ConatactEmail { get; set; }

        [Display(Name = "Zip")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$",ErrorMessage = "Invalid zip code.")]
        public int Zip { get; set; }
        
        [Required]
        [Display(Name = "Zip")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Invalid zip code.")]
        public int ContactZip { get; set; }
        [RegularExpression(@"\d*", ErrorMessage = "Invalid phone number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [RegularExpression(@"\d*",ErrorMessage = "Invalid phone number.")]
        [Display(Name = "Phone Number")]
        public string ContactPhone { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum 50 Characters Allowed")]
        [MinLength(5, ErrorMessage = "Minimum 5 characters required.")]

        [RegularExpression(@"^([a-zA-Z]+\s?)+$", ErrorMessage = "Organization Name can only have alphabets and spaces.")]
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }

        [Display(Name = "Organization Description")]

        [MaxLength(500, ErrorMessage = "Maximum 500 Characters Allowed")]
        [MinLength(50, ErrorMessage = "Minimum 50 characters required.")]

        public string OrganizationDecription { get; set; }
        [Display(Name = "Organization Logo")]

        [MaxFileSize(1024 * 1024, ErrorMessage = "Maximum allowed file size is {0} MB")]
        public HttpPostedFileBase OrganaiztionLogo { get; set; }
    }
}