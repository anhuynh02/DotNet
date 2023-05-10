using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            if (Session["UserId"] == null)
            {
                return Redirect("/login");
            }
            var userMeta = Session["UserMeta"];
            ViewBag.Type = "studio";
            ViewBag.Meta = meta;
            var v = from i in db.Users
                    where i.meta == (string)userMeta
                    select i;
            return View(v.FirstOrDefault());
        }

        [HttpGet]
        public ActionResult uploadVideo()
        {
            ViewBag.UserId = (int)Session["UserID"];
            ViewBag.tag_id = new SelectList(db.Tags, "id", "name");
            ViewBag.Type = "studio";
            return PartialView();
        }

        [HttpPost]
        public ActionResult deleteVideo(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Content("Cannot get that id");
            }
            var l = from i in db.Likes
                    where i.video_id == id
                    select i;
            db.Likes.RemoveRange(l);
            var c = from i in db.Comments
                    where i.video_id == id
                    select i;
            db.Comments.RemoveRange(c);
            var pc = from i in db.PlaylistContents
                     where i.video_id == id
                     select i;
            db.PlaylistContents.RemoveRange(pc);
            Video video = db.Videos.Find(id);
            db.Videos.Remove(video);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult getProcess()
        {
            ViewBag.UserId = (int)Session["UserID"];
            ViewBag.tag_id = new SelectList(db.Tags, "id", "name");
            ViewBag.Type = "studio";
            return PartialView();
        }

        public ActionResult editVideo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            long videoId = Convert.ToInt64(id);
            var v = from i in db.Videos
                    where i.id == videoId
                    select i;
            if (v == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = (int)Session["UserID"];
            ViewBag.tag_id = new SelectList(db.Tags, "id", "name");
            ViewBag.Type = "studio";
            return View(v.FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult editVideo([Bind(Include = "id,user_id,tag_id,title,description,like_count,view_count,comment_count,privacy,length,thumbnail,path,feature,meta,hide,order,datebegin,status")] Video video, HttpPostedFileBase img)
        {
            try
            {
                Video temp = db.Videos.Find(video.id);
                string imgPath = "";
                string imgName = "";
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        imgName = img.FileName;
                        imgPath = Path.Combine(HttpContext.Server.MapPath("/Uploads/Thumbnails/"), imgName);
                        img.SaveAs(imgPath);
                        temp.thumbnail = "/Uploads/Thumbnails/" + imgName;
                    }
                    temp.title = video.title;
                    temp.description = video.description;
                    temp.privacy = video.privacy;
                    temp.tag_id = video.tag_id;
                    db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
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
                    if (img != null)
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
                video.status = false;
                int? vidId = db.Videos.Max(v => (int?)v.id) + 1;
                video.meta = vidId.ToString();
                ViewBag.result = "Thêm thành công";
                db.Videos.Add(video);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ActionResult GetInfoVideo(int userId)
        {
            var v = from i in db.Videos
                    where i.User.id == userId
                    orderby i.order ascending
                    select i;
            return PartialView(v.ToList());
        }



        public void getTags(long? selectedId = null)
        {
            ViewBag.Tag = new SelectList(db.Tags.Where(x => x.hide == false).OrderBy(x => x.order), "id", "name", selectedId);
        }

        public ActionResult getVideo()
        {
            return View();
        }

        public ActionResult getInfoPlaylist(int userId)
        {
            var v = from i in db.Playlists
                    where i.User.id == userId
                    select i;
            return PartialView(v.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult editPlaylist([Bind(Include = "id,user_id,name,video_count,privacy,meta,hide,order,dateedit,datebegin")] Playlist p)
        {
            Playlist temp = db.Playlists.Find(p.id);
            try
            {
                if (ModelState.IsValid)
                {
                    temp.name = p.name;
                    temp.privacy = p.privacy;
                    db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Redirect("/studio/index/playlists");
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult deletePlaylist(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Content("Cannot get that id");
            }
            var v = from i in db.PlaylistContents
                    where i.playlist_id == id
                    select i;
            db.PlaylistContents.RemoveRange(v);
            Playlist p = db.Playlists.Find(id);
            db.Playlists.Remove(p);
            db.SaveChanges();
            return Redirect("/studio/index/playlists");
        }
    }
}