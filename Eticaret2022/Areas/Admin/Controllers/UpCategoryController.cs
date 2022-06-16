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
    public class UpCategoryController : Controller
    {
        // GET: Admin/UpCategories
        public ActionResult Index()
        {
            TempData["Active"] = ActiveTempDataInfo.UpCategories;
            List<UstKategori> upCategories = ContextDB.Connect.UstKategoriDal.GetActiveUstKategoriler();
            return View(upCategories);
        }

        public ActionResult CreateUpCategory()
        {
            TempData["Active"] = ActiveTempDataInfo.UpCategories;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateUpCategory(UstKategori ustKategori)
        {
            if (ModelState.IsValid)
            {
                ContextDB.Connect.UstKategoriDal.AddOrUpdate(ustKategori);
                return RedirectToAction("Index");
            }
            return View(ustKategori);
        }

        public ActionResult UpdateUpCategory(int upCategoryId)
        {
            TempData["Active"] = ActiveTempDataInfo.UpCategories;
            UstKategori ustKategori = ContextDB.Connect.UstKategoriDal.GetById(upCategoryId);
            return View(ustKategori);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UpdateUpCategory(UstKategori ustKategori)
        {
            if (ModelState.IsValid)
            {
                ContextDB.Connect.UstKategoriDal.AddOrUpdate(ustKategori);
                return RedirectToAction("Index");
            }
            return View(ustKategori);
        }


        [HttpPost]
        public bool DeleteUpCategory(int id)
        {
            try
            {
                UstKategori ustKategori = ContextDB.Connect.UstKategoriDal.GetById(id);
                ustKategori.AktifDurum = false;
                ContextDB.Connect.UstKategoriDal.AddOrUpdate(ustKategori);
                foreach (var altKategori in ustKategori.AltKategori)
                {
                    altKategori.AktifDurum = false;
                    ContextDB.Connect.AltKategoriDal.AddOrUpdate(altKategori);
                    foreach (var urun in altKategori.Urun)
                    {
                        urun.AktifDurum = false;
                        ContextDB.Connect.UrunDal.AddOrUpdate(urun);
                    }
                }
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