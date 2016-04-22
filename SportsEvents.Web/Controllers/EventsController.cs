using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SportsEvents.Web.Models;
using SportsEvents.Web.Repository;
using SportsEvents.Web.ViewModels;
using SportsEvents.Web.ViewModels.EventViewModels;
using ControllerBase = SportsEvents.Web.Infrastructure.ControllerBase;
namespace SportsEvents.Web.Controllers
{
    [Authorize]
    public class EventsController : ControllerBase
    {

        // GET: Events
        public async Task<ActionResult> Index()
        {
            return View(await DbContext.Events.ToListAsync());
        }
        public async Task<ActionResult> Search(string searchText)
        {
            return View(await DbContext.Events.Where(e => e.Sport.Name == searchText).ToListAsync());
        }
        // GET: Events/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = await DbContext.Events.FindAsync(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        [Authorize(Roles = "Organizer, Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Organizer, Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EventCreateViewModel eventViewModel)
        {


            if (ModelState.IsValid)
            {
                var sportTask = DbContext.Sports.SingleAsync(s => s.Name == eventViewModel.Sport);
                var eventTypeTask = DbContext.EventTypes.SingleAsync(e => e.Name == eventViewModel.EventType);
                var iconLinkTask = PictureService.CreateLink(eventViewModel.Icon);
                var picturesTask = PictureService.CreateLinks(eventViewModel.Picture);
                var organizerTask = DbContext.Users.SingleAsync(e => e.Id == User.Identity.GetUserId());
                await Task.WhenAll(sportTask, eventTypeTask, iconLinkTask, picturesTask);

                var sport = sportTask.Result;
                var eventType = eventTypeTask.Result;

                var iconLink = iconLinkTask.Result;
                var pictures = picturesTask.Result;
                var organizer = organizerTask.Result;
                var coordinates = DbGeography.FromText(eventViewModel.Latitude?.ToString() + eventViewModel.Longitude?.ToString());
                if (sport == null)
                {
                    sport = new Sport() { Name = eventViewModel.Sport };
                    DbContext.Sports.Add(sport);
                }
                if (eventType == null)
                {
                    eventType = new EventType() { Name = eventViewModel.EventType };
                    DbContext.EventTypes.Add(eventType);
                }
                var @event = new Event() { BeginDate = eventViewModel.BeginDate, EndDate = eventViewModel.EndDate, Description = eventViewModel.Description, Details = eventViewModel.Details, Sport = sport, EventType = eventType, ExternalLink = eventViewModel.ExternalLink, Pictures = pictures, StartingPrice = eventViewModel.StartingPrice, VideoLink = eventViewModel.VideoLink, Organizer = organizer, Coordinates = coordinates };
                await Repository.Events.AddAsync(@event);
                return RedirectToAction("Index");
            }

            return View(eventViewModel);
        }

        // GET: Events/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = await DbContext.Events.FindAsync(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StartingPrice,BeginDate,EndDate,Address,Description,Details,IconLink,VideoLink,ExternalLink,Coordinates")] Event @event)
        {
            if (ModelState.IsValid)
            {
                DbContext.Entry(@event).State = EntityState.Modified;
                await DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = await DbContext.Events.FindAsync(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Event @event = await DbContext.Events.FindAsync(id);
            DbContext.Events.Remove(@event);
            await DbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbContext.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult PostEvent()
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result;

            ClaimsIdentity identity = UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie).Result;

            if (!identity.HasClaim(e => e.Type == "IsOrganizer" && e.Value == "true"))
            {
                return RedirectToAction("OrganizerInformation", "Account", new { name = User.Identity.Name });
            }
            var model = new PostEventViewModel();
            var eventTypesTask = Repository.EventTypes.AllAsync();
            var sportsTask = Repository.Sports.AllAsync();
            var countriesTask = Repository.Countries.AllAsync();
            Task.WaitAll(eventTypesTask, sportsTask, countriesTask);
            model.EventTypes = eventTypesTask.Result;
            model.Sports = sportsTask.Result;
            model.Countries = countriesTask.Result;
            model.Cities = new List<City>();
            model.BeginDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            model.BeginTime = DateTime.Now;
            model.EndTime = DateTime.Now;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PostEvent(PostEventViewModel model)
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result;

            ClaimsIdentity identity = UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie).Result;

            if (!identity.HasClaim(e => e.Type == "IsOrganizer" && e.Value == "true"))
            {
                return RedirectToAction("OrganizerInformation", "Account", new { name = User.Identity.Name });
            }
            if (ModelState.IsValid)
            {
                var city = await Repository.Cities.GetAsync(model.CityId);
                var eventType = await Repository.EventTypes.GetAsync(model.EventTypeId);
                var sport = await Repository.Sports.GetAsync(model.SportId);
                var address = new Address()
                {
                    CityId = model.CityId ?? 0,
                    CountryName = city.CountryName,
                    Zip = model.Zip,
                    LineTwo = model.AddressLineTwo,
                    LineOne = model.AddressLineOne,
                    CityName = city.Name
                };
                byte[] icon = null;
                using (var inputStream = model.Icon?.InputStream)
                {
                    var memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        var copyToAsync = inputStream?.CopyToAsync(memoryStream);
                        if (copyToAsync != null)
                            await copyToAsync;
                    }
                    icon = memoryStream.ToArray();
                }
                var @event = new Event()
                {
                    OrganizerId = User.Identity.GetUserId(),
                    Address = address,
                    AddressString = address.ToString(),
                    BeginDate = model.BeginDate,
                    BeginTime = model.BeginTime,
                    EndTime = model.EndTime,
                    EndDate = model.EndDate,
                    Description = model.Title,
                    EventTypeId = eventType.Id,
                    EventTypeName = eventType.Name,
                    SportId = sport.Id,
                    CityId = city.Id,
                    SportName = sport.Name,
                    Details = model.Description,
                    VideoLink = model.VideoLink,
                    StartingPrice = model.Price,
                    Icon = icon,
                    ExternalLink = model.SocialMediaLink,
                    OrganizerName = user.UserName,
                    
                };
                Console.WriteLine(await Repository.Events.AddAsync(@event));
                return RedirectToAction("Dashboard", "Organizer");
            }
            var eventTypesTask = Repository.EventTypes.AllAsync();
            var sportsTask = Repository.Sports.AllAsync();
            var countriesTask = Repository.Countries.AllAsync();
            var cityTask = Repository.Cities.AllAsync();
            Task.WaitAll(eventTypesTask, sportsTask, countriesTask, cityTask);
            model.EventTypes = eventTypesTask.Result;
            model.Sports = sportsTask.Result;
            model.Countries = countriesTask.Result;

            model.Cities = cityTask.Result;
            return View(model);
        }
    }
}
