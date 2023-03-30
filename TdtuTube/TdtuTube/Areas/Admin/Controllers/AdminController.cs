﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TdtuTube.Models;

namespace TdtuTube.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        TdtuTubeEntities __db = new TdtuTubeEntities();
        public ActionResult Index()
        {
            return Redirect("/Admin/users");
        }

        public ActionResult getFunction()
        {
            var v = from t in __db.AdminMenus
                    select t;
            return PartialView(v.ToList());
        }
    }
}