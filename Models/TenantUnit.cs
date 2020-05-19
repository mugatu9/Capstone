using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    public class TenantUnit
    {
        public int TenantID { get; set; }
        public int UnitID { get; set; }
        public Tenant tenant { get; set; }
        public Unit unit { get; set; }
    }
}
