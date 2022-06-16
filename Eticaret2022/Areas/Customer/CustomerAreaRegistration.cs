using System.Web.Mvc;

namespace Eticaret2022.Areas.Customer
{
    public class CustomerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Customer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               "Anasayfa",
               "anasayfa",
               new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            context.MapRoute(
              "Hakkimizda",
              "hakkimizda",
              new { controller = "About", action = "SiteAbout", id = UrlParameter.Optional }
           );

            context.MapRoute(
              "AdresListesi",
              "adres-listesi",
              new { controller = "Address", action = "Addresses", id = UrlParameter.Optional }
           );

            context.MapRoute(
             "AdresEkle",
             "adres-ekle",
             new { controller = "Address", action = "CreateAddress", id = UrlParameter.Optional }
           );

            context.MapRoute(
             "AdresDuzenleme",
             "adres-duzenle",
             new { controller = "Address", action = "EditAddress", id = UrlParameter.Optional }
           );

            context.MapRoute(
             "BankaBilgileri",
             "banka-bilgilerimiz",
             new { controller = "Bank", action = "BankInfo", id = UrlParameter.Optional }
           );

            context.MapRoute(
             "SonSepet",
             "sepetim",
             new { controller = "Basket", action = "FinalBasket", id = UrlParameter.Optional }
           );

            context.MapRoute(
             "KategoriDetay",
             "kategori-detay",
             new { controller = "Category", action = "Detail", id = UrlParameter.Optional }
           );

            context.MapRoute(
             "Iletisim",
             "iletisim",
             new { controller = "Contact", action = "ContactConnect", id = UrlParameter.Optional }
           );


            context.MapRoute(
             "iptaliade",
             "iptal-iade-sozlesmesi",
             new { controller = "Home", action = "İptalIadeSozlesmesi", id = UrlParameter.Optional }
           );
            context.MapRoute(
           "gizlilik",
           "gizlilik-sozlesmesi",
           new { controller = "Home", action = "GizlilikSozlesmesi", id = UrlParameter.Optional }
         );

            context.MapRoute(
          "mesafelisatis",
          "mesafeli-satis-sozlesmesi",
          new { controller = "Home", action = "MesafeliSatisSozlesmesi", id = UrlParameter.Optional }
        );
            context.MapRoute(
             "Siparislerim",
             "siparislerim",
             new { controller = "Order", action = "PastOrders", id = UrlParameter.Optional }
           );

            context.MapRoute(
             "Odeme",
             "odeme",
             new { controller = "Payment", action = "Index", id = UrlParameter.Optional }
           );

            context.MapRoute(
             "Girisyap",
             "giris-yap",
             new { controller = "Auth", action = "LogIn", id = UrlParameter.Optional }
           );

            context.MapRoute(
             "UyeOl",
             "uye-ol",
             new { controller = "Auth", action = "Register", id = UrlParameter.Optional }
           );

            context.MapRoute(
             "SifreDegistir",
             "sifre-degistir",
             new { controller = "Auth", action = "ChangePassword", id = UrlParameter.Optional }
            );

            context.MapRoute(
             "SifremiUnuttum",
             "sifremi-unuttum",
             new { controller = "Auth", action = "ForgotPassword", id = UrlParameter.Optional }
            );

            context.MapRoute(
             "Hesabim",
             "hesabim",
             new { controller = "Auth", action = "AccountDetail", id = UrlParameter.Optional }
           );

            context.MapRoute(
             "UrunDetay",
             "{productId}--{url}",
             new { controller = "Product", action = "Detail", id = UrlParameter.Optional }
            );

            context.MapRoute(
             "Customer_default",
             "Customer/{controller}/{action}/{id}",
             new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}