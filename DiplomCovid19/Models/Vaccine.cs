using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomCovid19.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string VaccineName { get; set; }
        public IEnumerable<EmployeeVaccineJunction> EmployeeVaccines { get; set; }
    }
}
