using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomCovid19.Models;

namespace DiplomCovid19.Controllers
{
    public class VaccinationController : Controller
    {
        public EmployeeContext context;

        public VaccinationController(EmployeeContext ctx) => context = ctx;
        public IActionResult VaccinationCourses(Employee employee)
        {
            IEnumerable<EmployeeVaccineJunction> data = 
                context.EmployeeVaccineJunctions.Where(e => e.EmployeeId == employee.Id).ToList();
            ViewBag.FIO = employee.FIO;
            ViewBag.EmployeeId = employee.Id;
            return View("Vaccination", data);
        }

        //public IActionResult AddNewCourse(Employee employee)
        //{

        //}
    }
}
