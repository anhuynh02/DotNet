using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TdtuTube.Controllers
{
    public class LockedController : Controller
    {
        // GET: Locked
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult notFound()
        {
            return View();
        }
    }

}