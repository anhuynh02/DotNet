using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
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
            ViewBag.Type = "studio";
            ViewBag.Meta = meta;
            var v = from i in db.Users
                    where i.meta == "@1" //Tạm thời set cứng id
                    select i;
            return View(v.FirstOrDefault());
        }
        public ActionResult uploadVideo()
        {
            ViewBag.Type = "studio";
            ViewBag.tag_id = new SelectList(db.Tags, "id", "name");
            ViewBag.user_id = new SelectList(db.Users, "id", "name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public ActionResult uploadVideo([Bind(Include = "id,user_id,tag_id,title,description,like_count,view_count,comment_count,privacy,length,thumbnail,path,feature,meta,hide,order,datebegin,status")] Video video, HttpPostedFileBase img, HttpPostedFileBase vid)
        {
            try
            {
                string imgPath = "";
                string imgName = "";
                string vidPath = "";
                string vidName = "";
                if (ModelState.IsValid)
                {
                    if(vid != null)
                    {
                        if(img != null)
                        {
                            imgName = img.FileName;
                            imgPath = Path.Combine(HttpContext.Server.MapPath("/Uploads/Thumbnails/"), imgName);
                            img.SaveAs(imgPath);
                            video.thumbnail = "/Uploads/Thumbnails/" + imgName;
                        }
                        else
                        {
                            video.thumbnail = "/Uploads/Thumbnails/default.png";
                        }
                        vidName = vid.FileName;
                        vidPath = Path.Combine(HttpContext.Server.MapPath("/Uploads/Videos/"), vidName);
                        vid.SaveAs(vidPath);
                        video.path = "/Uploads/Videos/" + vidName;
                    }
                    video.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    video.length = "0:00";
                    ViewBag.result = "Thêm thành công";
                    db.Videos.Add(video);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(video);
        }

        public ActionResult GetInfoVideo(int userId)
        {
            var v = from i in db.Videos
                    where i.User.id == userId && i.privacy == false && i.hide == false && i.status == false
                    orderby i.order ascending
                    select i;
            return PartialView(v.ToList());
        }

        

        public void getTags(long? selectedId = null)
        {
            ViewBag.Tag = new SelectList(db.Tags.Where(x => x.hide == false).OrderBy(x => x.order), "id", "name", selectedId);
        }
    }
}