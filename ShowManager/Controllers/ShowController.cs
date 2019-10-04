using Microsoft.AspNet.Identity;
using ShowManager.Services;
using ShowManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowManager.Data;
using ShowManager.Models.ArtistShowData;

namespace ShowManager.Controllers
{
    [Authorize]
    public class ShowController : Controller
    {
    //private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Show Index
        public ActionResult Index()
        {
          //  var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ShowService();
            var model = service.GetShows();
            return View(model);
        }
        // Get: Create Show
        public ActionResult Create()
        {          
          //  var service = NewVenueService();
           // ViewBag.VenueID = new SelectList(service.GetVenues(), "VenueID", "VenueName");
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

            var service = NewShowService();
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
            var service = NewShowService();
            var detail = service.GetShowByID(id);
            var model = new ShowEdit
            {
                ShowID = detail.ShowID,
                ShowName = detail.ShowName,
                Venue = detail.Venue,
                VenueID = detail.VenueID,
                VenueName = detail.Venue.VenueName,
                VenueType = detail.Venue.VenueType,
                Location = detail.Venue.Location,

            };
            var venueService = NewVenueService();
            ViewBag.VenueID = new SelectList(venueService.GetVenues(), "VenueID", "VenueName");
            return View(model);
        }

        //Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShowEdit model)
        {
            var venueService = NewVenueService();
            if (!ModelState.IsValid)
            {
            ViewBag.VenueID = new SelectList(venueService.GetVenues(), "VenueID", "VenueName");
                return View(model);
            }
            if (model.ShowID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
            ViewBag.VenueID = new SelectList(venueService.GetVenues(), "VenueID", "VenueName");
                return View(model);
            }

            var service = NewShowService();
            if (service.UpdateShow(model))
            {
                TempData["SaveResult"] = "Your show was updated.";
                return RedirectToAction("Index");
            }

            ViewBag.VenueID = new SelectList(venueService.GetVenues(), "VenueID", "VenueName");
            ModelState.AddModelError("", "Your show could not be updated.");
            return View();

        }

        //Get Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = NewShowService();
            var model = service.GetShowByID(id);
            return View(model);
        }

        //Post Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = NewShowService();
            service.DeleteShow(id);
            TempData["SaveResult"] = "Your show was deleted";
            return RedirectToAction("Index");
        }

        //Details
        public ActionResult Details(int id)
        {
            var service = NewShowService();
            var model = service.GetShowByID(id);
            return View(model);
        }



        //Get Add ArtistShowData to Show
        public ActionResult AddArtistToShow(int showID)
        {
          
            var artistShowDataService = NewArtistShowDataService();
            var model = artistShowDataService.GetAddArtistToShowModel(showID);
            //not sure about view
            ViewBag.ArtistID = new SelectList(NewArtistService().GetArtists(), "ArtistID", "ArtistName");
            return View(model);
        }


        //Post Add ArtistShowData to Show
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddArtistToShow(AddArtistToShowModel model)
        {
            var artistService = NewArtistService();
            if (!ModelState.IsValid)
            {
                ViewBag.ArtistID = new SelectList(artistService.GetArtists(), "ArtistID", "ArtistName");
                return View(model);
            }

            if (NewArtistShowDataService().AddArtistShowDataToDataTable(model))
            {
                TempData["SaveResult"] = "Artist was added to show.";
                var id = model.ShowID;
                return RedirectToAction("Details", new { id = model.ShowID });
            }
            else
                ModelState.AddModelError("", "Artist could not be added");
            return View(model);


           // if(NewArtistShowDataService().)

           // bool artistAdded = artistShowDataService.PostAddArtistToShowModel(artistID, model);
            //if (artistAdded == true && artistID == model.ArtistID)
            //{
            //    artistShowDataService.AddArtistShowDataToDataTable(model);
            //    TempData["SaveResult"] = "Artist added to Show.";
            //    return View(model);
            //}
            //else
            //    ModelState.AddModelError("", "Artist could not be added to show");
            //return View(model);
        }

           


            //var artistShowDataService = NewArtistShowDataService();
            //artistShowDataService.AddArtistIDToArtistShowDataCreate(artistID, model);

        




        private ShowService NewShowService()
        {
          //  var userID = Guid.Parse(User.Identity.GetUserId());
            var showService = new ShowService();
            return showService;
        }
        //remove Guid functionality
        private VenueService NewVenueService()
        {
            
                //var userID = Guid.Parse(User.Identity.GetUserId());
                var venueService = new VenueService();
                return venueService;
            
        }
        private ArtistService NewArtistService()
        {
            //  var userID = Guid.Parse(User.Identity.GetUserId());
            var artistService = new ArtistService();
            return artistService;

        }

        private ArtistShowDataService NewArtistShowDataService()
        {
            var artistShowDataService = new ArtistShowDataService();
            return artistShowDataService;
        }
    }
}