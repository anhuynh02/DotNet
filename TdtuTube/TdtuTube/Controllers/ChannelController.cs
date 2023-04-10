using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;

namespace TdtuTube.Controllers
{
    public class ChannelController : Controller
    {
        // GET: Channel
        private TdtuTubeEntities db = new TdtuTubeEntities();
        public ActionResult Index(string user, string meta)
        {
            ViewBag.Controller = "channel";
            ViewBag.Meta = meta;
            var v = from i in db.Users
                    where i.meta == user
                    select i;
            return View(v.FirstOrDefault());
        }
        public ActionResult getUserVideos(int userId)
        {
            var v = from i in db.Videos
                    where i.User.id == userId && i.privacy == false && i.hide == false && i.status == false
                    orderby i.order ascending
                    select i;
            return PartialView(v.ToList());
        }
        public ActionResult getPLaylists(int userId)
        {
            var v = from i in db.Playlists
                    where i.user_id == userId
                    select i;
            return PartialView(v.ToList());
        }
    }
}