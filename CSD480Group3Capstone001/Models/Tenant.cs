using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    public class Tenant
    {
        public int TenantID { get; set; }
        public String PhoneNumber { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Employment { get; set; }
        public decimal? Salary { get; set; }
        public ICollection<Infraction> Infractions { get; set; }
        public ICollection<TenantUnit> TenantUnits { get; set; }
        public ICollection<RentPayment> RentPayments { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }


    }
}
