using Microsoft.AspNet.Identity;
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
    }
}