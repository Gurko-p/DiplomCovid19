using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiplomCovid19.Models;
using DiplomCovid19.Components;
using DiplomCovid19.Models.ViewModels;

namespace DiplomCovid19.Components
{
    public class VaccinationStatistic : ViewComponent
    {
        private EmployeeContext context;
        public VaccinationStatistic(EmployeeContext ctx) => context = ctx;
        public IViewComponentResult Invoke()
        {
            long countEmployees = context.Employees.ToList().Count();
            long fullCourseOfVaccinationCount = context.EmployeeVaccineJunctions.Where(e => e.DateSecondComponent != null).Distinct().ToList().Count();
            double fullCourseOfVaccinationPercent = Math.Round((Convert.ToDouble(fullCourseOfVaccinationCount) / countEmployees * 100), 2);
            long vaccinatedFirstComponentCount = context.EmployeeVaccineJunctions.Where(e => e.DateFirstComponent != null).Distinct().ToList().Count();
            double vaccinatedFirstComponentPercent = Math.Round((Convert.ToDouble(vaccinatedFirstComponentCount) / countEmployees * 100),  2);

            return View("Statistics", new EmployeeViewModel { 
                CountEmployees = countEmployees, 
                FullCourseOfVaccinationCount = fullCourseOfVaccinationCount,
                FullCourseOfVaccinationPercent = fullCourseOfVaccinationPercent,
                VaccinatedFirstComponentCount = vaccinatedFirstComponentCount,
                VaccinatedFirstComponentPercent = vaccinatedFirstComponentPercent
            });
        }
    }
}
