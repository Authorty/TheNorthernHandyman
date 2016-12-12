

using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Images()
        {
            try
            {
                //DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath(@"~\Content/Images"));
                //List<FileInfo> files = dirInfo.GetFiles().ToList();


                //return View(files);
                ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/Content/Images")).Select(fn => "~/Content/Images/" + Path.GetFileName(fn));

                return View();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

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

        public ActionResult SkidSteerPictures()
        {
            return View();

        }

        public ActionResult SnowRemovalPictures()
        {
            return View();

        }

        public ActionResult TreeRemovalPictures()
        {
            return View();

        }

        public ActionResult MowingPictures()
        {
            return View();

        }
        [HttpPost]
        public ActionResult MowingPictures(HttpPostedFileBase file)

        {
            var path = "";
                if(file=null)
            {
                if (file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                       || (Path.GetExtension(file.FileName).ToLower() == ".png"
                            || (Path.GetExtension(file.FileName).ToLower() == ".gif"
                            || (Path.GetExtension(file.FileName).ToLower() == ".jpeg"))))
                            {
                        path = Path.Combine(Server.MapPath("~/Content/Images"), file.FileName);
                        file.SaveAs(path);
                        ViewBag.UploadSuccess = true;
                    }
                }

            }

        }

    }

}