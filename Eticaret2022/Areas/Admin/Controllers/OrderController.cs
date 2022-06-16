using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret2022.App_Attributes;
using Eticaret2022.App_Classes;
using Eticaret2022.BussinessLayer.EmailHelper;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.Areas.Admin.Controllers
{
    [AccessDeniedAuthorize(Roles = RoleInfo.Admin)]
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult NewOrders(bool? emailState)
        {
            if (emailState != null)
            {
                TempData["EmailState"] = emailState;
            }
            TempData["Active"] = ActiveTempDataInfo.NewOrders;
            List<SatisDetay> satisDetaylar = ContextDB.Connect.SatisDetayDal.GetUnreadSatisDetaylar();
            return View(satisDetaylar);
        }

        public ActionResult ConfirmedOrders()
        {
            TempData["Active"] = ActiveTempDataInfo.ConfirmedOrders;
            List<SatisDetay> satisDetaylar = ContextDB.Connect.SatisDetayDal.GetConfirmedSatisDetaylar();
            return View(satisDetaylar);
        }

        public ActionResult RejectedOrders()
        {
            TempData["Active"] = ActiveTempDataInfo.RejectedOrders;
            List<SatisDetay> satisDetaylar = ContextDB.Connect.SatisDetayDal.GetRejectedSatisDetaylar();
            return View(satisDetaylar);
        }

        public ActionResult OrderDetail(int orderId, int pageState, bool? emailState)
        {
            if (emailState != null)
            {
                TempData["EmailState"] = emailState;
            }
            if (pageState == 1)
            {
                TempData["Active"] = ActiveTempDataInfo.NewOrders;
            }
            else if (pageState == 2)
            {
                TempData["Active"] = ActiveTempDataInfo.ConfirmedOrders;
            }
            else if (pageState == 3)
            {
                TempData["Active"] = ActiveTempDataInfo.RejectedOrders;
            }
            TempData["pageState"] = pageState;
            SatisDetay satisDetay = ContextDB.Connect.SatisDetayDal.GetById(orderId);
            return View(satisDetay);
        }

        [HttpPost]
        public ActionResult OrderCargoCode(int orderId, long cargoCode)
        {
            SatisDetay satisDetay = ContextDB.Connect.SatisDetayDal.GetById(orderId);
            satisDetay.KargoNumarasi = cargoCode;
            ContextDB.Connect.SatisDetayDal.AddOrUpdate(satisDetay);
            bool result = EmailHelper.SendEmailCargoCode(satisDetay);
            return RedirectToAction("OrderDetail", new { orderId = orderId, pageState = 2, emailState=result});
        }

        public ActionResult ConfirmOrder(int orderId)
        {
            SatisDetay satisDetay = ContextDB.Connect.SatisDetayDal.GetById(orderId);
            satisDetay.Okundu = true;
            satisDetay.OnayDurum = true;
            ContextDB.Connect.SatisDetayDal.AddOrUpdate(satisDetay);
            //EmailHtml emailHtmlClass = new EmailHtml(satisDetay);
            //string emailHtmlResult = emailHtmlClass.GetEmailHtmlContent();
            bool result = EmailHelper.SendEmailConfirmOrder(satisDetay);
            return RedirectToAction("NewOrders", new { emailState = result });
        }

        [HttpPost]
        public bool RejectOrder(int id)
        {
            try
            {
                SatisDetay satisDetay = ContextDB.Connect.SatisDetayDal.GetById(id);
                satisDetay.Okundu = true;
                satisDetay.OnayDurum = false;
                ContextDB.Connect.SatisDetayDal.AddOrUpdate(satisDetay);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

    }
}