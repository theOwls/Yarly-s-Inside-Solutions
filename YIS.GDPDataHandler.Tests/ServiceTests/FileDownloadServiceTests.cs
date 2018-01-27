using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YIS.GDPDataHandler.Services;

namespace YIS.GDPDataHandler.Tests.FileDownloadServiceTests
{
    [TestClass]
    public class FileDownloadServiceTests
    {
        IFileDownloadService _downloaderService;
        [TestMethod]
        public void DownloadCSV_ReturnsTrue_GivenSuccessfulDownload()
        {
            _downloaderService = new FileDownloadService();
            var result = _downloaderService.DownloadCSV();
            Assert.IsTrue(result);
        }
    }
}
