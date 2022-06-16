using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret2022.App_Attributes;
using Eticaret2022.App_Classes;
using Eticaret2022.Areas.Admin.Models;

namespace Eticaret2022.Areas.Admin.Controllers
{
    [AccessDeniedAuthorize(Roles = RoleInfo.Admin)]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            int newOrdersCount = ContextDB.Connect.SatisDetayDal.GetUnreadSatisDetaylar().Count;
            int newContactsCount = ContextDB.Connect.IletisimDal.GetUnreadIletisimler().Count;
            int unconfirmedCommentsCount = ContextDB.Connect.UrunYorumDal.GetUnconfirmedUrunYorumlar().Count;
            int lowStockProductsCount = ContextDB.Connect.UrunDal.GetUrunlerLowStockCount();
            HomeInfoModel homeInfoModel = new HomeInfoModel()
            {
                NewOrdersCount = newOrdersCount,
                NewContactsCount = newContactsCount,
                UnconfirmedCommentsCount = unconfirmedCommentsCount,
                LowStockProductsCount = lowStockProductsCount
            };
            return View(homeInfoModel);
        }

        public PartialViewResult SideNavWidget()
        {
            int newOrdersCount = ContextDB.Connect.SatisDetayDal.GetUnreadSatisDetaylar().Count;
            int newContactsCount = ContextDB.Connect.IletisimDal.GetUnreadIletisimler().Count;
            int unconfirmedCommentsCount = ContextDB.Connect.UrunYorumDal.GetUnconfirmedUrunYorumlar().Count;
            SideNavInfoModel sideNavInfoModel = new SideNavInfoModel()
            {
                NewOrdersCount = newOrdersCount,
                NewContactsCount = newContactsCount,
                UnconfirmedCommentsCount = unconfirmedCommentsCount
            };
            return PartialView(sideNavInfoModel);
        }


    }
}