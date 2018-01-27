using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace YIS.GDPDataHandler.Services
{
    public class FileDownloadService : IFileDownloadService
    {
        public bool DownloadCSV()
        {
            //WebClient Client = new WebClient();
            //Stream dataStream = Client.OpenRead("http://statistics.gov.scot/data/gross-domestic-product-annual-output-by-industry");
            //StreamReader reader = new StreamReader(dataStream);

            ////tomorrow - streamwriter method? 
            //using (var streamWriter = new StreamWriter("D:\\docs\\YIS\\YIS.txt"))
            //{
            //    reader.ReadLine();
            //    while (!reader.EndOfStream)
            //    {
            //        var line = reader.ReadLine();
            //        streamWriter.WriteLine(line);
            //    }
            //}
            //dataStream.Close();
            ////Client.DownloadFile("http://statistics.gov.scot/data/gross-domestic-product-annual-output-by-industry", "http://statistics.gov.scot/downloads/cube-table?");


            var fileDownloaded = true;
            return fileDownloaded;
        }
    }
}
