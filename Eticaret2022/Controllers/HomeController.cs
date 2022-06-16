using Eticaret2022.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.Repositories.Abstract;
using Eticaret2022.DataEntities.Repositories.Concrete;
using Eticaret2022.BussinessLayer.Basket;
using Eticaret2022.BussinessLayer.TranslateHelper;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.Models;


namespace Eticaret2022.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }

    }
}