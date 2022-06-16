using System;
using System.Linq;
using System.Web.Mvc;
using Eticaret2022.App_Classes;
using Eticaret2022.BussinessLayer.Manager;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.Areas.Customer.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult ContactConnect()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ContactConnect(Iletisim model)
        {
            model.Tarih = DateTime.Now;
            if (ModelState.IsValid)
            {
                ContextDB.Connect.IletisimDal.Add(model);
                ViewBag.Message = Consts.ContactSuccessMessage;
                ViewBag.IsSuccess = "1";
                return View(model);
            }
            ViewBag.IsSuccess = "0";
            ViewBag.Message = Consts.ContactErrorMessage;
            return View(new Iletisim());
        }

        public PartialViewResult ContactInfoWidget()
        {
            SiteHakkinda ContantInfo = ContextDB.Connect.SiteHakkindaDal.GetAll().FirstOrDefault();
            return PartialView(ContantInfo);
        }
    }
}