using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public int TenantID { get; set; }
        public String LicensePlate { get; set; }
        public String Model { get; set; }
        public String Make { get; set; }
        public int Year { get; set; }
        public String Color { get; set; }
        public Tenant Tenant { get; set; }
    }
}
