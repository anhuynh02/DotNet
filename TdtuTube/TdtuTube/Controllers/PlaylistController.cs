using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;

namespace TdtuTube.Controllers
{
    public class PlaylistController : Controller
    {
        private TdtuTubeEntities db = new TdtuTubeEntities();
        // GET: Playlist
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getWatchPlaylists(int videoId)
        {
            int userId = (int)Session["UserID"];
            var playlists = from i in db.Playlists
                            where i.user_id == userId
                            select i;
            var v = playlists
                .Select(p => new PlaylistContainVideoModel
                {
                    Playlist = p,
                    contain_video = p.PlaylistContents.Any(pc => pc.video_id == videoId)
                }).ToList();
            return PartialView(v);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult postPlaylistContent(int playlistId, int videoId)
        {
            PlaylistContent pc = new PlaylistContent();
            pc.playlist_id = playlistId;
            pc.video_id = videoId;
            pc.meta = null;
            pc.hide = false;
            pc.order = 0;
            pc.datebegin = DateTime.Now;
            pc.Video = (from i in db.Videos
                          where i.id == videoId
                          select i).FirstOrDefault();
            pc.Playlist = (from i in db.Playlists
                          where i.id == playlistId
                          select i).FirstOrDefault();
            db.Entry(pc).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Content("Add PlaylistContent Success !!");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult deletePlaylistContent(int playlistId, int videoId)
        {
            var t = from i in db.PlaylistContents
                    where i.playlist_id == playlistId && i.video_id == videoId
                    select i;
            PlaylistContent pc = t.FirstOrDefault();
            if (pc != null)
            {
                db.Entry(pc).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Content("Delete PlaylistContent Success !!");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult postPlaylist(string name, string privacy, int videoId)
        {
            int userId = (int)Session["UserID"];
            bool isPrivate = false;
            if (privacy == "1")
            {
                isPrivate = true;
            }

            Playlist playlist = new Playlist();
            playlist.user_id = userId;
            playlist.name = name;
            playlist.video_count = 0;
            playlist.privacy = isPrivate;
            int? playlistId = db.Playlists.Max(v => (int)v.id) + 1;
            playlist.meta = playlistId.ToString();
            playlist.hide = false;
            playlist.order = 0;
            playlist.dateedit = DateTime.Now;
            playlist.datebegin = DateTime.Now;
            playlist.User = (from i in db.Users
                             where i.id == userId
                             select i).FirstOrDefault();
            db.Entry(playlist).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();

            PlaylistContent pc = new PlaylistContent();
            pc.playlist_id = playlist.id;
            pc.video_id = videoId;
            pc.meta = null;
            pc.hide = false;
            pc.order = 0;
            pc.datebegin = DateTime.Now;
            pc.Video = (from i in db.Videos
                        where i.id == videoId
                        select i).FirstOrDefault();
            pc.Playlist = playlist;
            db.Entry(pc).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Content("Add Playlist Success !!");
        }
    }
}