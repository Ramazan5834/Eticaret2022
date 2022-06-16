using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Eticaret2022.App_Attributes;
using Eticaret2022.App_Classes;
using Eticaret2022.DataEntities.DataModels;
using Microsoft.AspNet.Identity;

namespace Eticaret2022.Areas.Customer.Controllers
{
    [AccessDeniedAuthorize(Roles = RoleInfo.Customer)]
    public class AddressController : Controller
    {
        public ActionResult Addresses()
        {
            List<Adres> customerAdresses =
                ContextDB.Connect.AdresDal.GetCustomerActiveAdresses(User.Identity.GetUserId());
            return View(customerAdresses);
        }

        public ActionResult EditAddress(int addressId)
        {
            Adres adres = ContextDB.Connect.AdresDal.GetById(addressId);
            return View(adres);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditAddress(Adres adres)
        {
            if (ModelState.IsValid)
            {
                ContextDB.Connect.AdresDal.AddOrUpdate(adres);
                return RedirectToAction("Addresses");
            }
            return View(adres);
        }

        public ActionResult CreateAddress()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateAddress(Adres adres)
        {
            if (ModelState.IsValid)
            {
                ContextDB.Connect.AdresDal.AddOrUpdate(adres);
                return RedirectToAction("Addresses");
            }

            return View(adres);
        }


        [HttpPost]
        public bool DeleteAddress(int id)
        {
            try
            {
                Adres adres = ContextDB.Connect.AdresDal.GetById(id);
                adres.AktifDurum = false;
                ContextDB.Connect.AdresDal.AddOrUpdate(adres);
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