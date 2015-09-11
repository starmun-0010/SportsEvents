using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using SportsEvents.Web.Models;

namespace SportsEvents.Web.Controllers
{
    public class RootController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        // GET: Root
        public ActionResult Index()
        {
            return View();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ??
                       HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set { _userManager = value; }
        }

        public async Task<ActionResult> Enable()
        {
            ViewBag.Message = "Root Already Exists";
            if (!await context.Users.AnyAsync(user => user.UserName == "root"))
            {
                await UserManager.CreateAsync(new ApplicationUser() { UserName = "root@root.com", Email = "root@root.com" },"Root1_");

                var result = await UserManager.AddToRoleAsync("root", "admin");
                if (result.Succeeded)
                {
                    ViewBag.Message = "Root Successfuly Created";
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ViewBag.Message += error;
                    }
                }
            }
           
            return View();
        }
    }
}