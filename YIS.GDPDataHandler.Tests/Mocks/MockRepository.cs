using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Reflection;
using YIS.GDPDataHandler.Data.Infrastructure;

namespace YIS.GDPDataHandler.Tests.Mocks
{
    public class MockRepository<T> : IRepository<T> where T: class
    {
        List<T> _dataRepository;

        public MockRepository()
        {
            _dataRepository = new List<T>();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T,bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            bool asNoTracking = false)
        {
            IQueryable<T> query = _dataRepository.AsQueryable();
            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }
            if(filter != null)
            {
                query = query.Where(filter);              
            }
            foreach(var includeProperty in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query) : query;
        }

        public T GetByKey(params object[] key)
        {
            var keyProperty = GetKeyPropertyForRepositoryType();
            return _dataRepository
                .SingleOrDefault(obj => keyProperty.GetValue(obj).ToString() == key.First().ToString());
        }

        public void Add(T entity)
        {
            _dataRepository.Add(entity);
        }

        public void Update(T entity)
        {
            var keyProperty = GetKeyPropertyForRepositoryType();
            var originalEntity = _dataRepository
                .SingleOrDefault(obj => keyProperty.GetValue(obj).ToString() ==
                                        keyProperty.GetValue(entity).ToString());
            this.Delete(originalEntity);
            this.Add(entity);
        }

        public void Delete(T entity)
        {
            _dataRepository.Remove(entity);
        }

        public void Delete(Guid Id)
        {
            var entity = this.GetByKey(Id);
            _dataRepository.Remove(entity);
        }

        public int Count()
        {
            return _dataRepository.Count;
        }

        private PropertyInfo GetKeyPropertyForRepositoryType()
        {
            const string IDPropertyFieldName = "Id";

            var keyProperty = typeof(T).GetProperty
                (
                    IDPropertyFieldName,
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.IgnoreCase
                );
            return keyProperty;
        }
    }
}
