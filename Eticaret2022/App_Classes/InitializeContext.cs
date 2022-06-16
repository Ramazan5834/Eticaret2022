using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Eticaret2022.App_Classes
{
    public class InitializeContext
    {
        public static void AddRolesIfNotExist()
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Customer"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }

        public static async Task AddFirstAdminIfNotExist(ApplicationUserManager applicationUserManager)
        {
            var userManager = applicationUserManager;
            var selectUser = userManager.FindByNameAsync("sivkop@mail.com");
            if (selectUser.Result == null)
            {
                var user = new ApplicationUser { UserName = "sivkop@mail.com", Email = "sivkop@mail.com", PhoneNumber = "000000000", Name = "Sivas", Surname = "Koop" };
                var result = await userManager.CreateAsync(user, "Sivkopsifre58..");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user.Id, "Admin");
                }
            }
        }

        public static void AddSiteHakkindaIfNotExist()
        {
            var siteHakkinda = ContextDB.Connect.SiteHakkindaDal.GetAll().FirstOrDefault();
            if (siteHakkinda == null)
            {
                ContextDB.Connect.SiteHakkindaDal.Add(new SiteHakkinda()
                {
                    Adi = "SİVKOP",
                    Email = "sivkop@com",
                    Adres = "Sivas",
                    HakkimizdaBaslik = "Sivkop Hakkımızda Başlık",
                    HakkimizdaIcerik = "Sivkop Hakkımızda İçerik",
                    Tel1 = "000000000",
                    Tel2 = "000000000"
                });
            }
        }

        public static void AddOdemeTipleriIfNotExist()
        {
            List<OdemeTip> odemeTipleri = ContextDB.Connect.OdemeTipDal.GetAll();
            if (odemeTipleri.Count != 3)
            {
                OdemeTip odemeTipIban = new OdemeTip(){Adi = "Iban İle Ödeme"};
                OdemeTip odemeTipKapida = new OdemeTip() { Adi = "Kapıda İle Ödeme" };
                OdemeTip odemeTipKart = new OdemeTip() { Adi = "Kart İle Ödeme" };
                ContextDB.Connect.OdemeTipDal.Add(odemeTipIban);
                ContextDB.Connect.OdemeTipDal.Add(odemeTipKapida);
                ContextDB.Connect.OdemeTipDal.Add(odemeTipKart);
            }
        }
    }
}