using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomCovid19.Models
{
    public class EmployeeVaccineJunction
    {
        public long Id { get; set; }
        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int? VaccineId { get; set; }
        public Vaccine Vaccine { get; set; }
        public DateTime? DateFirstComponent { get; set; }
        public DateTime? DateSecondComponent { get; set; }
    }
}
