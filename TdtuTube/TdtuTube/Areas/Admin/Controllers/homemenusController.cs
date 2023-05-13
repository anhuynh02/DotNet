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
            if (Session["UserRoleID"] == null || (int)Session["UserRoleID"] != 1)
                return Redirect("/login");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,name,link,icon,meta,order,hide,type_id,datebegin")] HomeMenu menu)
        {
            try
            {
                var t = from i in __db.HomeMenus
                        where i.name.Equals(menu.name)
                        select i;
                if (t.FirstOrDefault() == null)
                {
                    HomeMenu temp = __db.HomeMenus.Find(menu.id);
                    temp.name = menu.name;
                    __db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                    __db.SaveChanges();
                    TempData["menuEditSuccess"] = "Chỉnh sửa menu thành công";
                }
                else
                {
                    TempData["menuEditError"] = "Chỉnh sửa menu thất bại";
                }
                
                return RedirectToAction("Index", "homemenus");
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
    }
}