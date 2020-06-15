using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    public class Contractor
    {
        public int ContractorID { get; set; }
        public string PhoneNumber { get; set; }
        public String Company { get; set; }
        public String Specialty { get; set; }
        public ICollection<RepairHistory> RepairHistories { get; set; }
    }
}
