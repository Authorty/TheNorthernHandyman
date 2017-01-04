

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;
using TheNorthernHandyman.Models;

namespace TheNorthernHandyman.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult ImagesSideBar()
        {
            try
            {
                //DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath(@"~\Content/Images"));
                //List<FileInfo> files = dirInfo.GetFiles().ToList();


                //return View(files);
                ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/Content/Images")).Select(fn => "~/Content/Images/" + Path.GetFileName(fn));

                return PartialView(ViewBag.Images);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public ActionResult VideoSlider()
        {
            ViewBag.Message = "Videos";

            return View();
        }
        public ActionResult SideBarLocationIndicator2()
        {
            ViewBag.Message = "Videos";

            return View();
        }
    }



}