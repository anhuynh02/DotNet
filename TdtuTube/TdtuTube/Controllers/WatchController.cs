
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;

namespace TdtuTube.Controllers
{
    public class WatchController : Controller
    {
        // GET: Watch
        private TdtuTubeEntities db = new TdtuTubeEntities();
        public ActionResult Index(string meta)
        {
            ViewBag.Meta = meta;
            var v = from i in db.Videos
                    where i.meta == meta
                    select i;
            Video video = v.FirstOrDefault();
            if (video != null)
            {
                video.view_count += 1;
                db.Entry(video).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View(v.FirstOrDefault());
        }
        public ActionResult getVideos(int videoId, int tagId)
        {
            var v = from i in db.Videos
                    where i.id != videoId && i.privacy == false && i.hide == false && i.status == false && i.tag_id == tagId
                    orderby i.order ascending
                    select i;
            return PartialView(v.ToList());
        }
        
       
    }
}