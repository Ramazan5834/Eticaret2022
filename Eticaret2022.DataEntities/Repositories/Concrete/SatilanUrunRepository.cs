using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.DataEntities.Repositories.Abstract;

namespace Eticaret2022.DataEntities.Repositories.Concrete
{
    public class SatilanUrunRepository:GenericRepository<SatilanUrun>,ISatilanUrunDal
    {
        private readonly Eticaret2022Context _context;
        public SatilanUrunRepository(Eticaret2022Context context) : base(context)
        {
            _context = context;
        }
    }
}
