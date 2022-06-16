using System.Web.Mvc;
using Eticaret2022.App_Classes;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.Areas.Customer.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Customer/Category
        public ActionResult Detail(int categoryId)
        {
            AltKategori altKategori = ContextDB.Connect.AltKategoriDal.GetById(categoryId);
            return View(altKategori);
        }
    }
}