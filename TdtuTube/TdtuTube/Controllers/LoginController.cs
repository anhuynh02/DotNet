using System;
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
                    if (BC.Verify(password, user.password)) {
                        Session["UserID"] = user.id;
                        Session["UserRoleID"] = user.role_id;
                        Session["UserName"] = user.name;
                        Session["UserAvatarPath"] = user.avatar_path;
                        Session["UserMeta"] = user.meta;
                        return Redirect("/");
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