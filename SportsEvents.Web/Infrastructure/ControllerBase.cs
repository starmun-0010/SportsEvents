using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using SportsEvents.Web.Repository;

namespace SportsEvents.Web.Infrastructure
{
    public class ControllerBase : Controller
    {
        private SportsEventsDbContext _dbContext;
        private SportsEventsRepository _repository;
        private ApplicationUserManager _userManager;

        public SportsEventsRepository Repository => _repository ?? (_repository = new SportsEventsRepository(DbContext))
            ;

        public ApplicationUserManager UserManager => _userManager ??
                                                     (_userManager =
                                                         HttpContext.GetOwinContext()
                                                             .GetUserManager<ApplicationUserManager>());

        public SportsEventsDbContext DbContext => _dbContext ??
                                                   (_dbContext =
                                                       HttpContext.GetOwinContext().Get<SportsEventsDbContext>());
    }
}