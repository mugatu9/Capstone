using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    public class UserTabViewModel
    {
        public Tab ActiveTab { get; set; }
    }

    public enum Tab
    {
        Building,
        Contractor,
        Tenant,
        Unit,
        Vehicle
    }
}
