using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;

namespace TdtuTube.Areas.Admin.Controllers
{
    public class videosController : Controller
    {
        // GET: Admin/videos
        TdtuTubeEntities __db = new TdtuTubeEntities();
        public ActionResult Index()
        {

            return View(__db.Videos.ToList());
        }
    }
}