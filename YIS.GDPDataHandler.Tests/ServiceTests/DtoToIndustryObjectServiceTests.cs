using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YIS.GDPDataHandler.Services;
using YIS.GDPDataHandler.Tests.Mocks;
using System.Linq;
using Yarly_s_Inside_Solutions.Models;
using System.Collections.Generic;
using YIS.GDPDataHandler.Db;

namespace YIS.GDPDataHandler.Tests.ServiceTests
{
    [TestClass]
    public class DtoToIndustryObjectServiceTests
    {
        [TestMethod]
        public void ParseIndustryDtoToModelObject_ReturnsListOfTypeSector_GivenValidData()
        {
            var _dtoIndustryService = new DtoToIndustryObjectService();
            var repo = IndustryGDPDataRepository.GetSectorGDPData();
            var list = repo.GetAll().ToList();
            var result = _dtoIndustryService.ParseIndustryDtoToModelObject(list);
            Assert.AreEqual(result, typeof(List<IndustryAnnualGDP>));
        }
        
    }
}
