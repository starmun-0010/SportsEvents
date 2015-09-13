using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using SportsEvents.Web.Repository;

namespace SportsEvents.Web.Infrastructure
{
    public class ControllerBase : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _dbContext;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ??
                       (_userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>());
            }
            set { _userManager = value; }
        }
        public ApplicationDbContext DbContext
        {
            get
            {
                return _dbContext ??
                       (_dbContext = HttpContext.GetOwinContext().Get<ApplicationDbContext>());
            }
            set { _dbContext = value; }
        }
    }
}