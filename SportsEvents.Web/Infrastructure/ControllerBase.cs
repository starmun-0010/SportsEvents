using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SportsEvents.Web.Repository;

namespace SportsEvents.Web.Infrastructure
{
    public class ControllerBase : Controller
    {
        private SportsEventsRepository _repository;
        private ApplicationUserManager _userManager;
        private SportsEventsDbContext _dbContext;
        private ApplicationSignInManager _signInManager;

        public ControllerBase(SportsEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected  override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var sportsTask = DbContext.Sports.ToList();
            var eventTypeTask = DbContext.EventTypes.ToList();

            ViewData["Sports"] = sportsTask;
            ViewData["EventTypes"] = eventTypeTask;
            ViewData["Countries"] = DbContext.Countries.ToList();
        }

        protected ControllerBase() : this(new SportsEventsDbContext())
        {
            if (User != null && User.Identity.IsAuthenticated)
            {
                ViewBag.NotificatonsCount =
                    Repository.Events.Where(e => e.OrganizerId == User.Identity.GetUserId())
                        .Sum(e => e.RegisterRequestVisitors.Count);
                ViewBag.MessagesCount =
                    UserManager.Users.Where(e => e.Id == User.Identity.GetUserId()).Sum(e => e.Messages.Count);

            }
        }

        public SportsEventsRepository Repository => _repository ?? (_repository = new SportsEventsRepository(DbContext))
            ;

        public ApplicationUserManager UserManager => _userManager ??
                                                     (_userManager =
                                                         HttpContext.GetOwinContext()
                                                             .GetUserManager<ApplicationUserManager>());


        public SportsEventsDbContext DbContext => _dbContext ??
                                                   (_dbContext =
                                                       HttpContext.GetOwinContext().Get<SportsEventsDbContext>());

        public ApplicationSignInManager SignInManager => _signInManager ?? (_signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>());


        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }


    }
}
