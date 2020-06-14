using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    public class TenantUnit
    {
        public int TenantID { get; set; }
        public int UnitID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime MovedInDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime MovedOutDate { get; set; }
        public decimal Rent { get; set; }
        public Tenant tenant { get; set; }
        public Unit unit { get; set; }
    }
}
