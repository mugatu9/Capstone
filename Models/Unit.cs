using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    
    public class Unit
    {
        public int UnitID { get; set; }
        public int BuildingID { get; set; }
        public String UnitNumber { get; set; }
        public int SqrFootage { get; set; }
        public Building Building { get; set; }
        public ICollection<RepairHistory> RepairHistories { get; set; }
        public ICollection<TenantUnit> TenantUnits { get; set; }

    }
}
