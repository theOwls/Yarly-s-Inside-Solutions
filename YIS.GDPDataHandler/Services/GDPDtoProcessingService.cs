using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YIS.GDPDataHandler.Factories;

namespace YIS.GDPDataHandler.Services
{
    /// <summary>
    /// Let's see, I've not done one of the before. Diary time!
    /// 14/1/18
    /// This takes a datatable factory, they work with lists of the industry objects.
    /// The problem is assigning IDs on the fly. I wanted to do it in a familiar way. 
    /// </summary>
    public class GDPDtoProcessingService:IGDPDtoProcessingService
    {
        static IEntityDataTableFactory _entityDataTableFactory;
        static IDtoToIndustryObjectService _industryObjectService;

        public GDPDtoProcessingService(EntityDataTableFactory entityDataTableFactory,
            DtoToIndustryObjectService dtoToIndustryService)
        {
            _entityDataTableFactory = entityDataTableFactory;
            _industryObjectService = dtoToIndustryService;
        }

        public DataTable BuildDataTablesList(List<IndustryYearIndexDto> industryIndexDtoList)
        {
            var industrySectorList = _industryObjectService.ParseIndustryDtoToModelObject(industryIndexDtoList);

            var industryEntitiesTable = _entityDataTableFactory.CreateDataTableFrom(industrySectorList);

            return industryEntitiesTable;
        }
    }
}
