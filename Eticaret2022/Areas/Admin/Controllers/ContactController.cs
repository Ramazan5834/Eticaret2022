using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret2022.App_Attributes;
using Eticaret2022.App_Classes;
using Eticaret2022.DataEntities.DataModels;
using Microsoft.Ajax.Utilities;

namespace Eticaret2022.Areas.Admin.Controllers
{
    [AccessDeniedAuthorize(Roles = RoleInfo.Admin)]
    public class ContactController : Controller
    {
        // GET: Admin/Contact
        public ActionResult NewContacts()
        {
            TempData["Active"] = ActiveTempDataInfo.NewContacts;
            List<Iletisim> newContacts = ContextDB.Connect.IletisimDal.GetUnreadIletisimler();
            return View(newContacts);
        }

        public ActionResult PastContacts()
        {
            TempData["Active"] = ActiveTempDataInfo.PastContacts;
            List<Iletisim> pastContacts = ContextDB.Connect.IletisimDal.GetReadIletisimler();
            return View(pastContacts);
        }

        public ActionResult ReadContact(int contactId)
        {
            Iletisim iletisim = ContextDB.Connect.IletisimDal.GetById(contactId);
            iletisim.Okundu = true;
            ContextDB.Connect.IletisimDal.AddOrUpdate(iletisim);
            return RedirectToAction("NewContacts");
        }

        [HttpPost]
        public bool DeleteContact(int id)
        {
            try
            {
                Iletisim iletisim = ContextDB.Connect.IletisimDal.GetById(id);
                ContextDB.Connect.IletisimDal.Remove(iletisim);
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