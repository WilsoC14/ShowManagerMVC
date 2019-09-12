using Microsoft.AspNet.Identity;
using ShowManager.Models;
using ShowManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShowManager.Controllers
{
    [Authorize]
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService(userID);
            var model = service.GetArtists();
            return View(model);
        }

        //Get: Create Artist
        public ActionResult Create()
        {
            return View();
        }

        //Post: Create Artist
        //Artist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtistCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
           var service =CreateArtistService();
            service.CreateArtist(model);

            if (service.CreateArtist(model))
            {
                TempData["SaveResult"] = "Your Artist was created.";
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Artist could not be created");
            return View(model);

        }

        private ArtistService CreateArtistService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService(userID);
            return service;

        }
    }
}