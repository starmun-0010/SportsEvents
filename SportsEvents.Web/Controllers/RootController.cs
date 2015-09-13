using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SportsEvents.Web.Models;
using SportsEvents.Web.Repository;
using ControllerBase = SportsEvents.Web.Infrastructure.ControllerBase;

namespace SportsEvents.Web.Controllers
{
    public class RootController : ControllerBase
    {

        // GET: Root
        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> Enable()
        {
            //Not authorized if request is not local
            if (!Request.IsLocal)
            {
                ViewBag.Message = "Not Authorized";
                return View();
            }
            //if role admin does not exist, create it
            if (!await DbContext.Roles.AnyAsync(role => role.Name == "admin"))
            {
                DbContext.Roles.Add(new IdentityRole() { Name = "admin" });
                await DbContext.SaveChangesAsync();
            }
            //if user root does not exist create it
            ApplicationUser user;
            if (!await UserManager.Users.AnyAsync(usr => usr.UserName == "root"))
            {
                user = new ApplicationUser() { UserName = "root", Email = "root@root.com" };
                var rootCreateResult = await UserManager.CreateAsync(user, "Root1_");

                if (!rootCreateResult.Succeeded)
                {
                    foreach (var error in rootCreateResult.Errors)
                    {
                        ViewBag.Message += error;
                    }
                    return View();
                }
            } //if user root exists and role is not assigned, get the user
            else
            {
                user = await UserManager.Users.SingleAsync(e => e.UserName == "root");
            }
            // if user is not in role then assign the role
            if (!await UserManager.IsInRoleAsync(user.Id, "admin"))
            {
                var rootRoleResult = await UserManager.AddToRoleAsync(user.Id, "admin");
                if (!rootRoleResult.Succeeded)
                {
                    foreach (var error in rootRoleResult.Errors)
                    {
                        ViewBag.Message += error;
                    }
                    return View();
                }

            }
            else
            {
                ViewBag.Message = "Root Already Exists";
                return View();

            }

            ViewBag.Message = "Root Successfuly Created";
            return View();
        }
    }
}