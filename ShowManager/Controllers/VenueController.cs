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

        //Get: Edit
        public ActionResult Edit(int id)
        {
            var service = CreateNewVenueService();
            var detail = service.GetVenueByID(id);
            var model = new VenueEdit
            {
                VenueID = detail.VenueID,
                VenueName = detail.VenueName,
                VenueType = detail.VenueType,
                Location = detail.Location
            };
            return View(model);
        }

        //Post: Edit
        public ActionResult Edit(int id, VenueEdit model)
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

            var service = CreateNewVenueService();
            if (service.UpdateVenue(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your note could not be updated.");
            return View();

        }

        //Get Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateNewVenueService();
            var model = service.GetVenueByID(id);
            return View(model);
        }

        //Post Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateNewVenueService();
            service.DeleteVenue(id);
            TempData["SaveResult"] = "Your venue was deleted";
            return RedirectToAction("Index");
        }
        private VenueService CreateNewVenueService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new VenueService(userID);
            return service;
        }
    }
}