using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;

namespace TdtuTube.Controllers
{
    public class HomeController : Controller
    {
        private TdtuTubeEntities db = new TdtuTubeEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getFooter()
        {
            var v = from f in db.HomeMenus
                    where f.type_id != 4 && f.hide == false
                    orderby f.type_id, f.order ascending
                    select f;
            return PartialView(v.ToList());
        }
        public ActionResult getTags()
        {
            ViewBag.Meta = "video";
            var v = from t in db.Tags
                    where t.hide == false
                    orderby t.order descending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getVideos()
        {
            var v = from i in db.Videos
                    orderby i.id ascending
                    select i;
            return PartialView(v.ToList());
        }
    }
}