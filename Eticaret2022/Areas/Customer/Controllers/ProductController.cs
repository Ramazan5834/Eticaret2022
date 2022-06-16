using System.Collections.Generic;
using System.Web.Mvc;
using Eticaret2022.App_Attributes;
using Eticaret2022.App_Classes;
using Eticaret2022.BussinessLayer.Manager;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.Areas.Customer.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Detail(int productId,string url)
        {
            Urun urun = ContextDB.Connect.UrunDal.GetById(productId);
            List<OdemeTip> odemeYontemleri = ContextDB.Connect.OdemeTipDal.GetAll();
            ViewBag.odemeYontemleri = odemeYontemleri;
            return View(urun);
        }

        [HttpPost]
        public JsonResult CommentAdd(UrunYorum Comment)
        {
            ResponseResult<UrunYorum> response = new ResponseResult<UrunYorum>();

            if (Comment!=null)
            {
                 ContextDB.Connect.UrunYorumDal.Add(Comment);
                 response.Message = Consts.CommentSuccessMessage;
                 response.IsSuccess = true;
                 response.Result = null;
                 return Json(response);
            }
            response.Message = Consts.CommentErrorMessage;
            response.IsSuccess = false;
            response.Result = null;
            return Json(response);

        }

     
    }
}