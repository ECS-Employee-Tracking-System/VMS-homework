using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VMS_homework.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageVol()
        {
            return View();
        }
        public ActionResult ManageOpp()
        {
            return View();
        }
    }
}