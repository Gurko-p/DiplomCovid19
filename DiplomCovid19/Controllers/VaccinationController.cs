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
        public IActionResult VaccinationCourses(Employee employee)
        {
            IEnumerable<EmployeeVaccineJunction> data = 
                context.EmployeeVaccineJunctions.Include(v => v.Vaccine).Where(e => e.EmployeeId == employee.Id).ToList();
                ViewBag.Employee = context.Employees.Find(employee.Id);
            return View("Vaccination", data);
        }

        public IActionResult CreateNewCourse(long key)
        {
            ViewBag.Employee = context.Employees.Find(key);
            ViewBag.Vaccines = context.Set<Vaccine>();
            return View("Create", new EmployeeVaccineJunction { EmployeeId = key });
        }

        [HttpPost]
        public IActionResult CreateNewCourse(EmployeeVaccineJunction evj)
        {
            context.EmployeeVaccineJunctions.Add(evj);
            context.SaveChanges();
            if (evj.VaccineId > 0)
            {
                return RedirectToAction(nameof(VaccinationCourses), new Employee { Id = Convert.ToInt64(evj.EmployeeId) });
            }
            return Redirect("~/Home/Index");
        }
    }
}
