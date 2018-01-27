using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YIS.GDPDataHandler.Configuration;
using YIS.GDPDataHandler.Data.Infrastructure;
using YIS.GDPDataHandler.Factories;
using YIS.GDPDataHandler.Ninject;
using YIS.GDPDataHandler.Services;
using YIS.GDPDataHandler.SqlConnections;

namespace YIS.GDPDataHandler
{
    public class Program
    {
        static IKernel _ninjectKernel;

         
        static IUnitOfWork _unitOfWork;
        static IConfigurationManager _configurationManager;
        static IApplicationSettings _applicationSettings;
        static IEntityDataTableFactory _entityTableFactory;
        static ICSVParsingService _csvParsingService;
        static IDtoToIndustryObjectService _dtoObjectService;
        static IGDPDtoProcessingService _gdpProcessingServce;
        static IConnectionSettings _connectionSettings;
        static ISqlConnectionStringManager _sqlConnectionStringManager;
        static IIndustryImportService _industryImportService;


        static void Main(string[] args)
        {
            InitiliaseDependencies();
            var _csvParsingService = new CSVParsingService();
            var _entityTableFactory = new EntityDataTableFactory();
            var _dtoObjectService = new DtoToIndustryObjectService();
            var _gdpProcessingServce = new GDPDtoProcessingService(_entityTableFactory, _dtoObjectService);
            



            var gdpDataList = _csvParsingService.ParseCSV();
            var dataTables = _gdpProcessingServce.BuildDataTablesList(gdpDataList);
            _industryImportService.Import(dataTables);
            //16/1/18 TODO
            //Figure out ninject? Not really a priority, but you're going to start needing to look at it, especially for config
            //Get a database setup and import that data. Make some table gateways. I've already got the entity factories working
            //Import method mofo
        }

        private static void InitiliaseDependencies()
        {
            _ninjectKernel = NinjectFactory.GetInitialisedStandardKernelUsing(new NinjectCommon().RegisterServices);
            _unitOfWork = _ninjectKernel.Get<IUnitOfWork>();
            _configurationManager = _ninjectKernel.Get<IConfigurationManager>();
            _applicationSettings = _ninjectKernel.Get<IApplicationSettings>();
            _csvParsingService = _ninjectKernel.Get<ICSVParsingService>();
            _dtoObjectService = _ninjectKernel.Get<IDtoToIndustryObjectService>();
            _entityTableFactory = _ninjectKernel.Get<IEntityDataTableFactory>();
            _gdpProcessingServce = _ninjectKernel.Get<IGDPDtoProcessingService>();
            _connectionSettings = _ninjectKernel.Get<IConnectionSettings>();
            _sqlConnectionStringManager =
                _ninjectKernel.Get<ISqlConnectionStringManager>();     
            _industryImportService = _ninjectKernel.Get<IIndustryImportService>();
        }
    }
}
