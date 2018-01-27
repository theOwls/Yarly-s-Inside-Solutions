using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YIS.GDPDataHandler.Db;

namespace YIS.GDPDataHandler.Services
{
    public interface IDtoToIndustryObjectService
    {
        List<IndustryAnnualGDP> ParseIndustryDtoToModelObject(List<IndustryYearIndexDto> industryYearIndexDtoList); 
    }
}
