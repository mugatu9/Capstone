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
        public int RentPaymentID { get; set; }
        public int TenantID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public Tenant tenant { get; set; }
        
    }
}
