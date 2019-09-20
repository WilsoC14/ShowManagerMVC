using Microsoft.AspNet.Identity;
using ShowManager.Services;
using ShowManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowManager.Data;

namespace ShowManager.Controllers
{
    public class ShowController : Controller
    {
    private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Show Index
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ShowService(userID);
            var model = service.GetShows();
            return View(model);
        }
        // Get: Create Show
        public ActionResult Create()
        {
            ViewBag.VenueID = new SelectList(_db.Venues.ToList(), "VenueID", "VenueName");
            return View();
        }
        // Post: Create Show
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShowCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateShowService();
            if (service.CreateShow(model))
            {
                TempData["SaveResult"] = "Your Show was created.";
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Show could not be created");
            return View(model);
        }

        //Get: Edit
        public ActionResult Edit(int id)
        {
            var service = CreateShowService();
            var detail = service.GetShowByID(id);
            var model = new ShowEdit
            {
                ShowID = detail.ShowID,
                ShowName = detail.ShowName,
                Venue = detail.Venue,
                VenueID = detail.VenueID,
                VenueName = detail.VenueName,
                VenueType = detail.VenueType,
                Location = detail.Location,
                Artist = detail.Artist,
                ArtistID = detail.ArtistID,
                ArtistName = detail.ArtistName,
            };
            return View(model);
        }

        //Post: Edit
        public ActionResult Edit(int id, ShowEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.VenueID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateShowService();
            if (service.UpdateShow(model))
            {
                TempData["SaveResult"] = "Your show was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your show could not be updated.");
            return View();

        }

        //Get Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateShowService();
            var model = service.GetShowByID(id);
            return View(model);
        }

        //Post Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateShowService();
            service.DeleteShow(id);
            TempData["SaveResult"] = "Your show was deleted";
            return RedirectToAction("Index");
        }

        //Details
        public ActionResult Details(int id)
        {
            var service = CreateShowService();
            var model = service.GetShowByID(id);
            return View(model);
        }



        private ShowService CreateShowService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ShowService(userID);
            return service;
        }
    }
}