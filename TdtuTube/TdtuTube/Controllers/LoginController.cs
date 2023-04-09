﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;
using BC = BCrypt.Net.BCrypt;
namespace TdtuTube.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginPage
        private TdtuTubeEntities db = new TdtuTubeEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostLogin(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var v = from i in db.Users
                        where i.email == email
                        select i;
                var user = v.FirstOrDefault();
                if (user != null)
                {
                    if (BC.Verify(password, user.password))
                    {
                        Session["UserID"] = user.id;
                        Session["UserRoleID"] = user.role_id;
                        Session["UserName"] = user.name;
                        Session["UserAvatarPath"] = user.avatar_path;
                        Session["UserMeta"] = user.meta;
                        Session["Error"] = null;
                        if (Session["ReturnURL"] != null)
                        {
                            string URL = (string)Session["ReturnURL"];
                            return Redirect(URL);
                        }

                    }
                }
            }
            
            return Redirect("/login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostSignUp(string email, string password, string name)
        {
            if (ModelState.IsValid)
            {
                var v = from i in db.Users
                        where i.email == email
                        select i;
                var user = v.FirstOrDefault();
                if (user == null)
                {

                    User user1 = new User();
                    user1.email = email;
                    user1.name = name;
                    user1.password = BC.HashPassword(password);
                    user1.avatar_path = "/Uploads/Avatars/default.PNG";
                    user1.meta = "@" + user1.id;
                    user1.role_id = 1;
                    user1.hide = false;
                    user1.order = 0;
                    user1.subscriber_count = 0;
                    user1.datebegin = DateTime.Now;
                    db.Entry(user1).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();

                    var p = from i in db.Users
                            where i.email == email
                            select i;
                    var user2 = p.FirstOrDefault();
                        Session["UserID"] = user2.id;
                        Session["UserRoleID"] = user2.role_id;
                        Session["UserName"] = user2.name;
                        Session["UserAvatarPath"] = user2.avatar_path;
                        Session["UserMeta"] = user2.meta;
                        Session["Error"] = null;
                        if (Session["ReturnURL"] != null)
                        {
                            string URL = (string)Session["ReturnURL"];
                            return Redirect(URL);
                        }

               
                }
            }

            return Redirect("/login");
        }
        public ActionResult logout()
        {   
            //Delete the Session object.
            Session.Clear();

            return Redirect("/");
        }
    }
}