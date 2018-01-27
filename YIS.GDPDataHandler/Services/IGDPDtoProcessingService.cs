using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Services
{
    public interface IGDPDtoProcessingService
    {
        DataTable BuildDataTablesList(List<IndustryYearIndexDto> industryIndexDtoList);
    }
}
