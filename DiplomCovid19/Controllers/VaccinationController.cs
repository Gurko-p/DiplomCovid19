using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomCovid19.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using Flurl;

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

        [HttpPost]
        public IActionResult DeleteEmployeeVaccineJunction(EmployeeVaccineJunction evj)
        {
            context.EmployeeVaccineJunctions.Remove(evj);
            context.SaveChanges();
            return RedirectToAction(nameof(VaccinationCourses), new Employee { Id = Convert.ToInt64(evj.EmployeeId) });
        }
    
        public IActionResult UpdateEmployeeVaccineJunction(long id, long EmployeeId = 0)
        {
            if (EmployeeId != 0)
            {
                ViewBag.Employee = context.Employees.Find(EmployeeId);
            }
            ViewBag.Vaccines = context.Set<Vaccine>();
            return View("UpdateVaccination", id == 0 ? new EmployeeVaccineJunction { EmployeeId = EmployeeId } : context.EmployeeVaccineJunctions.Find(id));
        }
        [HttpPost]
        public IActionResult UpdateEmployeeVaccineJunction(EmployeeVaccineJunction evj)
        {
            if (evj.Id == 0)
            {
                context.EmployeeVaccineJunctions.Add(evj);
                context.SaveChanges();
            }
            else
            {
                context.EmployeeVaccineJunctions.Update(evj);
                context.SaveChanges();
            }
            return RedirectToAction(nameof(VaccinationCourses), new Employee { Id = Convert.ToInt64(evj.EmployeeId) });
        }

        public IActionResult BackToHomeIndex(string returnUrl)
        {
            return Redirect("~/Home/Index?fio=Левенко&vaccineId=0&got1comp=True&gotFullCourse=False");
        }
    }
}
