using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;

namespace TdtuTube.Controllers
{

    public class SearchController : Controller
    {
        private TdtuTubeEntities db = new TdtuTubeEntities();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult searchVideos(string meta)
        {
            var v = from i in db.Videos
                    where i.title.Contains(meta) && i.privacy == false && i.hide == false && i.status == false
                    orderby i.order ascending
                    select i;
            return PartialView(v.ToList());
        }
    }
}