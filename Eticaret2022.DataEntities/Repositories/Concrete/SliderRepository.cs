using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret2022.DataEntities.DataModels;
using Eticaret2022.DataEntities.Repositories.Abstract;

namespace Eticaret2022.DataEntities.Repositories.Concrete
{
    public class SliderRepository:GenericRepository<Slider>,ISliderDal
    {
        public SliderRepository(Eticaret2022Context context) : base(context)
        {
        }
    }
}
