using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DiplomCovid19.Models
{
    public class Subdivision
    {
        public int Id { get; set; }

        [Display(Name = "Подразделение")]
        public string SubdivisionName { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
