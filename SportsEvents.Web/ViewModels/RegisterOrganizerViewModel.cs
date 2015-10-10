using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using SportsEvents.Web.CustomAttirbutes;
using SportsEvents.Web.Models;

namespace SportsEvents.Web.ViewModels
{
    public class RegisterOrganizerViewModel
    {
        public List<Country> Countries { get; set; }

        [Url(ErrorMessage = "Not a valid URL.")]
        public string Link { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name can only have capital or small alphabets.")]
        [MaxLength(20, ErrorMessage = "Maximum 20 Characters Allowed")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name can only have capital or small alphabets.")]
        [MaxLength(20, ErrorMessage = "Maximum 20 Characters Allowed")]
        public string LastName { get; set; }

        //address
        [MaxLength(120, ErrorMessage = "Maximum 120 Characters Allowed")]
        public string LineOne { get; set; }

        [MaxLength(120, ErrorMessage = "Maximum 120 Characters Allowed")]
        public string LineTwo { get; set; }

        public int CityId { get; set; }
        public int CountryId { get; set; }

        public List<City> Cities { get; set; }
        //Contact  Address
        [Required]
        [RegularExpression(@"^[a-zA-Z]+\s?[a-zA-Z]+$", ErrorMessage = "Contact Name can only have alphabets and spaces.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 Characters Allowed")]
        public string ContactName { get; set; }

        [Required]
        [MaxLength(120, ErrorMessage = "Maximum 120 Characters Allowed")]
        public string ContactLineOne { get; set; }

        [Required]
        [MaxLength(120, ErrorMessage = "Maximum 120 Characters Allowed")]
        public string ContactLineTwo { get; set; }

        [Required]
        public int ContactCountryId { get; set; }

        [Required]
        public int ContactCityId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Maximum 50 Characters Allowed")]
        [RegularExpression(@"^([a-zA-Z]+\s?)+$", ErrorMessage = "Organization Name can only have alphabets and spaces.")]

        public string OrganizationName { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum 500 Characters Allowed")]
        public string OrganizationDecription { get; set; }

        [MaxFileSize(1024 * 1024, ErrorMessage = "Maximum allowed file size is {0} MB")]
        public HttpPostedFileBase OrganaiztionLogo { get; set; }
    }
}