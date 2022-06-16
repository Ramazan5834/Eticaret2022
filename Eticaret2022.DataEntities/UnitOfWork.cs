using Eticaret2022.DataEntities.Repositories.Abstract;
using Eticaret2022.DataEntities.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.DataEntities
{
    public class UnitOfWork : IUnitOfWork
    {
        private Eticaret2022Context _context;
        public IAdresDal AdresDal { get; set; }
        public IAltKategoriDal AltKategoriDal { get; set; }
        public ISatilanUrunDal SatilanUrunDal { get; set; }
        public ISatisDetayDal SatisDetayDal { get; set; }
        public IUrunDal UrunDal { get; set; }
        public IUrunYorumDal UrunYorumDal { get; set; }
        public IUstKategoriDal UstKategoriDal { get; set; }
        public IBankaBilgiDal BankaBilgiDal { get; set; }
        public IIletisimDal IletisimDal { get; set; }
        public ISiteHakkindaDal SiteHakkindaDal { get; set; }
        public ISliderDal SliderDal { get; set; }
        public IAspNetUsersDal AspNetUsersDal { get; set; }
        public IOdemeTipDal OdemeTipDal { get; set; }
        public ISistemHataDal SistemHataDal { get; set; }
        public IFaturaDal FaturaDal { get; set; }

        public UnitOfWork(Eticaret2022Context context)
        {
            _context = context;
            AdresDal = new AdresRepository(context);
            AltKategoriDal = new AltKategoriRepository(context);
            SatilanUrunDal = new SatilanUrunRepository(context);
            SatisDetayDal = new SatisDetayRepository(context);
            UrunDal = new UrunRepository(context);
            UrunYorumDal = new UrunYorumRepository(context);
            UstKategoriDal = new UstKategoriRepository(context);
            BankaBilgiDal = new BankaBilgiRepository(context);
            IletisimDal = new IletisimRepository(context);
            SiteHakkindaDal = new SiteHakkindaRepository(context);
            SliderDal = new SliderRepository(context);
            AspNetUsersDal = new AspNetUsersRepository(context);
            OdemeTipDal = new OdemeTipRepository(context);
            SistemHataDal = new SistemHataRepository(context);
            FaturaDal = new FaturaRepository(context);
        }


        public void Dispose()
        {
            _context.Dispose();
        }
        

    }
}
