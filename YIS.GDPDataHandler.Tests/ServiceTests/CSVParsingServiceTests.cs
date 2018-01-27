using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YIS.GDPDataHandler.Services;
using System.Collections.Generic;

namespace YIS.GDPDataHandler.Tests.ServiceTests
{
	[TestClass]
	public class CSVParsingServiceTests
	{
        ICSVParsingService _csvParser;

		[TestMethod]
		public void ParseCSV_ReturnsTrue_GivenSuccessfulRead()
		{
            _csvParser = new CSVParsingService();
            var result = _csvParser.ParseCSV();
            Assert.IsInstanceOfType(result, typeof(List<IndustryYearIndexDto>));
		}
	}
}
