using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    public class Building
    {
        public int BuildingID { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public int Zip { get; set; }
        public String? OrgName { get; set; }
        public ICollection<TaxParcel> TaxParcels { get; set; }
        public ICollection<Unit> Units { get; set; }


        
    }
}
