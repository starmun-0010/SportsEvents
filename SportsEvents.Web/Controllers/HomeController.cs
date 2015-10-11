using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SportsEvents.Web.Infrastructure.Attributes;
using SportsEvents.Web.Repository;
using SportsEvents.Web.ViewModels;
using ControllerBase = SportsEvents.Web.Infrastructure.ControllerBase;

namespace SportsEvents.Web.Controllers
{
    public class HomeController : ControllerBase

    {
        public ActionResult Featured()
        {
            var model = Repository.Events.Where(e => e.IsFeatured).ToListAsync().Result;
            return PartialView(model);
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        public ActionResult Events(int skip = 0, int take = 20)
        {
            if (take > 20) take = 20;
            var eventsTask = Repository.Events.Where(e => e.BeginDate > DateTime.Now).OrderBy(e => e.BeginDate).Skip(skip).Take(take).ToListAsync();
            var countTask = Repository.Events.CountAsync(e => e.BeginDate > DateTime.Now);

            Task.WaitAll(eventsTask, countTask);
            var model = new EventsViewModel() { Events = eventsTask.Result, Count = countTask.Result, CurrentSkip = skip, CurrentTake = take };
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

        public ActionResult Adds()
        {

            var addsTask = Repository.Advertisements.Where(add => add.Prelogin).ToListAsync();

            return PartialView(addsTask.Result);
        }
    }
}