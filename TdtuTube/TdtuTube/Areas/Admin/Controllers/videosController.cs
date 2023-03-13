using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        public ActionResult lockOrUnlock(int? id)
        {
            try
            {
                Video video = __db.Videos.Find(id);
                if (ModelState.IsValid)
                {
                    if(video.status == false)
                    {
                        video.status = true;
                    }
                    else
                    {
                        video.status = false;
                    }
                    __db.Entry(video).State = System.Data.Entity.EntityState.Modified;
                    __db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }catch(DbEntityValidationException e)
            {
                throw e;
            }catch(Exception e)
            {
                throw e;
            }
            return RedirectToAction("Index");
        }

        public Video getById(long id)
        {
            return __db.Videos.Where(v => v.id == id).FirstOrDefault();
        }
    }
}