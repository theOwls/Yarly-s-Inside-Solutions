using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        DbContext Context { get; }
        bool WriteLocked { set; }
        IRepository<T> GetRepository<T>() where T : class;
        T GetByKey<T>(params object[] key) where T : class;
        void SaveChanges(bool writeThroughLock = false);
    }
}
