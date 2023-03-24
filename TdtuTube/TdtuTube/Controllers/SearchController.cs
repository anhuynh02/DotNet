using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;
using TdtuTube.Libs;
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

        public ActionResult searchVideos(string searchQuery)
        {
            if (searchQuery == null)
            {
                return PartialView(new List<Video>());
            }
            var t = from i in db.Videos
                    where i.privacy == false && i.hide == false && i.status == false
                    orderby i.order ascending
                    select i;
            ".".Contains(".");
            var v = t.ToList().Where(i => VideoFormat.normalize(i.title).Contains(searchQuery.ToLower()));
            return PartialView(v);
        }
    }
}