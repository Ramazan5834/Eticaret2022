using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret2022.DataEntities.Repositories.Abstract
{
    public interface IGenericDal<TEntity> where TEntity : class
    {
        TEntity GetById(int id);

        List<TEntity> GetAll();

        void AddOrUpdate(TEntity entity);

        void Add(TEntity entity);

        void AddRange(List<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(List<TEntity> entities);

        TEntity AddWithRetObject(TEntity entity);

    }
}
