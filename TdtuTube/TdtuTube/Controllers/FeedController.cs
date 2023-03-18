using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;

namespace TdtuTube.Controllers
{
    public class FeedController : Controller
    {
        private TdtuTubeEntities db = new TdtuTubeEntities();
        public ActionResult Index(string meta)
        {
            ViewBag.Type = "feed/" + meta;
            ViewBag.Meta = meta;
            return View();
        }
        public ActionResult getSubscribeChannelVideos(int id)
        {
            var t = from i in db.Subscribes
                    where i.user_id == id && i.subscribe_state == true && i.hide == false
                          && i.User.status == false && i.User.hide == false
                    orderby i.order ascending
                    select i.User.Videos;
            var v = from videos in t
                        from i in videos
                        where i.privacy == false && i.hide == false && i.status == false
                        orderby i.order ascending, i.datebegin descending
                    select i;
            return PartialView(v.ToList());
        }
        public ActionResult getLikeVideos(int id)
        {
            var v = from i in db.Likes
                    where i.user_id == id && i.like_state == true && i.hide == false
                          && i.Video.privacy == false && i.Video.hide == false && i.Video.status == false
                    orderby i.order ascending, i.datebegin descending
                    select i.Video;
            return PartialView(v.ToList());
        }
    }
}