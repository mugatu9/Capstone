using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int TaxParcelYear { get; set; }

        [Column(TypeName = "money")]
        public decimal TaxParcelAmount { get; set; }
        public ICollection<Unit> Units { get; set; }


        
    }
}
