using System.Web.Mvc;
using ControllerBase = SportsEvents.Web.Infrastructure.ControllerBase;

namespace SportsEvents.Web.Controllers
{
    public class OrganizerController : ControllerBase
    {
        public ActionResult ControlPanel()
        {
            return View();
        }
    }
}