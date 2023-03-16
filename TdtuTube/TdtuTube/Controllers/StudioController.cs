using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using TdtuTube.Models;

namespace TdtuTube.Controllers
{
    public class StudioController : Controller
    {
        // GET: Studio
        private TdtuTubeEntities db = new TdtuTubeEntities();
        public ActionResult Index(string meta)
        {
            ViewBag.Meta = meta;
            var v = from i in db.Users
                    where i.meta == "@1" //Tạm thời set cứng id
                    select i;
            return View(v.FirstOrDefault());
        }

        public ActionResult GetInfoVideo(int userId)
        {
            var v = from i in db.Videos
                    where i.User.id == userId && i.privacy == false && i.hide == false && i.status == false
                    orderby i.order ascending
                    select i;
            return PartialView(v.ToList());
        }
        [Route()]
        public ActionResult uploadVideo()
        {
            return View();
        }
    }


}