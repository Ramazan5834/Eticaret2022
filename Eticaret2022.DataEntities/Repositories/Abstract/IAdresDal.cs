using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;

namespace Eticaret2022.DataEntities.Repositories.Abstract
{
    public interface IAdresDal : IGenericDal<Adres>
    {
        List<Adres> GetCustomerActiveAdresses(string userId);
    }
}
