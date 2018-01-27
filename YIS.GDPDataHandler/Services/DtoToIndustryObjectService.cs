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
            var SectorList = new List<IndustryAnnualGDP>();
            foreach(var industryIndex in industryYearIndexDtoList)
            {
                SectorList.Add(new IndustryAnnualGDP
                {
                    Id = Guid.NewGuid(),
                    DateCode = industryIndex.DateCode,
                    Value = industryIndex.Value,
                    Sector = industryIndex.Sector
                });
            }
            return SectorList;
        }
    }
}
