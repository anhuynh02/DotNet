using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;

namespace TdtuTube.Controllers
{
    public class VideoController : Controller
    {
        private TdtuTubeEntities db = new TdtuTubeEntities();
        public ActionResult Index(string meta)
        {
            ViewBag.tag = meta;
            return View();
        }
        public ActionResult getVideos(string meta)
        {
            var v = from i in db.Videos
                    where i.Tag.meta == meta && i.privacy == false && i.hide == false && i.status == false
                    orderby i.id ascending
                    select i;
            return PartialView(v.ToList());
        }
    }
}
