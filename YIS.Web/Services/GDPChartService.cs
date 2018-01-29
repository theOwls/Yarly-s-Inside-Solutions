using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YIS.GDPDataHandler.Data.Infrastructure;
using YIS.GDPDataHandler.Db;

namespace YIS.Web.Services
{
    public class GDPChartService : IGDPChartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GDPChartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public object GetChartModel()
        {
            var chartModel = _unitOfWork.GetRepository<IndustryAnnualGDP>();
            return chartModel.GetAll().FirstOrDefault();
        }
    }
}