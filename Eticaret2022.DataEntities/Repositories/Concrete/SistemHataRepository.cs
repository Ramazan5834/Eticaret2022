using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.DataEntities.Repositories.Abstract;

namespace Eticaret2022.DataEntities.Repositories.Concrete
{
    public class SistemHataRepository : GenericRepository<SistemHata>, ISistemHataDal
    {
        private readonly Eticaret2022Context _context;
        public SistemHataRepository(Eticaret2022Context context) : base(context)
        {
            _context = context;
        }

        public void AddSistemHataFromException(Exception exception)
        {
            SistemHata sistemHata = new SistemHata()
            {
                Tarih = DateTime.Now,
                Veri = exception.Data.ToString(),
                Kod = exception.HResult,
                Kaynak = exception.Source,
                Mesaj = exception.Message,
                YiginIzi = exception.StackTrace
            };
            _context.Set<SistemHata>().Add(sistemHata);
            _context.SaveChanges();
        }

        public List<SistemHata> GetSistemHatalar()
        {
            return _context.SistemHata.OrderByDescending(I => I.Tarih).ToList();
        }

    }
}
