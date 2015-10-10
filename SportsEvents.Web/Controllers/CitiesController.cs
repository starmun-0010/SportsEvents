using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllerBase = SportsEvents.Web.Infrastructure.ControllerBase;

namespace SportsEvents.Web.Controllers
{
    public class CitiesController : ControllerBase
    {
        // GET: Cities
        [Route("Countries/{countryId}/Cities")]
        public ActionResult GetCities(int countryId)
        {
            var cities = Repository.Cities.Where(e => e.CountryId == countryId).ToListAsync().Result;
            return PartialView(cities);
        }
    }
}