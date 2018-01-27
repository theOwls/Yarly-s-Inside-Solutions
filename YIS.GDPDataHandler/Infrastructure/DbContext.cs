using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YIS.GDPDataHandler.Db;

namespace YIS.GDPDataHandler.Infrastructure
{
    public class DbContext : Data.Infrastructure.DbContext
    {
        public DbContext() { }
        public DbContext(DbConnection connection)
            : base(connection) { }
        public virtual IDbSet<IndustryAnnualGDP> IndustryAnnualGDP { get; set; }
    }
}
