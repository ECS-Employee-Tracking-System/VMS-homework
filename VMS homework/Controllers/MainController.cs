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
        [Authorize]

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]

        public ActionResult ManageOpp()
        {
            return View();
        }
    }
}