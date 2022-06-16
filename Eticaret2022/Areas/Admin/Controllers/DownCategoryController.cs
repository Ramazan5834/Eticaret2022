using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Eticaret2022.App_Attributes;
using Eticaret2022.App_Classes;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.Areas.Admin.Controllers
{
    [AccessDeniedAuthorize(Roles = RoleInfo.Admin)]
    public class DownCategoryController : Controller
    {
        // GET: Admin/DownCategory
        public ActionResult Index()
        {
            TempData["Active"] = ActiveTempDataInfo.DownCategories;
            List<AltKategori> downCategories = ContextDB.Connect.AltKategoriDal.GetActiveAltKategoriler();
            return View(downCategories);
        }

        public ActionResult CreateDownCategory()
        {
            TempData["Active"] = ActiveTempDataInfo.DownCategories;
            List<UstKategori> ustKategoriler = ContextDB.Connect.UstKategoriDal.GetActiveUstKategoriler();
            ViewBag.UstKategoriler = ustKategoriler;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateDownCategory(AltKategori altKategori, HttpPostedFileBase imageUpload)
        {
            if (imageUpload != null)
            {
                Image img = Image.FromStream(imageUpload.InputStream);
                Bitmap bitImage = new Bitmap(img,1000,500);
                string imageWay = "/Content/App_Images/AltKategoriImages/" + Guid.NewGuid() + Path.GetExtension(imageUpload.FileName);
                altKategori.ResimPath = imageWay;
                bitImage.Save(Server.MapPath(imageWay));
                if (ModelState.IsValid)
                {
                    ContextDB.Connect.AltKategoriDal.AddOrUpdate(altKategori);
                    return RedirectToAction("Index");
                }
            }
            List<UstKategori> ustKategoriler = ContextDB.Connect.UstKategoriDal.GetActiveUstKategoriler();
            ViewBag.UstKategoriler = ustKategoriler;
            return View(altKategori);
        }

        public ActionResult UpdateDownCategory(int downCategoryId)
        {
            TempData["Active"] = ActiveTempDataInfo.DownCategories;
            List<UstKategori> ustKategoriler = ContextDB.Connect.UstKategoriDal.GetActiveUstKategoriler();
            ViewBag.UstKategoriler = ustKategoriler;
            AltKategori altKategori = ContextDB.Connect.AltKategoriDal.GetById(downCategoryId);
            return View(altKategori);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UpdateDownCategory(AltKategori altKategori, HttpPostedFileBase imageUpload)
        {
            if (imageUpload != null)
            {
                string deletePath = Request.MapPath(altKategori.ResimPath);
                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }
                Image img = Image.FromStream(imageUpload.InputStream);
                Bitmap bitImage = new Bitmap(img,1000,500);
                string imageWay = "/Content/App_Images/AltKategoriImages/" + Guid.NewGuid() + Path.GetExtension(imageUpload.FileName);
                altKategori.ResimPath = imageWay;
                bitImage.Save(Server.MapPath(imageWay));
                if (ModelState.IsValid)
                {
                    ContextDB.Connect.AltKategoriDal.AddOrUpdate(altKategori);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    ContextDB.Connect.AltKategoriDal.AddOrUpdate(altKategori);
                    return RedirectToAction("Index");
                }
            }
            List<UstKategori> ustKategoriler = ContextDB.Connect.UstKategoriDal.GetActiveUstKategoriler();
            ViewBag.UstKategoriler = ustKategoriler;
            return View(altKategori);
        }

        [HttpPost]
        public bool DeleteDownCategory(int id)
        {
            try
            {
                AltKategori altKategori = ContextDB.Connect.AltKategoriDal.GetById(id);
                altKategori.AktifDurum = false;
                ContextDB.Connect.AltKategoriDal.AddOrUpdate(altKategori);
                foreach (var urun in altKategori.Urun)
                {
                    urun.AktifDurum = false;
                    ContextDB.Connect.UrunDal.AddOrUpdate(urun);
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