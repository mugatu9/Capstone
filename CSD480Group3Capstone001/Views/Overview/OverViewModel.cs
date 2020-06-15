using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSD480Group3Capstone001.Controllers;
using CSD480Group3Capstone001.Models;

namespace CSD480Group3Capstone001.Views.Overview
{
    public class OverViewModel
    {
        public ICollection<Building> Buildings { get; set; }
        public ICollection<Tenant> Tenants { get; set; }
        public ICollection<Unit> Units { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<RentPayment> RentPayments { get; set; }

        public ICollection<Infraction> Infractions { get; set; }
    }
}
