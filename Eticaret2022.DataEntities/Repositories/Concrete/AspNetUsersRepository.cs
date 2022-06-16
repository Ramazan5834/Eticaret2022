using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.DataEntities.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret2022.DataEntities.Repositories.Concrete
{
    public class AspNetUsersRepository : GenericRepository<AspNetUsers>, IAspNetUsersDal
    {
        private readonly Eticaret2022Context _context;
        public AspNetUsersRepository(Eticaret2022Context context) : base(context)
        {
            _context = context;
        }

        public string GetActiveUserNameAndSurname(string userId)
        {
            AspNetUsers aspNetUser = _context.AspNetUsers.FirstOrDefault(I => I.Id == userId);
            return aspNetUser?.Name + " " + aspNetUser?.Surname;
        }

        public List<AspNetUsers> GetAdmins()
        {
            AspNetRoles adminRole = _context.AspNetRoles.FirstOrDefault(I => I.Name == "Admin");
            return adminRole?.AspNetUsers.ToList();
        }
    }
}
