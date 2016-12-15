

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

        public ActionResult ContactEmail(ContactEmailModels e)
        {
            
                string ValidationMessage = String.Empty;

                ViewBag.Name = String.Empty;
                ViewBag.Email = String.Empty;
                ViewBag.Phone = String.Empty;
                ViewBag.Message = String.Empty;


                if (!String.IsNullOrEmpty(e.Name) && !String.IsNullOrEmpty(e.Message) && !String.IsNullOrEmpty(e.Phone) && !String.IsNullOrEmpty(e.Email))
                {
                    var emailmessage = new System.Web.Mail.MailMessage()
                    {
                        Subject = e.Name,
                        Body = "From: " + e.Name + "\n Phone Number: " + e.Phone + "\n Job Description: " + e.Message,
                        From = "thenorthernhandyman@thenorthernhandyman.org",
                        To = "itismejody@gmail.com",
                        BodyFormat = MailFormat.Text,
                        Priority = System.Web.Mail.MailPriority.High
                    };

                    System.Web.Mail.SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
                    SmtpMail.Send(emailmessage);
                    MessageBox("Email sent successfully!");
                    return RedirectToAction("Index", "Home", null);

                }
            

            //if (e.Name == "" || e.Name == null)
            //{
            //    ViewBag.Name = "Please add your name";
            //}


            //if (e.Phone == "" || e.Phone == null)
            //{
            //    ViewBag.Phone = "Please add your phone";

            //}


            //if (e.Message == "" || e.Message == null)
            //{
            //    ViewBag.Message = "Please add your Message";

            //}
            //if (e.Email == "" || e.Message == null)
            //{
            //    ViewBag.Email = "Please Add your Email";
            //}

            // TempData["Validation"] = ValidationMessage;
            //return new JavaScriptResult { Script = "alert('" + ValidationMessage + "');" };

            return View(e);
        }

        public EmptyResult MessageBox(string s)
        {
            Response.Write("<script type=\"text/javascript\">alert('" + s + "');</script>");
            return null;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = String.Empty;

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

                //var dir = Directory.EnumerateFiles(Server.MapPath("~/Content/Images")).Select(fn => "~/Content/Images/" + Path.GetFileName(fn));

                //return View(files);
                ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/Content/Images")).Select(fn => "~/Content/Images/" + Path.GetFileName(fn));


                return View(ViewBag.Images);
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
        public ActionResult Equipment()
        {
            return View();

        }
        public ActionResult FireWood()
        {
            return View();

        }


    }



}