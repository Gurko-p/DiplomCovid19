using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DiplomCovid19.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public long CountEmployees { get; set; }
        public long FullCourseOfVaccinationCount { get; set; }
        public double FullCourseOfVaccinationPercent { get; set; }
        public long VaccinatedFirstComponentCount { get; set; }
        public double VaccinatedFirstComponentPercent { get; set; }
    }

    public class EmployeeFiterModel
    {
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 30 символов")]
        public string FIO { get; set; }
        public int VaccineId { get; set; }
        public bool? GotFirstComponent { get; set; }
        public bool? GotFullCourse { get; set; }
        public int Flag { get; set; }
    }

    public class IndexViewModel
    {
        public EmployeeFiterModel FiterModel { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
