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
        public ActionResult getSidebar()
        {
            var v = from s in db.HomeMenus
                    where s.type_id == 1 && s.hide == false
                    orderby s.order ascending
                    select s;
            return PartialView(v.ToList());
        }
        public ActionResult getFooter(int id)
        {
            var v = from f in db.HomeMenus
                    where f.type_id == id && f.hide == false
                    orderby f.order ascending
                    select f;
            return PartialView(v.ToList());
        }
        public ActionResult getCopyrightLogo()
        {
            var v = from c in db.HomeMenus
                    where c.type_id == 4 && c.hide == false
                    select c;
            return PartialView(v.FirstOrDefault());
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
                    where i.privacy == false && i.hide == false && i.status == false
                    orderby i.order ascending
                    select i;
            return PartialView(v.ToList());
        }
    }
}