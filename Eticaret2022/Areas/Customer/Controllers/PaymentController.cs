using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret2022.App_Attributes;
using Eticaret2022.App_Classes;
using Eticaret2022.Areas.Customer.Models;
using Eticaret2022.BussinessLayer.Basket;
using Eticaret2022.BussinessLayer.EmailHelper;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Eticaret2022.Areas.Customer.Controllers
{
    [AccessDeniedAuthorize(Roles = RoleInfo.Customer)]
    public class PaymentController : Controller
    {
        public ActionResult Index()
        {
            PaymentGetModel model = new PaymentGetModel();
            AspNetUsers usermodel = new AspNetUsers();
            List<Adres> userAdressModel = new List<Adres>();
            
            usermodel = ContextDB.Connect.AspNetUsersDal.GetAll().FirstOrDefault(ss => ss.Id == User.Identity.GetUserId());
            userAdressModel = ContextDB.Connect.AdresDal.GetAll().Where(ss => ss.MusteriId == User.Identity.GetUserId() && ss.AktifDurum).ToList();

            model.userInfo = usermodel;
            model.userAddressList = userAdressModel;
            model.paymentTypeList = ContextDB.Connect.OdemeTipDal.GetAll();
            return View(model);
        }

        public JsonResult Payment(PaymentPostModel pay)
        {
            var Basket = (Basket)Session["Basket"];
            if (pay.PaymentType == 0 || pay.IndividualType == 0 || pay.AddressId == 0)
            {
                return Json(new { message = "Lütfen Gerekli Alanları Doldurunuz !", type = 'e' });
            }

            if (Basket != null)
            {
                if (Basket.BasketLines.Count > 0)
                {
                    double satisDetayTotalFiyat = 0;
                    List<Urun> BasketProducts = new List<Urun>();
                    foreach (var item in Basket.BasketLines)
                    {
                        var product = ContextDB.Connect.UrunDal.GetById(item.Urun.Id);
                        if (product.AktifDurum == false || item.Adet > product.Stok)
                        {
                            return Json(new { message = " İşlem Yapılırken Bir Hata Oluştu Lütfen Tekrar Deneyiniz !", type = 'e' });

                        }
                        BasketProducts.Add(product);
                        satisDetayTotalFiyat += product.Fiyat * item.Adet;
                    }

                    var satisDetay = new SatisDetay
                    {
                        MusteriId = User.Identity.GetUserId(),
                        OdemeTipId = pay.PaymentType,
                        KargoNumarasi = 0,
                        OnayDurum = false,
                        AdresId = pay.AddressId,
                        Okundu = false,
                        Tarih = DateTime.Now,
                        TotalFiyat = satisDetayTotalFiyat
                    };

                    int satisDetayId = ContextDB.Connect.SatisDetayDal.AddWithRetObject(satisDetay).Id;

                    Fatura fatura = new Fatura()
                    {
                        Id = satisDetayId,
                        FirmaAdi = pay.FirmaAdi,
                        VergiDairesi = pay.VergiDairesi,
                        VergiNo = pay.VergiNo,
                        TcKimlik = pay.TcKimlik,
                    };
                    ContextDB.Connect.FaturaDal.Add(fatura);
                    foreach (var item in BasketProducts)
                    {
                        ContextDB.Connect.SatilanUrunDal.Add(new SatilanUrun
                        {
                            SatisDetayId = satisDetayId,
                            UrunId = item.Id,
                            UrunAnlikFiyat = item.Fiyat,
                            Adet = Basket.BasketLines.FirstOrDefault(ss => ss.Urun.Id == item.Id).Adet
                        });
                        var product = ContextDB.Connect.UrunDal.GetById(item.Id);
                        product.Stok = (short)(Convert.ToInt16(product.Stok) - Convert.ToInt16(Basket.BasketLines.FirstOrDefault(ss => ss.Urun.Id == item.Id).Adet));
                        ContextDB.Connect.UrunDal.AddOrUpdate(product);
                    }

                    //EmailHelper.SendEmailCreateOrder(System.Web.HttpContext.Current.GetOwinContext()
                    //    .GetUserManager<ApplicationUserManager>()
                    //    .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()).Email,satisDetay);
                    EmailHelper.SendEmailCreateOrder(satisDetay);
                    EmailHelper.SendEmailToAdminAfterCreateOrder(satisDetay,
                        ContextDB.Connect.SiteHakkindaDal.CompanyEmail());

                    HttpContext.Session["Basket"] = null;
                    return Json(new { message = " Siparişiniz Alınmıştır!", type = 's' });

                }

                return Json(new { message = " İşlem Yapılırken Bir Hata Oluştu Lütfen Tekrar Deneyiniz !", type = 'e' });
            }

            return Json(new { message = " İşlem Yapılırken Bir Hata Oluştu Lütfen Tekrar Deneyiniz !", type = 'e' });
        }
    }
}
