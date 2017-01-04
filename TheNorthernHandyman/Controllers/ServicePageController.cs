using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheNorthernHandyman.Controllers
{
    public class ServicePageController : Controller
    {
        // GET: ServicePage
        public ActionResult MowingAlbums()
        {
            return View();
        }
        public ActionResult ProjectAlbums()
        {
            return View();
        }
        public ActionResult SkidSteerWorkAlbums()
        {
            return View();
        }
        public ActionResult SnowRemovalAlbums()
        { 
            return View();
        }
        public ActionResult TreeRemovalAlbums()
        {
            return View();
        }
    }
}