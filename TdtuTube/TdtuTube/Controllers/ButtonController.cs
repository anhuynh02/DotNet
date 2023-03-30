using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult subscribeChannel(int ownerId)
        {
            int userId = (int)Session["UserID"];
            var v = from i in db.Subscribes
                    where i.user_id == userId && i.subscribe_user_id == ownerId
                    select i;
            Subscribe sub = v.FirstOrDefault();
            if (sub == null)
            {
                Subscribe subscribe = new Subscribe();
                subscribe.user_id = (int)Session["UserID"];
                subscribe.subscribe_user_id = ownerId;
                subscribe.subscribe_state = false;
                subscribe.hide = false;
                subscribe.order = 0;
                db.Entry(subscribe).State = System.Data.Entity.EntityState.Added; db.SaveChanges();
                return PartialView(subscribe);
            }
            return PartialView(sub);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult postSub(int ownerId)
        {
            int userId = (int)Session["UserID"];
            var v = from i in db.Subscribes
                    where i.user_id == userId  && i.subscribe_user_id == ownerId
                    select i;
            Subscribe subscribe = v.FirstOrDefault();
            subscribe.subscribe_state = (!subscribe.subscribe_state);
            db.Entry(subscribe).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Content("Subscribe success !!");
        }
    }
}