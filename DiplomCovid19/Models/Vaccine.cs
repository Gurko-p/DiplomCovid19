using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DiplomCovid19.Models
{
    public class Vaccine
    {
        public int Id { get; set; }

        [Display(Name = "Название вакцины")]
        public string VaccineName { get; set; }
        public IEnumerable<EmployeeVaccineJunction> EmployeeVaccines { get; set; }
    }
}
