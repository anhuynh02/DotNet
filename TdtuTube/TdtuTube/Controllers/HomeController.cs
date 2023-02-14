using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;
namespace TdtuTube.Controllers
{
    public class HomeController : Controller
    {
        TdtuTubeEntities db = new TdtuTubeEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult getMenu() {
            var v = from t in db.Tags
                    orderby t.id ascending
                    select t;
            return PartialView(v.ToList());
        }
    }
}