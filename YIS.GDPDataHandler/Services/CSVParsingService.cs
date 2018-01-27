using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Services
{
    public class CSVParsingService: ICSVParsingService
    {
        const char DataDelimeter = ',';
        public List<IndustryYearIndexDto> ParseCSV()
        {
            List<IndustryYearIndexDto> industryIndexList = new List<IndustryYearIndexDto>();
             
            using (var reader = new StreamReader("C:\\Users\\LSP\\Documents\\Projects\\Yarly's Inside Solutions\\ScotGDPData.csv"))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] lineData = line.Split(DataDelimeter);
                    var dateValue = ReadDataLine(lineData[1]);
                    IndustryYearIndexDto industryIndexDto = GetLineDataDto(lineData);
                    industryIndexList.Add(industryIndexDto);                    
                }
            }
            return industryIndexList;
        }

        private string ReadDataLine(string lineData)
        {
            return lineData.Trim();
        }

        private IndustryYearIndexDto GetLineDataDto (string[] lineData)
        {
            return new IndustryYearIndexDto
            {
                DateCode = ReadDataLine(lineData[1]),
                Value = ReadDataLine(lineData[4]),
                Sector = ReadDataLine(lineData[5])
            };
        }

    }
}
