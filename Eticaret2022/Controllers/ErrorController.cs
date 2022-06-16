using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret2022.Controllers
{
    public class ErrorController : Controller
    {
        //404
        public ActionResult PageNotFound(string aspxerrorpath)
        {
            if (!string.IsNullOrWhiteSpace(aspxerrorpath))
            {
                return RedirectToAction("PageNotFound");
            }
            return View();
        }
        //403
        public ActionResult NoAccessPermission(string aspxerrorpath)
        {
            if (!string.IsNullOrWhiteSpace(aspxerrorpath))
            {
                return RedirectToAction("NoAccessPermission");
            }
            return View();
        }
        //500
        public ActionResult ServerError(string aspxerrorpath)
        {
            if (!string.IsNullOrWhiteSpace(aspxerrorpath))
            {
                return RedirectToAction("ServerError");
            }
            return View();
        }
    }
}