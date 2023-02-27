using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;

namespace TdtuTube.Areas.Admin.Controllers
{
    public class tagsController : Controller
    {
        // GET: Admin/tags
        TdtuTubeEntities __db = new TdtuTubeEntities();
        public ActionResult Index()
        {
            return View(__db.Tags.ToList());
        }

        public ActionResult CreateTag()
        {
            return View();
        }
    }
}