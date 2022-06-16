using System.Linq;
using System.Web.Mvc;
using Eticaret2022.App_Classes;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.Areas.Customer.Controllers
{
    public class AboutController : Controller
    {
        // GET: Customer/About
        public ActionResult SiteAbout()
        {
            SiteHakkinda SiteAbout = ContextDB.Connect.SiteHakkindaDal.GetAll().FirstOrDefault();
            return View(SiteAbout);
        }
    }
}