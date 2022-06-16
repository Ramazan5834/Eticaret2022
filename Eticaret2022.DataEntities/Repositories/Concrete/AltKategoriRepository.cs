using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.DataEntities.Repositories.Abstract;

namespace Eticaret2022.DataEntities.Repositories.Concrete
{
    public class AltKategoriRepository:GenericRepository<AltKategori>,IAltKategoriDal
    {
        private readonly Eticaret2022Context _context;
        public AltKategoriRepository(Eticaret2022Context context) : base(context)
        {
            _context = context;
        }

        public List<AltKategori> GetMoreContainAltKategoriler()
        {
            List<AltKategori> altKategoriler = _context.AltKategori.Where(I=>I.AktifDurum).OrderByDescending(I => I.Urun.Count).ToList();
            if (altKategoriler.Count > 5)
            {
                return altKategoriler.Take(5).ToList();
            }
            else
            {
                return altKategoriler;
            }
        }

        public List<AltKategori> GetActiveAltKategoriler()
        {
            return _context.AltKategori.Where(I => I.AktifDurum == true).ToList();
        }
    }
}
