using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Text;
using TdtuTube.Models;

namespace TdtuTube.Controllers
{
    public class ButtonController : Controller
    {
        private TdtuTubeEntities db = new TdtuTubeEntities();
        // GET: Button
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getSubscribe(int ownerId)
        {
            Subscribe subscribe;
            int userId = (int) Session["UserID"];
            var v = from i in db.Subscribes
                    where i.user_id == userId && i.subscribe_user_id == ownerId
                    select i;
            subscribe = v.FirstOrDefault();
            if (subscribe == null)
            {
                subscribe = new Subscribe();
                subscribe.user_id = (int) Session["UserID"];
                subscribe.subscribe_user_id = ownerId;
                subscribe.subscribe_state = false;
                subscribe.hide = false;
                subscribe.order = 0;
                subscribe.datebegin = DateTime.Now;
                db.Entry(subscribe).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
            return PartialView(subscribe);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult postSubscribe(int ownerId)
        {
            int userId = (int) Session["UserID"];
            var v = from i in db.Subscribes
                    where i.user_id == userId  && i.subscribe_user_id == ownerId
                    select i;
            Subscribe subscribe = v.FirstOrDefault();
            subscribe.subscribe_state = !subscribe.subscribe_state;
            db.Entry(subscribe).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            Response.StatusCode = (int) HttpStatusCode.OK;
            return Content("Subscribe success !!");
        }
        public ActionResult getLike(int videoId)
        {
            Like like;
            int userId = (int)Session["UserID"];
            var v = from i in db.Likes
                    where i.user_id == userId && i.video_id == videoId
                    select i;
            like = v.FirstOrDefault();
            if (like == null)
            {
                like = new Like();
                like.user_id = (int)Session["UserID"];
                like.video_id = videoId;
                like.like_state = false;
                like.hide = false;
                like.order = 0;
                like.datebegin = DateTime.Now;
                like.Video = (from i in db.Videos
                              where i.id == videoId
                              select i).FirstOrDefault();
                db.Entry(like).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
            return PartialView(like);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult postLike(int videoId)
        {
            int userId = (int)Session["UserID"];
            var v = from i in db.Likes
                    where i.user_id == userId && i.video_id == videoId
                    select i;
            Like like = v.FirstOrDefault();
            like.like_state = !like.like_state;
            db.Entry(like).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Content("Like success !!");
        }
    }
}