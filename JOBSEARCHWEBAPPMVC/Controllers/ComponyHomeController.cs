using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JOBSEARCHWEBAPPMVC.Controllers
{
    public class ComponyHomeController : Controller
    {
        // GET: ComponyHome
        public ActionResult ComHome_PageLoad()
        {
            return View();
        }

    }
}