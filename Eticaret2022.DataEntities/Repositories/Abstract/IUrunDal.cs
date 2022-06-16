using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.DataEntities.Repositories.Abstract
{
    public interface IUrunDal : IGenericDal<Urun>
    {
        List<Urun> GetLatestUrunler();
        List<Urun> GetActiveUrunler();
        List<Urun> GetSearchingProducts(string searchString);
        int GetUrunlerLowStockCount();
    }
}
