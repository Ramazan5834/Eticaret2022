using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret2022.App_Attributes;
using Eticaret2022.App_Classes;
using Eticaret2022.Controllers;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Eticaret2022.Areas.Admin.Controllers
{
    [AccessDeniedAuthorize(Roles = RoleInfo.Admin)]
    public class AdminSystemController : Controller
    {
        public ApplicationUserManager UserManager
        {
            get
            {
                return  HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public RoleManager<IdentityRole> RoleManager
        {
            get
            {
                return new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            }
        }

        public ActionResult ListAdmins()
        {
            TempData["Active"] = ActiveTempDataInfo.ListAdmins;
            List<ApplicationUser> allUsers = UserManager.Users.ToList();
            List<ApplicationUser> adminUsers = new List<ApplicationUser>();
            List<IdentityRole> allRoles = RoleManager.Roles.ToList();
            IdentityRole adminRole = allRoles.FirstOrDefault(I => I.Name == "Admin");
            foreach (var applicationUser in allUsers)
            {
                List<IdentityUserRole> applicationUserRoles = applicationUser.Roles.ToList();
                foreach (var applicationUserRole in applicationUserRoles)
                {
                    if (applicationUserRole.RoleId == adminRole?.Id)
                    {
                        adminUsers.Add(applicationUser);
                    }
                }
            }
            return View(adminUsers);
        }

        public ActionResult CreateNewAdmin()
        {
            TempData["Active"] = ActiveTempDataInfo.ListAdmins;
            return View();
        }

        public ActionResult AccountDetail()
        {
            TempData["Active"] = ActiveTempDataInfo.AccountDetailAndEdit;
            ApplicationUser applicationUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return View(applicationUser);
        }

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

            ApplicationUser user = new ApplicationUser()
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

        public ActionResult ChangePassword()
        {
            return View();
        }


    }
}