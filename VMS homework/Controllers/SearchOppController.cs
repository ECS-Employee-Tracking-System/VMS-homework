using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMS_homework.Models;

namespace VMS_homework.Controllers
{
    public class SearchOppController : Controller
    {
        OpportunityEntities db = new OpportunityEntities();
        // GET: Search

        //Lets the administrator search for Opportunity by name
        [Authorize]
        public ActionResult Index(String searching)
        {
            var status = from s in db.OppTables
                         select s;
            if (!String.IsNullOrEmpty(searching))
            {
                status = status.Where(s => s.Opportunity.Contains(searching));
            }
            return View(status.ToList());

        }

        //returns all Opportunities in last 60 days
        [Authorize]
        public ActionResult MostRecent()
        {
            var status = from s in db.OppTables
                         select s;
            
            DateTime time = DateTime.Today.AddDays(-60);
            status = status.Where(s => (s.OpportunityStartDate.CompareTo(time)) >= 0);

            return View(status.ToList());
        }

        //Lets the administrator search for Opportunity by Center
        [Authorize]
        public ActionResult ByCenter(String searching)
        {
            var status = from s in db.OppTables
                         select s;
            if (!String.IsNullOrEmpty(searching))
            {
                status = status.Where(s => s.OpportunityCenter.Contains(searching));
            }
            return View(status.ToList());
        }
    }
}