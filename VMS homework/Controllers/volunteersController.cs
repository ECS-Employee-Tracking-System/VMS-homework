using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VMS_homework.Models;

namespace VMS_homework.Controllers
{
    public class volunteersController : Controller
    {
        private VMSEntities db = new VMSEntities();

        // GET: volunteers
        [Authorize]
        public ActionResult Index()
        {
            return View(db.volunteers.ToList());
        }

        // GET: volunteers/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            volunteer volunteer = db.volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // GET: volunteers/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: volunteers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,UserName,Password,Centers,Skills,Availability,StreetAddress,CityAddress,StateAddress,ZipAddress,HomePhone,WorkPhone,CellPhone,Email,Education,Liscenses,ECFirstName,ECLastName,ECHomePhone,ECCellPhone,ECEmail,ECStreetAddress,ECCityAddress,ECStateAddress,ECZipcode,DLFile,SSFile,ApprovalStatus")] volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.volunteers.Add(volunteer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volunteer);
        }

        // GET: volunteers/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            volunteer volunteer = db.volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: volunteers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "FirstName,LastName,UserName,Password,Centers,Skills,Availability,StreetAddress,CityAddress,StateAddress,ZipAddress,HomePhone,WorkPhone,CellPhone,Email,Education,Liscenses,ECFirstName,ECLastName,ECHomePhone,ECCellPhone,ECEmail,ECStreetAddress,ECCityAddress,ECStateAddress,ECZipcode,DLFile,SSFile,ApprovalStatus")] volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Search");
            }
            return View(volunteer);
        }

        // GET: volunteers/Delete/5
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            volunteer volunteer = db.volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: volunteers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(string id)
        {
            volunteer volunteer = db.volunteers.Find(id);
            db.volunteers.Remove(volunteer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult ManageVol()
        {
            return View(db.volunteers.ToList());
        }

        [Authorize]
        public ActionResult ChangeFilter()
        {
            return View();
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
