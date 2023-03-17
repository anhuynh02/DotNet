using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TdtuTube.Controllers
{
    public class FeedController : Controller
    {
        // GET: Feed
        public ActionResult Index(string meta)
        {
            ViewBag.Type = "feed/" + meta;
            return View();
        }
    }
}