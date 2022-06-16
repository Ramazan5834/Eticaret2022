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
    public class SliderController : Controller
    {
        // GET: Admin/Slider
        public ActionResult Index()
        {
            TempData["Active"] = ActiveTempDataInfo.Slider;
            List<Slider> sliders = ContextDB.Connect.SliderDal.GetAll();
            return View(sliders);
        }

        public ActionResult CreateSlider()
        {
            TempData["Active"] = ActiveTempDataInfo.Slider;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateSlider(Slider slider,HttpPostedFileBase imageUpload)
        {
            if (imageUpload != null)
            {
                Image img = Image.FromStream(imageUpload.InputStream);
                Bitmap bitImage = new Bitmap(img,1461,844);
                string imageWay = "/Content/App_Images/SliderImages/" + Guid.NewGuid() + Path.GetExtension(imageUpload.FileName);
                slider.ResimPath = imageWay;
                bitImage.Save(Server.MapPath(imageWay));
                if (ModelState.IsValid)
                {
                    ContextDB.Connect.SliderDal.AddOrUpdate(slider);
                    return RedirectToAction("Index");
                }
            }
            return View(slider);
        }


        public ActionResult UpdateSlider(int sliderId)
        {
            TempData["Active"] = ActiveTempDataInfo.Slider;
            Slider slider = ContextDB.Connect.SliderDal.GetById(sliderId);
            return View(slider);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UpdateSlider(Slider slider,HttpPostedFileBase imageUpload)
        {
            if (imageUpload != null)
            {
                string deletePath = Request.MapPath(slider.ResimPath);
                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }
                Image img = Image.FromStream(imageUpload.InputStream);
                Bitmap bitImage = new Bitmap(img, 1461, 844);
                string imageWay = "/Content/App_Images/SliderImages/" + Guid.NewGuid() + Path.GetExtension(imageUpload.FileName);
                slider.ResimPath = imageWay;
                bitImage.Save(Server.MapPath(imageWay));
                if (ModelState.IsValid)
                {
                    ContextDB.Connect.SliderDal.AddOrUpdate(slider);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    ContextDB.Connect.SliderDal.AddOrUpdate(slider);
                    return RedirectToAction("Index");
                }
            }
            return View(slider);
        }

        [HttpPost]
        public bool DeleteSlider(int id)
        {
            try
            {
                Slider slider = ContextDB.Connect.SliderDal.GetById(id);
                string deletePath = Request.MapPath(slider.ResimPath);
                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }
                ContextDB.Connect.SliderDal.Remove(slider);
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