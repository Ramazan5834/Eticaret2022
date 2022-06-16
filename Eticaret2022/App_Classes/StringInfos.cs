using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret2022.App_Classes
{
    public class RoleInfo
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
    }

    public class ActiveTempDataInfo
    {
        public const string UpCategories = "UpCategories";
        public const string DownCategories = "DownCategories";
        public const string Products = "Products";
        public const string NewOrders = "NewOrders";
        public const string ConfirmedOrders = "ConfirmedOrders";
        public const string RejectedOrders = "RejectedOrders";
        public const string NewContacts = "NewContacts";
        public const string PastContacts = "PastContacts";
        public const string UnconfirmedComments = "UnconfirmedComments";
        public const string PastComments = "PastComments";
        public const string Bank = "Bank";
        public const string SiteAbout = "SiteAbout";
        public const string Slider = "Slider";
        public const string ListAdmins = "ListAdmins";
        public const string AccountDetailAndEdit = "AccountDetailAndEdit";
        public const string SystemError = "SystemError";
    }

}