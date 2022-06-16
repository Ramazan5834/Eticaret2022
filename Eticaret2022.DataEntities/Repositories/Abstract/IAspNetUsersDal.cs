using Eticaret2022.DataEntities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret2022.DataEntities.Repositories.Abstract
{

    public interface IAspNetUsersDal : IGenericDal<AspNetUsers>
    {
        string GetActiveUserNameAndSurname(string userId);
        List<AspNetUsers> GetAdmins();
    }
}
