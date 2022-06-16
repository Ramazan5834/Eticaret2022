using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Eticaret2022.App_Classes;
using Eticaret2022.Areas.Customer.Models;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Customer/Home
        public ActionResult Index()
        {
            HomePageModel homePageModel = new HomePageModel
            {
                LatestUrunler = ContextDB.Connect.UrunDal.GetLatestUrunler(),
                MostContainAltKategoriler = ContextDB.Connect.AltKategoriDal.GetMoreContainAltKategoriler()
            };
            return View(homePageModel);
        }
        public PartialViewResult CategoryWidget()
        {
            List<UstKategori> activeUstKategoriler = ContextDB.Connect.UstKategoriDal.GetActiveUstKategoriler();
            return PartialView(activeUstKategoriler);
        }
        public PartialViewResult CategoryWidgetMobil()
        {
            List<UstKategori> activeUstKategoriler = ContextDB.Connect.UstKategoriDal.GetActiveUstKategoriler();
            return PartialView(activeUstKategoriler);
        }
        public PartialViewResult SliderWidget()
        {
            List<Slider> sliderList = ContextDB.Connect.SliderDal.GetAll();
            return PartialView(sliderList);
        }

        public PartialViewResult FooterWidget()
        {
            SiteHakkinda ContantInfo = ContextDB.Connect.SiteHakkindaDal.GetAll().FirstOrDefault();
            return PartialView(ContantInfo);
        }

        [HttpPost]
        public JsonResult GetProduct(int Id)
        {
            try
            {
                Urun urun = ContextDB.Connect.UrunDal.GetById(Id);
                return Json(new { durum = true, dataImg = urun.ResimPath, dataName = urun.Adi, dataId = urun.Id, dataPrice = urun.Fiyat });
            }
            catch (Exception e)
            {
                return Json(new { durum = false });

            }
        }
        [HttpPost]
        public JsonResult GetStokCount(int Id)
        {
            try
            {
                Urun urun = ContextDB.Connect.UrunDal.GetById(Id);
                int stokCount = urun.Stok;
                return Json(new { durum = true, urunStokCount = stokCount });
            }
            catch (Exception e)
            {
                return Json(new { durum = false });

            }
        }

        public ActionResult SearchInProducts(string searchString)
        {
            TempData["SearchString"] = searchString;
            List<Urun> searchingProducts = ContextDB.Connect.UrunDal.GetSearchingProducts(searchString);
            return View(searchingProducts);
        }

        public ActionResult GizlilikSozlesmesi()
        {
            return View();
        }
        public ActionResult İptalIadeSozlesmesi()
        {
            return View();
        }
        public ActionResult MesafeliSatisSozlesmesi()
        {
            return View();
        }
    }
}