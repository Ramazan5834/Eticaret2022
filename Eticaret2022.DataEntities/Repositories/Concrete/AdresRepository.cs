using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.DataEntities.Repositories.Abstract;

namespace Eticaret2022.DataEntities.Repositories.Concrete
{
    public class AdresRepository:GenericRepository<Adres>,IAdresDal
    {
        private readonly Eticaret2022Context _context;
        public AdresRepository(Eticaret2022Context context) : base(context)
        {
            _context = context;
        }

        public List<Adres> GetCustomerActiveAdresses(string userId)
        {
            return _context.Adres.Where(I => I.MusteriId == userId).Where(I => I.AktifDurum).ToList();
        }
    }
}
