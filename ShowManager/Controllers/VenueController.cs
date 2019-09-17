using Microsoft.AspNet.Identity;
using System;
using ShowManager.Models;
using ShowManager.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShowManager.Controllers
{
    public class VenueController : Controller
    {
        // GET: Venue
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new VenueService(userID);
            var model = service.GetVenues();
            return View(model);
        }

        //Get: Create Venue
        public ActionResult Create()
        {
            return View();
        }

        //Post: Create Venue
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VenueCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            VenueService service = CreateNewVenueService();

            if (service.CreateVenue(model))
            {
                TempData["SaveResult"] = "Your Venue was created.";
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Venue could not be created");
            return View(model);

        }

        //Post: Edit
        public ActionResult Edit (int id)
        {
            var service = CreateNewVenueService();
            var artist = 
        }

        private VenueService CreateNewVenueService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new VenueService(userID);
            return service;
        }
    }
}