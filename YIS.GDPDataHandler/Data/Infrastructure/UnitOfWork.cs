using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace YIS.GDPDataHandler.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private Dictionary<Type, object> _repositories;

        public DbContext Context { get { return _context; } }

        public bool WriteLocked { get; set; }

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.Keys.Contains(typeof(T)))
                return _repositories[typeof(T)] as IRepository<T>;

            var repository = new Repository<T>(Context);
            _repositories.Add(typeof(T), repository);

            return repository;
        }

        public T GetByKey<T>(params object[] key) where T : class
        {
            var repo = this.GetRepository<T>();
            return repo.GetByKey(key);
        }

        public void SaveChanges(bool writeThroughLock = false)
        {
            if (WriteLocked && !writeThroughLock)
                return;
            try
            {
                Context.SaveChanges();
            }
            catch(DbEntityValidationException ex)
            {
                throw new Exception(ex.EntityValidationErrors
                    .First()
                    .ValidationErrors
                    .First()
                    .ErrorMessage);
            }
        }
    }
}
