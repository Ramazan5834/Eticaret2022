using Eticaret2022.DataEntities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eticaret2022.Areas.Customer.Models
{
    public class HomePageModel
    {
        public List<Urun> LatestUrunler { get; set; }
        public List<AltKategori> MostContainAltKategoriler { get; set; }

    }
}