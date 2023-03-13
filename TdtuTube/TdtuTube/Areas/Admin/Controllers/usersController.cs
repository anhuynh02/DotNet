using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;

namespace TdtuTube.Areas.Admin.Controllers
{
    public class usersController : Controller
    {
        // GET: Admin/users
        TdtuTubeEntities __db = new TdtuTubeEntities();
        public ActionResult Index()
        {
            return View(__db.Users.ToList());
        }

        public ActionResult lockOrUnlock(int? id)
        {
            try
            {
                User user = __db.Users.Find(id);
                if (ModelState.IsValid)
                {
                    if (user.status == false)
                    {
                        user.status = true;
                    }
                    else
                    {
                        user.status = false;
                    }
                    __db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    __db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return RedirectToAction("Index");
        }

        public User getById(long id)
        {
            return __db.Users.Where(v => v.id == id).FirstOrDefault();
        }
    }
}