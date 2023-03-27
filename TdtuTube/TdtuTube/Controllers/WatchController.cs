
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
        public ActionResult subscribeChannel(int userId, int ownerId)
        {
            var v = from i in db.Subscribes
                    where i.user_id == userId && i.subscribe_user_id == ownerId
                    select i;
            Subscribe sub = v.FirstOrDefault();
            if (sub == null)
            {
                Subscribe subscribe = new Subscribe();
                subscribe.user_id = userId;
                subscribe.subscribe_user_id = ownerId;
                subscribe.subscribe_state = false;
                db.Entry(subscribe).State = System.Data.Entity.EntityState.Added; db.SaveChanges();
                List<Subscribe> list = new List<Subscribe>();
                list.Add(subscribe);
                return PartialView(list);
            }
            return PartialView(v.ToList());
        }
        public ActionResult getSub(int userId, int ownerId)
        {
            var v = from i in db.Subscribes
                    where i.user_id == userId && i.subscribe_user_id == ownerId
                    select i;
            Subscribe subscribe = v.FirstOrDefault();
            subscribe.subscribe_state = (!subscribe.subscribe_state);
            db.Entry(subscribe).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();   
            return RedirectToAction("/a");
        }
    }
}