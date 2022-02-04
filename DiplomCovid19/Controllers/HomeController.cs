using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomCovid19.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DiplomCovid19.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository repository;
        private EmployeeContext context;
        public HomeController(IEmployeeRepository repo, EmployeeContext ctx)
        {
            repository = repo;
            context = ctx;
        }
        [Authorize]
        public IActionResult Index()
        {
            IQueryable<Employee> employees = repository.Employees
                .Include(e => e.Subdivision)
                .Include(e => e.Rank)
                .Include(e => e.Position)
                .OrderBy(e => e.FIO);
            return View(employees.ToList());
        }


        //[Authorize]
        //public IActionResult Index() => View(GetData(nameof(Index)));

        //[Authorize(Roles = "Users")]
        //public IActionResult OtherAction() => View("Index",
        //    GetData(nameof(OtherAction)));

        //private Dictionary<string, object> GetData(string actionName) =>
        //    new Dictionary<string, object>
        //    {
        //        ["Action"] = actionName,
        //        ["User"] = HttpContext.User.Identity.Name,
        //        ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
        //        ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
        //        ["In Users Role"] = HttpContext.User.IsInRole("Users")
        //    };

        public IActionResult UpdateEmployee(long key)
        {
            ViewBag.Subdivisions = context.Subdivisions;
            ViewBag.Ranks = context.Ranks;
            ViewBag.Positions = context.Positions;
            return View(key == 0 ? new Employee() : repository.Get(key));
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee, Employee employeeOriginal = null)
        {
            if (employee.Id == 0)
            {
                repository.AddEmployee(employee);
            }
            else
            {
                repository.UpdateEmployee(employee, employeeOriginal);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteEmployee(long id)
        {
            repository.DeleteEmployee(new Employee { Id = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
