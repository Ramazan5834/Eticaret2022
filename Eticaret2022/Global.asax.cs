using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Eticaret2022.App_Classes;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Eticaret2022
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected async void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeContext.AddRolesIfNotExist();
            await InitializeContext.AddFirstAdminIfNotExist(new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext())));
            InitializeContext.AddSiteHakkindaIfNotExist();
            InitializeContext.AddOdemeTipleriIfNotExist();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            HttpException httpException = exception as HttpException;

            if (httpException != null || exception != null)
            {
                string action;
                try
                {
                    switch (httpException.GetHttpCode())
                    {
                        case 403:
                            // page not found
                            action = "/erisim-yetkisi-hatasi";
                            break;
                        case 404:
                            // page not found
                            action = "/sayfa-bulunamadi-hatasi";
                            break;
                        case 500:
                            // server error
                            action = "/sunucu-hatasi";
                            break;
                        default:
                            action = "/sunucu-hatasi";
                            break;
                    }
                }
                catch (Exception exc)
                {
                    action = "/sayfa-bulunamadi-hatasi";
                }
                ContextDB.Connect.SistemHataDal.AddSistemHataFromException(exception);
                // clear error on server
                Response.Clear();
                Server.ClearError();
                Response.Redirect(action);
                // Response.Redirect(String.Format("~/Error/{0}/?message={1}", action, exception.Message));
            }
        }


    }
}
