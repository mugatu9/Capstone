using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    //For Nathan: REMEMBER TO SPECIFY COMPOSITE KEYS IN DB CONTEXT (PK: TenatID, UnitID, StartDate)
    public class RentPayment
    {
        public int TenatID { get; set; }
        public int UnitID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public ICollection<Tenant> Tenants { get; set; }
        public ICollection<Unit> Units { get; set; }
    }
}
