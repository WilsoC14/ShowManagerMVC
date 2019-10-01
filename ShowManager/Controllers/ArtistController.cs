﻿using Microsoft.AspNet.Identity;
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
            

            if (service.CreateArtist(model))
            {
                TempData["SaveResult"] = "Your Artist was created.";
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Artist could not be created");
            return View(model);

        }

        //Get: Edit
        
            public ActionResult Edit (int id)
        {
            var service = CreateArtistService();
            var artist = service.GetArtistByID(id);
            var model =
                        new ArtistEdit
                        {
                            ArtistID = artist.ArtistID,
                            ArtistName = artist.ArtistName,
                            Location = artist.Location
                        };
            return View(model);
        }

        //Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, ArtistEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.ArtistID != id) 
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateArtistService();
            if (service.UpdateArtist(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Artist could not be updated.");
            return View();
        }


        //Get Delete
        [ActionName("Delete")]
        public ActionResult Delete (int id)
        {
            var service = CreateArtistService();
            var model = service.GetArtistByID(id);
            return View(model);
        }

        //Post Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateArtistService();
            service.DeleteArtist(id);
            TempData["SaveResult"] = "Your note was deleted";
            return RedirectToAction("Index");
        }
        
        //Details
        public ActionResult Details(int id)
        {
            var service = CreateArtistService();
            var model = service.GetArtistByID(id);
            return View(model);
        }


        private ArtistService CreateArtistService()
        {
          //  var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService();
            return service;

        }
    }
}