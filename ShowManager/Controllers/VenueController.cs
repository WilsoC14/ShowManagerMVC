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
    [Authorize]
    public class VenueController : Controller
    {
        // GET: Venue
        public ActionResult Index()
        {
           // var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new VenueService();
            var model = service.GetVenues();
           
            return View(model);
        }

        //Get: Create Venue
        public ActionResult Create()
        {
            var service = new VenueService();
           // var model = service.GetVenues();
            
        //    ViewBag.VenueType = new SelectList();
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
            VenueService service = NewVenueService();

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
            var service = NewVenueService();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
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

            var service = NewVenueService();
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
            var service = NewVenueService();
            var model = service.GetVenueByID(id);
            return View(model);
        }

        //Post Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = NewVenueService();
            service.DeleteVenue(id);
            TempData["SaveResult"] = "Your venue was deleted";
            return RedirectToAction("Index");
        }

        //Details
        //Details
        public ActionResult Details(int id)
        {
            var service = NewVenueService();
            var model = service.GetVenueByID(id);
            return View(model);
        }

        




        private VenueService NewVenueService()
        {
           // var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new VenueService();
            return service;
        }
    }
}