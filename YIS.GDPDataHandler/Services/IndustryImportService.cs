using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YIS.GDPDataHandler.SqlConnections;

namespace YIS.GDPDataHandler.Services
{
    public class IndustryImportService : IIndustryImportService
    {
        readonly string _sqlConnectionString;

        const string IndustryImportTableName = "IndustryAnnualGDP";
        const string DefaultConnectionStringName = "DefaultConnection";

        public string DatabaseName { get; }

        public IndustryImportService(ISqlConnectionStringManager sqlConnectionStringManager)            
        {
            DatabaseName =
                sqlConnectionStringManager.GetDatabaseNameFor(DefaultConnectionStringName);
            _sqlConnectionString =
                sqlConnectionStringManager.GetConnectionStringWith(DefaultConnectionStringName);
        }

        public void Import(DataTable dataTable)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(_sqlConnectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        using (SqlBulkCopy bulkCopyLoader =
                            new SqlBulkCopy(connection,
                            SqlBulkCopyOptions.TableLock |
                            SqlBulkCopyOptions.FireTriggers,
                            transaction))
                        {
                            bulkCopyLoader.DestinationTableName = IndustryImportTableName;
                            bulkCopyLoader.WriteToServer(dataTable);
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
