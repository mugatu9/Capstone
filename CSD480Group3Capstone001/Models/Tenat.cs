using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD480Group3Capstone001.Models
{
    public class Tenat
    {
        public int TenatID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String? Employer { get; set; }
        public decimal? Salary { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime MovedInDate { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? MovedOutDate { get; set; }
        public ICollection<Infraction> Infractions { get; set; }
        public ICollection<RentPayment> RentPayments { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }


    }
}
