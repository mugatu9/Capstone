using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    public class Infraction
    {
        public int InfractionID { get; set; }
        public int TenantID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public String Reason { get; set; }
        public decimal Amount { get; set; }
        public bool Paid { get; set; }
        public Tenant Tenant { get; set; }
    }
}
