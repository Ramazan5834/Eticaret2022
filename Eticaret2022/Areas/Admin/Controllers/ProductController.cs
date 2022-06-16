using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret2022.App_Attributes;
using Eticaret2022.App_Classes;
using Eticaret2022.BussinessLayer.Manager;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.Areas.Admin.Controllers
{
    [AccessDeniedAuthorize(Roles = RoleInfo.Admin)]
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            TempData["Active"] = ActiveTempDataInfo.Products;
            List<Urun> urunler = ContextDB.Connect.UrunDal.GetActiveUrunler();
            return View(urunler);
        }

        public ActionResult CreateProduct()
        {
            TempData["Active"] = ActiveTempDataInfo.Products;
            List<AltKategori> altKategoriler = ContextDB.Connect.AltKategoriDal.GetActiveAltKategoriler();
            ViewBag.AltKategoriler = altKategoriler;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateProduct(Urun urun, string stringFiyat, HttpPostedFileBase imageUpload)
        {
            if (imageUpload != null && stringFiyat != null && ProductProcesses.CheckPrice(stringFiyat))
            {
                if (stringFiyat.Contains(","))
                {
                    urun.Fiyat = (double)Decimal.Parse(stringFiyat, NumberStyles.Number);
                }
                else
                {
                    urun.Fiyat = Int32.Parse(stringFiyat);
                }
                Image img = Image.FromStream(imageUpload.InputStream);
                Bitmap bitImage = new Bitmap(img, 768, 465);
                string imageWay = "/Content/App_Images/UrunImages/" + Guid.NewGuid() + Path.GetExtension(imageUpload.FileName);
                urun.ResimPath = imageWay;
                urun.EklenmeTarihi = DateTime.Now;
                bitImage.Save(Server.MapPath(imageWay));
                if (ModelState.IsValid)
                {
                    ContextDB.Connect.UrunDal.AddOrUpdate(urun);
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("createProd", "Eksik alan olmadığına emin olun.Fiyat boşluk içeremez veya ondalıklı fiyat girecekseniz (.) değil (,) kullanmalısınız");
            List<AltKategori> altKategoriler = ContextDB.Connect.AltKategoriDal.GetActiveAltKategoriler();
            ViewBag.AltKategoriler = altKategoriler;
            return View(urun);
        }

        public ActionResult UpdateProduct(int productId)
        {
            TempData["Active"] = ActiveTempDataInfo.Products;
            List<AltKategori> altKategoriler = ContextDB.Connect.AltKategoriDal.GetActiveAltKategoriler();
            ViewBag.AltKategoriler = altKategoriler;
            Urun urun = ContextDB.Connect.UrunDal.GetById(productId);
            return View(urun);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UpdateProduct(Urun urun, string stringFiyat, HttpPostedFileBase imageUpload)
        {
            if (stringFiyat != null && ProductProcesses.CheckPrice(stringFiyat))
            {
                if (stringFiyat.Contains(","))
                {
                    urun.Fiyat = (double)Decimal.Parse(stringFiyat, NumberStyles.Number);
                }
                else
                {
                    urun.Fiyat = Int32.Parse(stringFiyat);
                }
                if (imageUpload != null)
                {
                    string deletePath = Request.MapPath(urun.ResimPath);
                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                    Image img = Image.FromStream(imageUpload.InputStream);
                    Bitmap bitImage = new Bitmap(img, 768, 465);
                    string imageWay = "/Content/App_Images/UrunImages/" + Guid.NewGuid() + Path.GetExtension(imageUpload.FileName);
                    urun.ResimPath = imageWay;
                    bitImage.Save(Server.MapPath(imageWay));
                    if (ModelState.IsValid)
                    {
                        ContextDB.Connect.UrunDal.AddOrUpdate(urun);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        ContextDB.Connect.UrunDal.AddOrUpdate(urun);
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError("updateProd", "Eksik alan olmadığına emin olun.Fiyat boşluk içeremez veya ondalıklı fiyat girecekseniz (.) değil (,) kullanmalısınız");
            List<AltKategori> altKategoriler = ContextDB.Connect.AltKategoriDal.GetActiveAltKategoriler();
            ViewBag.AltKategoriler = altKategoriler;
            return View(urun);
        }

        [HttpPost]
        public bool DeleteProduct(int id)
        {
            try
            {
                Urun urun = ContextDB.Connect.UrunDal.GetById(id);
                urun.Stok = 0;
                urun.AktifDurum = false;
                ContextDB.Connect.UrunDal.AddOrUpdate(urun);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //public bool CheckPrice(string stringFiyat)
        //{
        //    for (int i = 0; i < stringFiyat.Length; i++)
        //    {
        //        string characterFiyat = stringFiyat[i].ToString();
        //        if (i == 0 || i == stringFiyat.Length - 1)
        //        {
        //            if (
        //                characterFiyat == "1" ||
        //                characterFiyat == "2" ||
        //                characterFiyat == "3" ||
        //                characterFiyat == "4" ||
        //                characterFiyat == "5" ||
        //                characterFiyat == "6" ||
        //                characterFiyat == "7" ||
        //                characterFiyat == "8" ||
        //                characterFiyat == "9"
        //            ) { }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            if (
        //                characterFiyat == "0" ||
        //                characterFiyat == "1" ||
        //                characterFiyat == "2" ||
        //                characterFiyat == "3" ||
        //                characterFiyat == "4" ||
        //                characterFiyat == "5" ||
        //                characterFiyat == "6" ||
        //                characterFiyat == "7" ||
        //                characterFiyat == "8" ||
        //                characterFiyat == "9" ||
        //                characterFiyat == ","
        //            ) { }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}
    }
}


/*
 *     [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateProduct(Urun urun, string stringFiyat, HttpPostedFileBase imageUpload)
        {
            if (imageUpload != null && stringFiyat != null && !stringFiyat.Contains(".") && stringFiyat.Contains(","))
            {
                urun.Fiyat = (double)Decimal.Parse(stringFiyat, NumberStyles.Number);
                Image img = Image.FromStream(imageUpload.InputStream);
                Bitmap bitImage = new Bitmap(img, 768, 465);
                string imageWay = "/Content/App_Images/UrunImages/" + Guid.NewGuid() + Path.GetExtension(imageUpload.FileName);
                urun.ResimPath = imageWay;
                urun.EklenmeTarihi = DateTime.Now;
                bitImage.Save(Server.MapPath(imageWay));
                if (ModelState.IsValid)
                {
                    ContextDB.Connect.UrunDal.AddOrUpdate(urun);
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("createProd", "Eksik alan olmadığına emin olun.Fiyat zorunlu olarak (,) içermelidir (.) değil.Tam fiyat girmek için örneğin 20,00tl gibi");
            List<AltKategori> altKategoriler = ContextDB.Connect.AltKategoriDal.GetActiveAltKategoriler();
            ViewBag.AltKategoriler = altKategoriler;
            return View(urun);
        }
 */