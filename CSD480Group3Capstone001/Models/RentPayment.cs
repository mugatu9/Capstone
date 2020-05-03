using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    //For Nathan: REMEMBER TO SPECIFY COMPOSITE KEYS IN DB CONTEXT (PK: TenatID, UnitID, Date)
    public class RentPayment
    {
        public int TenantID { get; set; }
        public int UnitID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public Tenant tenant { get; set; }
        public Unit unit { get; set; }
    }
}
