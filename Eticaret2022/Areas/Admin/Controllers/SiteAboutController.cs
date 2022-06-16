using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret2022.App_Attributes;
using Eticaret2022.App_Classes;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.Areas.Admin.Controllers
{
    [AccessDeniedAuthorize(Roles = RoleInfo.Admin)]
    public class SiteAboutController : Controller
    {
        // GET: Admin/SiteAbout
        public ActionResult Index()
        {
            TempData["Active"] = ActiveTempDataInfo.SiteAbout;
            SiteHakkinda siteHakkinda = ContextDB.Connect.SiteHakkindaDal.GetAll().FirstOrDefault();
            return View(siteHakkinda);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UpdateSiteAbout(SiteHakkinda siteHakkinda, HttpPostedFileBase hakkimizdaImageUpload, HttpPostedFileBase logoImageUpload, HttpPostedFileBase bannerImageUpload)
        {
            if (hakkimizdaImageUpload != null)
            {
                string deletePath = Request.MapPath(siteHakkinda.HakkimizdaResimPath);
                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }
                Image img = Image.FromStream(hakkimizdaImageUpload.InputStream);
                Bitmap bitImage = new Bitmap(img, 768, 465);
                string imageWay = "/Content/App_Images/HakkimizdaImages/" + Guid.NewGuid() + Path.GetExtension(hakkimizdaImageUpload.FileName);
                siteHakkinda.HakkimizdaResimPath = imageWay;
                bitImage.Save(Server.MapPath(imageWay));
            }

            if (logoImageUpload != null)
            {
                string deletePath = Request.MapPath(siteHakkinda.LogoPath);
                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }
                Image img = Image.FromStream(logoImageUpload.InputStream);
                Bitmap bitImage = new Bitmap(img,800,800);
                string imageWay = "/Content/App_Images/Logo/" + Guid.NewGuid() + Path.GetExtension(logoImageUpload.FileName);
                siteHakkinda.LogoPath = imageWay;
                bitImage.Save(Server.MapPath(imageWay));
            }

            if (bannerImageUpload != null)
            {
                string deletePath = Request.MapPath(siteHakkinda.BannerResimPath);
                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }
                Image img = Image.FromStream(bannerImageUpload.InputStream);
                Bitmap bitImage = new Bitmap(img,800,250);
                string imageWay = "/Content/App_Images/Logo/" + Guid.NewGuid() + Path.GetExtension(bannerImageUpload.FileName);
                siteHakkinda.BannerResimPath = imageWay;
                bitImage.Save(Server.MapPath(imageWay));
            }

            ContextDB.Connect.SiteHakkindaDal.AddOrUpdate(siteHakkinda);
            return RedirectToAction("Index");
        }
    }
}