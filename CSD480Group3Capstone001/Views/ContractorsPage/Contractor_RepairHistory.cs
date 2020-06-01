using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSD480Group3Capstone001.Data;
using CSD480Group3Capstone001.Models;

namespace CSD480Group3Capstone001.Views.ContractorsPage
{
    public class Contractor_RepairHistory
    {
        public ICollection<Contractor> Contractors { get; set; }
        public ICollection<RepairHistory> RepairHistory { get; set; }
    }
}
