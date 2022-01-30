using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
}
