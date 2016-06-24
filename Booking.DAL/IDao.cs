using System;
using System.Collections.Generic;
using System.Linq;

namespace Booking.DAL
{
    public interface IDao<TEntity>
    {
        IQueryable<TEntity> Get();

        TEntity GetById(int id);

        void Delete(TEntity entity);

        TEntity Save(TEntity entity);

        void Save(IEnumerable<TEntity> entities);

        bool Exists(Func<TEntity, bool> condition);

        void SaveChanges();

        IQueryable Query();

        IQueryable<TEntity> Queryable();
    }
}
