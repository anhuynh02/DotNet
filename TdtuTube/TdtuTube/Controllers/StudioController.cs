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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetInfoVideo()
        {
            var v = from vid in db.Videos
                    select vid;
            return PartialView(v.ToList());
        }
    }


}