using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YIS.GDPDataHandler.Db
{
    public class IndustryAnnualGDP
    {
        [Key]
        public Guid Id { get; set; }
        public string DateCode { get; set; }
        public string Value { get; set; }
        public string Sector { get; set; }
    }
}
