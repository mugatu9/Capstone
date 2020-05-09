using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    public class User
    {
        public string OwnerID { get; set; }
        public string Email { get; set; }

        public ContactStatus Status { get; set; }

    }
    public enum ContactStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
