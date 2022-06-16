using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.DataEntities.Repositories.Abstract;

namespace Eticaret2022.DataEntities.Repositories.Concrete
{
    public class UrunYorumRepository:GenericRepository<UrunYorum>,IUrunYorumDal
    {
        private readonly Eticaret2022Context _context;
        public UrunYorumRepository(Eticaret2022Context context) : base(context)
        {
            _context = context;
        }

        public List<UrunYorum> GetUnconfirmedUrunYorumlar()
        {
            return _context.UrunYorum.Where(I => I.OnayDurum == false).ToList();
        }

        public List<UrunYorum> GetConfirmedUrunYorumlar()
        {
            return _context.UrunYorum.Where(I => I.OnayDurum == true).ToList();
        }
    }
}
