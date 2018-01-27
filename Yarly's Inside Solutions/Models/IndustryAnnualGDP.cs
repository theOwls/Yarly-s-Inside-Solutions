using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yarly_s_Inside_Solutions.Models
{
    public class IndustryAnnualGDP
    {
        public string Id = new Guid().ToString();
        public string DateCode { get; set; }
        public string Value { get; set; }
        public string IndustrySector { get; set; }
    }
}