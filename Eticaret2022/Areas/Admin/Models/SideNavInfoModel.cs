using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret2022.Areas.Admin.Models
{
    public class SideNavInfoModel
    {
        public int NewOrdersCount { get; set; }
        public int NewContactsCount { get; set; }
        public int UnconfirmedCommentsCount { get; set; }

    }
}