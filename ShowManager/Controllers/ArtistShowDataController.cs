using System;
using ShowManager.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowManager.Models.ArtistShowData;

namespace ShowManager.Controllers
{
    public class ArtistShowDataController : Controller
    {
        // Get: Existing Artists To Add Artist to Show
        public ActionResult AddExistingArtistToExistingShow(int showID)
        {
            var service = NewASDService();
            var artistService = NewArtistService();
            ViewBag.ArtistID = new SelectList(artistService.GetArtists(), "ArtistID", "ArtistName");

            return View();
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddArtist (int showID, ArtistShowDataCreate model)

        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = NewASDService();

            if (service.AddShowToAsdObject(showID, model))
            {
                TempData["SaveResult"] = "Your Show was created.";
                return RedirectToAction("AddExistingArtistToExistingShow");
            }
            else
                ModelState.AddModelError("", "Show could not be created");
            return View(model);

        }




        // GET: ArtistShowData
        public ActionResult Index()
        {
            return View();
        }


        // New ArtistShowDataService
        private ArtistShowDataService NewASDService()
        {
            var service = new ArtistShowDataService();
            return service;
        }

        // New Artist Service
        private ArtistService NewArtistService()
        {
            //  var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService();
            return service;

        }
    }
}