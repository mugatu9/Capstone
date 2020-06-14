using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    //For Nathan: REMEMBER TO SPECIFY COMPOSITE KEYS IN DB CONTEXT (PK: ContractorID, UnitID, StartDate)
    public class RepairHistory
    {
        public int RepairHistoryID { get; set; }
        public int ContractorID { get; set; }
        public int? UnitID { get; set; }
        public int? BuidlingID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FinishDate { get; set; }
        public String Notes { get; set; }
        public decimal Cost { get; set; }
        public bool Paid { get; set; }
        public Building Building { get; set; }
        public Unit Unit { get; set; }
        public Contractor Contractor { get; set; }
    }

}