using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomCovid19.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomCovid19.Controllers
{
    public class VaccinationController : Controller
    {
        public EmployeeContext context;

        public VaccinationController(EmployeeContext ctx) => context = ctx;
        public IActionResult VaccinationCourses(long id)
        {
            IEnumerable<EmployeeVaccineJunction> data = 
                context.EmployeeVaccineJunctions.Include(v => v.Vaccine).Where(e => e.EmployeeId == id).ToList();
                ViewBag.Employee = context.Employees.Find(id);
            return View("Vaccination", data);
        }

        public IActionResult CreateNewCourse(Employee emp)
        {
            ViewBag.Employee = context.Employees.Find(emp.Id);
            ViewBag.Vaccines = context.Set<Vaccine>();
            return View("Create", new EmployeeVaccineJunction { EmployeeId = emp.Id });
        }

        [HttpPost]
        public IActionResult CreateNewCourse(EmployeeVaccineJunction evj)
        {
            context.EmployeeVaccineJunctions.Add(evj);
            context.SaveChanges();
            return RedirectToAction(nameof(VaccinationCourses), new Employee { Id = Convert.ToInt64(evj.EmployeeId) });
        }

        [HttpPost]
        public IActionResult DeleteEmployeeVaccineJunction(EmployeeVaccineJunction evj)
        {
            context.EmployeeVaccineJunctions.Remove(evj);
            context.SaveChanges();
            return RedirectToAction(nameof(VaccinationCourses), new Employee { Id = Convert.ToInt64(evj.EmployeeId) });
        }
    
        public IActionResult UpdateEmployeeVaccineJunction(long id)
        {
            return View("Update");
        }
        [HttpPost]
        public IActionResult UpdateEmployeeVaccineJunction(EmployeeVaccineJunction evj)
        {
            context.EmployeeVaccineJunctions.Add(evj);
            context.SaveChanges();
            return RedirectToAction(nameof(VaccinationCourses), new Employee { Id = Convert.ToInt64(evj.EmployeeId) });
        }

    }
}
