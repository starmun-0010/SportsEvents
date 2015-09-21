using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsEvents.Web.Models;
using SportsEvents.Web.Repository;
using ControllerBase = SportsEvents.Web.Infrastructure.ControllerBase;

namespace SportsEvents.Web.Controllers
{
    public class HomeController : ControllerBase

    {
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult Events(int skip = 0, int take = 20)
        {
            if (take > 20) take = 20;
            var events = Repository.Events.Where(e => e.BeginDate > DateTime.Now).OrderBy(e => e.BeginDate).Skip(skip).Take(take);
            var count = Repository.Events.Count(e => e.BeginDate > DateTime.Now);
            var model = new EventsViewModel() { Events = events, Count = count, CurrentSkip = skip, CurrentTake = take };
            return PartialView(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class EventsViewModel
    {
        public IQueryable<Event> Events { get; set; }
        public int Count { get; set; }
        public int CurrentSkip { get; set; }
        public int CurrentTake { get; set; }
    }
}