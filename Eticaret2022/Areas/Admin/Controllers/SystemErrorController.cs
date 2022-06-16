using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret2022.App_Attributes;
using Eticaret2022.App_Classes;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.Areas.Admin.Controllers
{
    [AccessDeniedAuthorize(Roles = RoleInfo.Admin)]
    public class SystemErrorController : Controller
    {
        public ActionResult Index()
        {
            TempData["Active"] = ActiveTempDataInfo.SystemError;
            List<SistemHata> systemErrors = ContextDB.Connect.SistemHataDal.GetSistemHatalar();
            return View(systemErrors);
        }

        public ActionResult SystemErrorDetail(int systemErrorId)
        {
            TempData["Active"] = ActiveTempDataInfo.SystemError;
            SistemHata systemError = ContextDB.Connect.SistemHataDal.GetById(systemErrorId);
            return View(systemError);
        }
    }
}