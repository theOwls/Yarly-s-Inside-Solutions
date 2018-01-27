using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YIS.GDPDataHandler.Db;

namespace YIS.Web.Services
{
    public interface IGDPDataService
    {
        List<IndustryAnnualGDP> GenerateData();
    }
}