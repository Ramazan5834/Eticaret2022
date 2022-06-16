using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.DataEntities.Repositories.Abstract;

namespace Eticaret2022.DataEntities.Repositories.Concrete
{
    public class SatisDetayRepository : GenericRepository<SatisDetay>, ISatisDetayDal
    {
        private readonly Eticaret2022Context _context;
        public SatisDetayRepository(Eticaret2022Context context) : base(context)
        {
            _context = context;
        }

        public List<SatisDetay> GetCustomerSatisDetaylar(string userId)
        {
            return _context.SatisDetay.Where(I => I.MusteriId == userId).OrderByDescending(I => I.Tarih).ToList();
        }

        public List<SatisDetay> GetUnreadSatisDetaylar()
        {
            return _context.SatisDetay.Where(I => I.Okundu == false).OrderByDescending(I => I.Tarih).ToList();
        }

        public List<SatisDetay> GetConfirmedSatisDetaylar()
        {
            return _context.SatisDetay.Where(I => I.OnayDurum == true && I.Okundu == true).OrderByDescending(I => I.Tarih).ToList();
        }

        public List<SatisDetay> GetRejectedSatisDetaylar()
        {
            return _context.SatisDetay.Where(I => I.OnayDurum == false && I.Okundu == true).OrderByDescending(I => I.Tarih).ToList();
        }
    }
}
