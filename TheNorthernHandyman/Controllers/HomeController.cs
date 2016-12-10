

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheNorthernHandyman.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = String.Empty;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How To Contact Me....";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Services We Provide...";

            return View();
        }



    }
}