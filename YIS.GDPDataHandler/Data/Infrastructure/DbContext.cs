using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YIS.GDPDataHandler.Factories;

namespace YIS.GDPDataHandler.Data.Infrastructure
{
    public abstract class DbContext : System.Data.Entity.DbContext
    {
        protected DbContext() : base(ConnectionStringSettingFactory
            .GetConnectionStringSettings()
            .GetConnectionStringBy("DefaultConnection")) { }

        protected DbContext(DbConnection connection) : base(connection, true) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            DontUseEntityFrameworkCodeFirstInitializer();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();         
        }

        public void DontUseEntityFrameworkCodeFirstInitializer()
        {
            Database.SetInitializer<DbContext>(null);
        }
    }
}
