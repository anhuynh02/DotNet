using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using TdtuTube.Models;

namespace TdtuTube.Areas.Admin.Controllers
{
    public class tagsController : Controller
    {
        // GET: Admin/tags
        TdtuTubeEntities __db = new TdtuTubeEntities();
        public ActionResult Index()
        {
            return View(__db.Tags.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateTag([Bind(Include ="id,name,meta,order,hide")] Tag tag)
        {
            try
            {
                __db.Tags.Add(tag);
                __db.SaveChanges();
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

        public JsonResult Edit(int? id)
        {
            if(id == null)
            {
                return Json(new { Message = "Không tìm thấy", JsonRequestBehavior.AllowGet });
            }
            var v = from i in __db.Tags
                    where i.id == id //Tạm thời set cứng id
                    select i;
            if (v == null)
            {
                return Json(new { Message = "Không tìm thấy", JsonRequestBehavior.AllowGet });
            }
            return Json(v.FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,name,meta,order,hide")] Tag tag)
        {
            try
            {
                Tag temp = __db.Tags.Find(tag.id);
                temp.name = tag.name;
                temp.meta = tag.meta;
                temp.hide = tag.hide;
                __db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                __db.SaveChanges();
                return RedirectToAction("Index", "tags");
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