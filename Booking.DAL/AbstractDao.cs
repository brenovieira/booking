using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Booking.DAL
{
    public abstract class AbstractDao<TEntity> : IDao<TEntity>
        where TEntity : class, IEntity
    {
        protected DbContext DbContext { get; set; }

        protected AbstractDao(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual TEntity Save(TEntity entity)
        {
            return Save(entity, true);
        }

        public virtual TEntity Save(TEntity entity, bool autosave)
        {
            if (entity.Id == 0)
            {
                DbContext.Set<TEntity>().Add(entity);
            }
            else
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }
            
            if (autosave)
            {
                SaveChanges();
            }

            return entity;
        }

        public virtual void Save(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any()) return;

            DbContext.Configuration.AutoDetectChangesEnabled = false;
            foreach (var entity in entities) Save(entity, false);

            DbContext.ChangeTracker.DetectChanges();
            DbContext.Configuration.AutoDetectChangesEnabled = true;

            SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public bool Exists(Func<TEntity, bool> condition)
        {
            return DbContext.Set<TEntity>().Any(condition);
        }

        public IQueryable<TEntity> Get()
        {
            return DbContext.Set<TEntity>();
        }

        public virtual void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public IQueryable Query()
        {
            return DbContext.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Queryable()
        {
            return DbContext.Set<TEntity>().AsQueryable();
        }
    }
}
