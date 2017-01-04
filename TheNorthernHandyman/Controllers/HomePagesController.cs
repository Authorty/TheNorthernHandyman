using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;
using TheNorthernHandyman.Models;

namespace TheNorthernHandyman.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
       
        public ActionResult About()
        {
            ViewBag.Message = String.Empty;

            return View();
        }
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

            return View(e);
        }

        public EmptyResult MessageBox(string s)
        {
            Response.Write("<script type=\"text/javascript\">alert('" + s + "');</script>");
            return null;
        }

        public ActionResult Employment()
        {
            ViewBag.Message = "Would You Like To Join Our Team";
            return View();

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Services We Provide...";

            return View();
        }


    }
}