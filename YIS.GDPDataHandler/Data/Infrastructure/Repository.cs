using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Data.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext DbContext { get; set; }
        private DbSet<T> DbSet { get; set; }
        public Repository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentException("dbcontext is null");

            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            bool asNoTracking = false)
        {
            IQueryable<T> query = DbSet;

            if (asNoTracking)
                query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            foreach(var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return orderBy != null ? orderBy(query) : query;
        }

        public T GetByKey(params object[] key)
        {
            return DbSet.Find(key);
        }

        public void Add(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if(dbEntityEntry.State == EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {            
            var dbEntityEntry = DbContext.Entry(entity);
            var keyProperty = dbEntityEntry
                                    .Entity
                                    .GetType()
                                    .GetProperties()
                                    .FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(KeyAttribute)));
            var keyObject = keyProperty.GetValue(dbEntityEntry.Entity);

            if (keyObject == null)
                keyObject = DbSet
                    .Create()
                    .GetType()
                    .GetProperty("Id")
                    .GetValue(entity);

            if(dbEntityEntry.State == EntityState.Detached)
            {
                var attachedEntity = GetByKey(keyObject);
                if(attachedEntity != null)
                {
                    var attachedEntry = DbContext.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    DbSet.Attach(entity);
                    dbEntityEntry.State = EntityState.Modified;
                }
            }
        }

        public void Delete(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if(dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public void Delete(Guid id)
        {
            var entity = GetByKey(id);
            if (entity != null)
                Delete(entity);
        }

        public int Count()
        {
            return GetAll().Count();
        }
    }
}
