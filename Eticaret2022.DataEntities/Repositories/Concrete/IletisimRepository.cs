using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.DataEntities.Repositories.Abstract;

namespace Eticaret2022.DataEntities.Repositories.Concrete
{
    public class IletisimRepository : GenericRepository<Iletisim>, IIletisimDal
    {
        private readonly Eticaret2022Context _context;
        public IletisimRepository(Eticaret2022Context context) : base(context)
        {
            _context = context;
        }

        public List<Iletisim> GetReadIletisimler()
        {
            return _context.Iletisim.Where(I => I.Okundu == true).OrderByDescending(I=>I.Tarih).ToList();
        }

        public List<Iletisim> GetUnreadIletisimler()
        {
            return _context.Iletisim.Where(I => I.Okundu == false).OrderByDescending(I => I.Tarih).ToList();
        }
    }
}
