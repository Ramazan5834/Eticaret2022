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
    //[Authorize(Roles = "Admin")]
    [AccessDeniedAuthorize(Roles = RoleInfo.Admin)]
    public class BankController : Controller
    {
        // GET: Admin/Bank
        public ActionResult Index()
        {
            TempData["Active"] = ActiveTempDataInfo.Bank;
            List<BankaBilgi> banks = ContextDB.Connect.BankaBilgiDal.GetAll();
            return View(banks);
        }

        public ActionResult CreateBankInfo()
        {
            TempData["Active"] = ActiveTempDataInfo.Bank;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateBankInfo(BankaBilgi bankInfo, HttpPostedFileBase imageUpload)
        {
            if (imageUpload != null)
            {
                Image img = Image.FromStream(imageUpload.InputStream);
                Bitmap bitImage = new Bitmap(img,768,768);
                string imageWay = "/Content/App_Images/BankaImages/" + Guid.NewGuid() + Path.GetExtension(imageUpload.FileName);
                bankInfo.ResimPath = imageWay;
                bitImage.Save(Server.MapPath(imageWay));
                if (ModelState.IsValid)
                {
                    ContextDB.Connect.BankaBilgiDal.AddOrUpdate(bankInfo);
                    return RedirectToAction("Index");
                }
            }
            return View(bankInfo);
        }


        public ActionResult UpdateBankInfo(int bankInfoId)
        {
            TempData["Active"] = ActiveTempDataInfo.Bank;
            BankaBilgi bankaBilgi = ContextDB.Connect.BankaBilgiDal.GetById(bankInfoId);
            return View(bankaBilgi);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UpdateBankInfo(BankaBilgi bankaBilgi, HttpPostedFileBase imageUpload)
        {
            if (imageUpload != null)
            {
                string deletePath = Request.MapPath(bankaBilgi.ResimPath);
                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }
                Image img = Image.FromStream(imageUpload.InputStream);
                Bitmap bitImage = new Bitmap(img, 768, 768);
                string imageWay = "/Content/App_Images/BankaImages/" + Guid.NewGuid() + Path.GetExtension(imageUpload.FileName);
                bankaBilgi.ResimPath = imageWay;
                bitImage.Save(Server.MapPath(imageWay));
                if (ModelState.IsValid)
                {
                    ContextDB.Connect.BankaBilgiDal.AddOrUpdate(bankaBilgi);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    ContextDB.Connect.BankaBilgiDal.AddOrUpdate(bankaBilgi);
                    return RedirectToAction("Index");
                }
            }
            return View(bankaBilgi);
        }

        [HttpPost]
        public bool DeleteBankInfo(int id)
        {
            try
            {
                BankaBilgi bankaBilgi = ContextDB.Connect.BankaBilgiDal.GetById(id);
                ContextDB.Connect.BankaBilgiDal.Remove(bankaBilgi);
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