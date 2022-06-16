using System.Web;
using System.Web.Mvc;
using Eticaret2022.App_Attributes;
using Eticaret2022.App_Classes;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Eticaret2022.Areas.Customer.Controllers
{
    public class AuthController : Controller
    {
        // GET: Customer/Auth
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [AccessDeniedAuthorize(Roles = RoleInfo.Customer)]
        public ActionResult AccountDetail()
        {
            ApplicationUser applicationUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return View(applicationUser);
        }

        [AccessDeniedAuthorize(Roles = RoleInfo.Customer)]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UpdateAccount(AspNetUsers applicationUser)
        {
            if (ModelState.IsValid)
            {
                applicationUser.UserName = applicationUser.Email;
                ContextDB.Connect.AspNetUsersDal.AddOrUpdate(applicationUser);
                TempData["message"] = "İşleminiz başarı ile gerçekleşti.";
                return RedirectToAction("AccountDetail");
            }

            ApplicationUser user = new ApplicationUser
            {
                Email = applicationUser.Email,
                Id = applicationUser.Id,
                Surname = applicationUser.Surname,
                AccessFailedCount = applicationUser.AccessFailedCount,
                EmailConfirmed = applicationUser.EmailConfirmed,
                LockoutEnabled = applicationUser.LockoutEnabled,
                LockoutEndDateUtc = applicationUser.LockoutEndDateUtc,
                Name = applicationUser.Name,
                PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed,
                PhoneNumber = applicationUser.PhoneNumber,
                PasswordHash = applicationUser.PasswordHash,
                SecurityStamp = applicationUser.SecurityStamp,
                TwoFactorEnabled = applicationUser.TwoFactorEnabled,
                UserName = applicationUser.UserName
            };
            TempData["message"] = "Bir Hata Oluştu";
            return View("AccountDetail", user);
        }

        [AccessDeniedAuthorize(Roles = RoleInfo.Customer)]
        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("~/Views/Error/ServerError.cshtml") : View();
        }

        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}