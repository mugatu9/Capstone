using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    public class TaxParcel
    {
        public int tpID { get; set; }
        public int Year { get; set; }
        
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public ICollection<Building> Buildings { get; set; }
    }
}
