using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarly_s_Inside_Solutions.Models;

namespace YIS.GDPDataHandler.Tests.Mocks
{
    public class IndustryGDPDataRepository
    {
        public static MockRepository<IndustryYearIndexDto> GetIndustrySectorGDPData()
        {
            var repo = new MockRepository<IndustryYearIndexDto>();
            repo.Add(new IndustryYearIndexDto
            {
                DateCode = "1/2/2018",
                IndustrySector = "Agriculture",
                Value = "112"
            });
            repo.Add(new IndustryYearIndexDto
            {
                DateCode = "1/2/2018",
                IndustrySector = "Agriculture",
                Value = "113"
            });
            return repo;
        }

    }
}
