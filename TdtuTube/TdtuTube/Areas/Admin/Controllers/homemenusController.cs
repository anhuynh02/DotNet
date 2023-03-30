using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;

namespace TdtuTube.Areas.Admin.Controllers
{
    public class homemenusController : Controller
    {
        // GET: Admin/homemenus
        TdtuTubeEntities __db = new TdtuTubeEntities();
        public ActionResult Index()
        {
            return View(__db.HomeMenus.ToList());
        }

        public ActionResult hideOrShow(int? id)
        {
            try
            {
                HomeMenu homeMenu = __db.HomeMenus.Find(id);
                if (ModelState.IsValid)
                {
                    if (homeMenu.hide == false)
                    {
                        homeMenu.hide = true;
                    }
                    else
                    {
                        homeMenu.hide = false;
                    }
                    __db.Entry(homeMenu).State = System.Data.Entity.EntityState.Modified;
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
    }
}