using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YIS.GDPDataHandler.Db;

namespace YIS.GDPDataHandler.Services
{
    public class DtoToIndustryObjectService:IDtoToIndustryObjectService
    {
        public List<IndustryAnnualGDP> ParseIndustryDtoToModelObject(List<IndustryYearIndexDto> industryYearIndexDtoList)
        {
            var industrySectorList = new List<IndustryAnnualGDP>();
            foreach(var industryIndex in industryYearIndexDtoList)
            {
                industrySectorList.Add(new IndustryAnnualGDP
                {
                    Id = Guid.NewGuid(),
                    DateCode = industryIndex.DateCode,
                    Value = industryIndex.Value,
                    IndustrySector = industryIndex.IndustrySector
                });
            }
            return industrySectorList;
        }
    }
}
