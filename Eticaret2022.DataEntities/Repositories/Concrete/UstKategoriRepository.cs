using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.DataEntities.Repositories.Abstract;

namespace Eticaret2022.DataEntities.Repositories.Concrete
{
    public class UstKategoriRepository:GenericRepository<UstKategori>,IUstKategoriDal
    {
        private readonly Eticaret2022Context _context;
        public UstKategoriRepository(Eticaret2022Context context) : base(context)
        {
            _context = context;
        }

        public List<UstKategori> GetActiveUstKategoriler()
        {
            return _context.UstKategori.Where(I => I.AktifDurum == true).ToList();
        }
        
    }
}
