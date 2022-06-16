using System.Collections.Generic;
using System.Web.Mvc;
using Eticaret2022.App_Attributes;
using Eticaret2022.App_Classes;
using Eticaret2022.DataEntities.DataModels;
using Microsoft.AspNet.Identity;

namespace Eticaret2022.Areas.Customer.Controllers
{
    [AccessDeniedAuthorize(Roles = RoleInfo.Customer)]
    public class OrderController : Controller
    {
        // GET: Customer/Order
        public ActionResult PastOrders()
        {
            List<SatisDetay> satisDetaylar = ContextDB.Connect.SatisDetayDal.GetCustomerSatisDetaylar(User.Identity.GetUserId());
            return View(satisDetaylar);
        }

       
    }

}