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
    public class OppTablesController : Controller
    {
        private OpportunityEntities db = new OpportunityEntities();

        // GET: OppTables
        public ActionResult Index()
        {
            return View(db.OppTables.ToList());
        }

        // GET: OppTables/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OppTable oppTable = db.OppTables.Find(id);
            if (oppTable == null)
            {
                return HttpNotFound();
            }
            return View(oppTable);
        }

        // GET: OppTables/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OppTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Opportunity,OpportunityStartDate,OpportunityStopDate,OpportunityLastComp,OpportunityCenter")] OppTable oppTable)
        {
            if (ModelState.IsValid)
            {
                db.OppTables.Add(oppTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oppTable);
        }

        // GET: OppTables/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OppTable oppTable = db.OppTables.Find(id);
            if (oppTable == null)
            {
                return HttpNotFound();
            }
            return View(oppTable);
        }

        // POST: OppTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Opportunity,OpportunityStartDate,OpportunityStopDate,OpportunityLastComp,OpportunityCenter")] OppTable oppTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oppTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oppTable);
        }

        // GET: OppTables/Delete/
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OppTable oppTable = db.OppTables.Find(id);
            if (oppTable == null)
            {
                return HttpNotFound();
            }
            return View(oppTable);
        }

        // POST: OppTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            OppTable oppTable = db.OppTables.Find(id);
            db.OppTables.Remove(oppTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult ManageOpp()
        {
            return View(db.OppTables.ToList());
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
