using System.Collections.Generic;
using System.Web.Mvc;
using Eticaret2022.App_Classes;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.Areas.Customer.Controllers
{
    public class BankController : Controller
    {
        public ActionResult BankInfo()
        {
            List<BankaBilgi> bankInfos = ContextDB.Connect.BankaBilgiDal.GetAll();
            return View(bankInfos);
        }
    }
}