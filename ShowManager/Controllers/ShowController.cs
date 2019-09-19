using Microsoft.AspNet.Identity;
using ShowManager.Services;
using ShowManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShowManager.Controllers
{
    public class ShowController : Controller
    {
        // GET: Show
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ShowService(userID);
            var model = service.GetVenues();
            return View(model);
        }
    }
}