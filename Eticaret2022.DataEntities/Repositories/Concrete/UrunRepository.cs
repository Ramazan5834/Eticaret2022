using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.DataEntities.Repositories.Abstract;

namespace Eticaret2022.DataEntities.Repositories.Concrete
{
    public class UrunRepository : GenericRepository<Urun>, IUrunDal
    {
        private readonly Eticaret2022Context _context;
        public UrunRepository(Eticaret2022Context context) : base(context)
        {
            _context = context;
        }

        public List<Urun> GetLatestUrunler()
        {
            List<Urun> urunler = _context.Urun.Where(I => I.AktifDurum).OrderByDescending(I => I.EklenmeTarihi)
                .ToList();
            if (urunler.Count > 10)
            {
                return urunler.Take(10).ToList();
            }
            else
            {
                return urunler;
            }
        }

        public List<Urun> GetActiveUrunler()
        {
            return _context.Urun.Where(I => I.AktifDurum).OrderByDescending(I => I.EklenmeTarihi)
                .ToList();
        }

        public List<Urun> GetSearchingProducts(string searchString)
        {
            return _context.Urun.Where(I => I.AktifDurum).Where(I => I.Adi.Contains(searchString) || I.Aciklama.Contains(searchString)).ToList();
        }

        public int GetUrunlerLowStockCount()
        {
            return _context.Urun.Count(I => I.AktifDurum && I.Stok <= 3);
        }
    }
}
