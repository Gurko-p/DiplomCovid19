using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomCovid19.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomCovid19.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeContext context;
        public HomeController(EmployeeContext ctx) => context = ctx;
        public IActionResult Index()
        {
            IQueryable<Employee> employees = context.Employees
                .Include(e => e.Subdivision)
                .Include(e => e.Rank)
                .Include(e => e.Position);
            return View(employees.ToList());
        }
    }
}
