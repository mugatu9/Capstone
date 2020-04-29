using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    public class Building
    {
        public int buildingID { get; set; }
        public int? tpID { get; set; }
        public String Address { get; set; }
        public String? OrgName { get; set; }
        public TaxParcel TaxParcel { get; set; }
        public ICollection<Unit> Units { get; set; }



    }
}
