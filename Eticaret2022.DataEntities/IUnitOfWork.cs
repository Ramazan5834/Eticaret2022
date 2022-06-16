using Eticaret2022.DataEntities.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret2022.DataEntities
{
    public interface IUnitOfWork : IDisposable
    {
        IAdresDal AdresDal { get; set; }
        IAltKategoriDal AltKategoriDal { get; set; }
        ISatilanUrunDal SatilanUrunDal { get; set; }
        ISatisDetayDal SatisDetayDal { get; set; }
        IUrunDal UrunDal { get; set; }
        IUrunYorumDal UrunYorumDal { get; set; }
        IUstKategoriDal UstKategoriDal { get; set; }
        IBankaBilgiDal BankaBilgiDal { get; set; }
        IIletisimDal IletisimDal { get; set; }
        ISiteHakkindaDal SiteHakkindaDal { get; set; }
        ISliderDal SliderDal { get; set; }
        IAspNetUsersDal AspNetUsersDal { get; set; }
        IOdemeTipDal OdemeTipDal { get; set; }
        ISistemHataDal SistemHataDal { get; set; }
        IFaturaDal FaturaDal { get; set; }

    }
}
