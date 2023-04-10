
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;

namespace TdtuTube.Controllers
{
    public class WatchController : Controller
    {
        // GET: Watch
        private TdtuTubeEntities db = new TdtuTubeEntities();
        public ActionResult Index(string meta, string list, string listmeta)
        {
            if (list == "playlist")
            {
                var exist = from i in db.Playlists
                            where i.meta == listmeta
                            select i;
                if (exist.FirstOrDefault() != null)
                {
                    ViewBag.PlaylistMeta = listmeta;
                }
                else
                {
                    return Redirect("/watch/" + meta);
                }
            }
            else
            {
                return Redirect("/watch/" + meta);
            }
            var v = from i in db.Videos
                    where i.meta == meta
                    select i;
            Video video = v.FirstOrDefault();
            if (video != null)
            {
                video.view_count += 1;
                db.Entry(video).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View(v.FirstOrDefault());

        }
        public ActionResult getVideos(int videoId, int tagId)
        {
            var v = from i in db.Videos
                    where i.id != videoId && i.privacy == false && i.hide == false && i.status == false && i.tag_id == tagId
                    orderby i.order ascending
                    select i;
            return PartialView(v.ToList());
        }
        public ActionResult getPlaylist(int playlistId)
        {
            var v = from i in db.PlaylistContents
                    where i.playlist_id == playlistId && i.hide == false
                    select i;
            return PartialView(v.ToList());
        }

    }
}