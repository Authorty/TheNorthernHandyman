using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;
using TheNorthernHandyman.Models;

namespace TheNorthernHandyman.Controllers
{
    public class ContactEmailModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactEmailModels
        public ActionResult Index()
        {
            return View(db.ContactEmailModels.ToList());
        }

        // GET: ContactEmailModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEmailModels contactEmailModels = db.ContactEmailModels.Find(id);
            if (contactEmailModels == null)
            {
                return HttpNotFound();
            }
            return View(contactEmailModels);
        }

        // GET: ContactEmailModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactEmailModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Phone,Message")] ContactEmailModels contactEmailModels)
        {
            if (ModelState.IsValid)
            {
                db.ContactEmailModels.Add(contactEmailModels);
                db.SaveChanges();


                var emailmessage = new System.Web.Mail.MailMessage()
                {
                    Subject = contactEmailModels.Name,
                    Body = "From: " + contactEmailModels.Name + "\n Phone Number: " + contactEmailModels.Phone + "\n Job Description: " + contactEmailModels.Message,
                    From = "thenorthernhandyman@thenorthernhandyman.org",
                    To = "itismejody@gmail.com",
                    BodyFormat = MailFormat.Text,
                    Priority = System.Web.Mail.MailPriority.High
                };

                System.Web.Mail.SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
                SmtpMail.Send(emailmessage);
                //return RedirectToAction("Index","Home",null);
                return View();
            }

            return View(contactEmailModels);
        }

        // GET: ContactEmailModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEmailModels contactEmailModels = db.ContactEmailModels.Find(id);
            if (contactEmailModels == null)
            {
                return HttpNotFound();
            }
            return View(contactEmailModels);
        }

        // POST: ContactEmailModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Telephone,Message")] ContactEmailModels contactEmailModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactEmailModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactEmailModels);
        }

        // GET: ContactEmailModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactEmailModels contactEmailModels = db.ContactEmailModels.Find(id);
            if (contactEmailModels == null)
            {
                return HttpNotFound();
            }
            return View(contactEmailModels);
        }

        // POST: ContactEmailModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactEmailModels contactEmailModels = db.ContactEmailModels.Find(id);
            db.ContactEmailModels.Remove(contactEmailModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
