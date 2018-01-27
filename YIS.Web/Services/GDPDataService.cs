using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YIS.GDPDataHandler.Data.Infrastructure;
using YIS.GDPDataHandler.Db;

namespace YIS.Web.Services
{
    public class GDPDataService : IGDPDataService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GDPDataService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<IndustryAnnualGDP> GenerateData()
        {
            var _industryData = _unitOfWork.GetRepository<IndustryAnnualGDP>();
            return _industryData.GetAll().ToList();
        }
    }
}