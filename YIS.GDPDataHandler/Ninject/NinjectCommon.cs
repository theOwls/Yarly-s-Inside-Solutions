using Ninject;
using YIS.GDPDataHandler.Configuration;
using YIS.GDPDataHandler.Data.Infrastructure;
using YIS.GDPDataHandler.Factories;
using YIS.GDPDataHandler.Services;
using YIS.GDPDataHandler.SqlConnections;

namespace YIS.GDPDataHandler.Ninject
{
    public class NinjectCommon
    {
        public void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InTransientScope();
            kernel.Bind<DbContext>().To<Infrastructure.DbContext>();
            kernel.Bind<IConfigurationManager>().To<DatabaseConfigurationManager>();
            kernel.Bind<IApplicationSettings>().To<ApplicationSettings>().InTransientScope();
            kernel.Bind<IEntityDataTableFactory>().To<EntityDataTableFactory>().InTransientScope();
            kernel.Bind<ICSVParsingService>().To<CSVParsingService>().InTransientScope();
            kernel.Bind<IDtoToIndustryObjectService>().To<DtoToIndustryObjectService>().InTransientScope();
            kernel.Bind<IGDPDtoProcessingService>().To<GDPDtoProcessingService>().InTransientScope();
            kernel.Bind<IConnectionStringManager>().To<AwkwardConnectionManager>().InTransientScope();
            kernel.Bind<IConnectionSettings>().To<ConnectionStringSettings>().InTransientScope();
            kernel.Bind<ISqlConnectionStringManager>().To<SqlConnectionStringManager>().InTransientScope();
            

            kernel.Bind<IIndustryImportService>().To<IndustryImportService>().InTransientScope();
        }
    }
}
