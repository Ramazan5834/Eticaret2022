using System;
using System.Web.Mvc;
using Eticaret2022.BussinessLayer.Basket;
using Eticaret2022.DataEntities;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.Areas.Customer.Controllers
{
    public class BasketController : Controller
    {
        public ActionResult FinalBasket()
        {
            return View(GetBasket());
        }

        public PartialViewResult BasketCustomerWidget()
        {
            return PartialView(GetBasket());
        }

        [HttpPost]
        public JsonResult AddProduct(int Id, int adet)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork(new Eticaret2022Context()))
                {
                    var Product = uow.UrunDal.GetById(Id);
                    if (Product != null)
                    {
                        GetBasket().AddProduct(Product, adet);
                        return Json(new { rtnValue = true, message = "Ürün Sepete Eklendi !" });
                    }

                    return Json(new { rtnValue = false, message = "Ürün Sepete Eklenirken Sorun Oluştu.Lütfen Tekrar Deneyiniz !" });
                }
            }
            catch (Exception e)
            {
                return Json(new { rtnValue = false, message = "Ürün Sepete Eklenirken Sorun Oluştu.Lütfen Tekrar Deneyiniz !" });
            }
        }

        [HttpPost]
        public JsonResult RemoveProductSelected(int Id,int adet)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork(new Eticaret2022Context()))
                {
                    var Product = uow.UrunDal.GetById(Id);
                    if (Product != null)
                    {
                        GetBasket().DeleteProductSelected(Product);
                        return Json(new { rtnValue = true, message = "Ürün Sepetinizden Çıkarılmıştır !" });
                    }

                    return Json(new { rtnValue = false, message = "Ürün Sepetten Çıkarılırken Sorun Oluştu.Lütfen Tekrar Deneyiniz !" });
                }
            }
            catch (Exception)
            {
                return Json(new { rtnValue = false, message = "Ürün Sepetten Çıkarılırken Sorun Oluştu.Lütfen Tekrar Deneyiniz !" });
            }
        }

        [HttpPost]
        public JsonResult RemoveProduct(int Id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork(new Eticaret2022Context()))
                {
                    var Product = uow.UrunDal.GetById(Id);
                    if (Product != null)
                    {
                        GetBasket().DeleteProduct(Product);
                        return Json(new { rtnValue = true, message = "Ürün Sepetinizden Çıkarılmıştır !" });
                    }

                    return Json(new { rtnValue = false, message = "Ürün Sepetten Çıkarılırken Sorun Oluştu.Lütfen Tekrar Deneyiniz !" });
                }
            }
            catch (Exception)
            {
                return Json(new { rtnValue = false, message = "Ürün Sepetten Çıkarılırken Sorun Oluştu.Lütfen Tekrar Deneyiniz !" });
            }
        }

        public Basket GetBasket()
        {
           
            var Basket = (Basket)Session["Basket"];
            if (Basket == null)
            {
                Basket = new Basket();
                Session["Basket"] = Basket;
            }
            return Basket;
        }

        [HttpPost]
        public void ClearBasket()
        {
            GetBasket().BasketLines.Clear();
        }

    }
}