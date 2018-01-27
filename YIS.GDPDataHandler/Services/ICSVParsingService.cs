using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Services
{
    public interface ICSVParsingService
    {
        List<IndustryYearIndexDto> ParseCSV();
    }
}
