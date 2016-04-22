using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SportsEvents.Web.Models;
using SportsEvents.Web.ViewModels;
using ControllerBase = SportsEvents.Web.Infrastructure.ControllerBase;

namespace SportsEvents.Web.Controllers
{
    public class OrganizerController : ControllerBase
    {
        // [Authorize(Roles = "Organizer")]
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        [Route("Organizer/Register", Name = "RegisterOrganizer")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        [Route("Dashboard/MyEvents")]
        public async Task<ActionResult> MyEvents()
        {
            var userId = User.Identity.GetUserId();
            var events = await Repository.Events.Where(e => e.OrganizerId == userId).Select(e => new MyEventsSummaryViewModel { Title = e.Description, ClicksCount = e.ClickerUsers.Count, SavesCount = e.BookmarkerVisitors.Count, Id = e.Id }).ToListAsync();
            return View(events);
        }

        [Route("Dashboard/RegistrationRequests")]
        public async Task<ActionResult> RegistrationRequests()
        {
            var userId = User.Identity.GetUserId();
            var requests = await
                DbContext.Events.Where(e => e.OrganizerId == userId && e.RegisterRequestVisitors.Count > 0)
                    .Select(
                        e =>
                            new RegistrationRequestsViewModel
                            {
                                Id = e.Id,
                                Description = e.Description,
                                UserInfo = e.RegisterRequestVisitors.Select(user => new RegistrationRequestsViewModel.User() { Id = user.Id, Name = user.UserName })

                            }).ToListAsync();

            return View(requests);
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("Organizer/Register")]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, Address = new Address() };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, false, false);
                    await UserManager.AddClaimAsync(user.Id, new Claim(ClaimTypes.Role, "OrganizerCandidate"));
                    return RedirectToAction("OrganizerInformation", "Account", new { name = User.Identity.Name });
                }
                AddErrors(result);
            }

            return View(model);
        }
        [Route("Dashboard/MyEvents/Edit/{id}")]
        public async Task<ActionResult> EditEvent(int id)
        {

            if (!await UserManager.Users.AnyAsync(user => user.Events.Any(e => e.Id == id)))
            {
                return new HttpUnauthorizedResult();
            }
            return View();

        }
    }

    public class RegistrationRequestsViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<User> UserInfo { get; set; }

        public class User
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}