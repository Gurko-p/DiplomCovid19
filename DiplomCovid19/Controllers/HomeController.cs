using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomCovid19.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using DiplomCovid19.Helpers;
using DiplomCovid19.Models.ViewModels;
using Newtonsoft.Json;

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
        //[Authorize]
        public IActionResult Index(string fio = null, int vaccineId = 0, bool got1comp = false, bool gotFullCourse = false)
        {
            ViewBag.Vaccines = context.Set<Vaccine>();
            string returnUrl = UrlExtensions.PathAndQuery(HttpContext.Request);
            HttpContext.Session.SetString("returnUrl", returnUrl);

            ViewBag.EmployeeFiterModel = new EmployeeFiterModel
            {
                FIO = fio,
                VaccineId = vaccineId,
                GotFirstComponent = got1comp,
                GotFullCourse = gotFullCourse
            };


            IEnumerable<Employee> employees = repository.Employees
                .Include(e => e.Subdivision)
                .Include(e => e.Rank)
                .Include(e => e.Position)
                .Where(e => e.FIO.Contains(fio ?? ""))
                .ToList();

            IEnumerable<Employee> empFiltered = null;
            if (got1comp != false && gotFullCourse == false)
            {
                IEnumerable<EmployeeVaccineJunction> empVacJunc = context.EmployeeVaccineJunctions.ToList();
                empFiltered = from emp in employees
                              join evj in empVacJunc on emp.Id equals evj.EmployeeId
                              where evj.DateFirstComponent.HasValue
                              select emp;
            }
            else if (gotFullCourse != false)
            {
                IEnumerable<EmployeeVaccineJunction> empVacJunc = context.EmployeeVaccineJunctions.ToList();
                empFiltered = from emp in employees
                              join evj in empVacJunc on emp.Id equals evj.EmployeeId
                              where evj.DateSecondComponent.HasValue
                              select emp;
            }
            else if (vaccineId != 0)
            {
                IEnumerable<EmployeeVaccineJunction> empVacJunc = context.EmployeeVaccineJunctions.ToList();
                empFiltered = from emp in employees
                              join evj in empVacJunc on emp.Id equals evj.EmployeeId
                              where evj.VaccineId == vaccineId
                              select emp;
            }
            else
            {
                empFiltered = employees;
            }

            return View(empFiltered?.Distinct().ToList());
        }



        public JsonResult filterEmployees(string fio = null)
        {
            var employees = context.Employees
                .Include(e => e.Subdivision)
                .Include(e => e.Rank)
                .Include(e => e.Position)
                .Where(e => e.FIO.Contains(fio ?? ""))
                    .Select(s => new
                    {
                        Id = s.Id,
                        FIO = s.FIO,
                        CountCourseVaccination = s.CountCourseVaccination,
                        Subdivision = new
                        {
                            SubdivisionName = s.Subdivision.SubdivisionName
                        },
                        Rank = new 
                        { 
                            RankName = s.Rank.RankName
                        },
                        Position = new
                        {
                            PositionName = s.Position.PositionName
                        }
                    });
            return Json(employees);
        }

        //[HttpPost]
        //[ActionName("Index")]
        //public IActionResult FilteredIndex(string fio = null, int vaccineId = 0, bool got1comp = false, bool gotFullCourse = false)
        //{
        //    ViewBag.Vaccines = context.Set<Vaccine>();

        //    string returnUrl = null;
        //    //string name = HttpContext.Request.Form["fio"];
        //    //string vacId = HttpContext.Request.Form["vaccineId"];
        //    //string g1c = HttpContext.Request.Form["got1comp"];
        //    //string gfc = HttpContext.Request.Form["gotFullCourse"];
        //    returnUrl = $"/Home/Index?fio={fio}&vaccineId={vaccineId}&got1comp={got1comp}&gotFullCourse={gotFullCourse}";
        //    Console.WriteLine(returnUrl);
        //    HttpContext.Session.SetString("returnUrl", returnUrl);
        //    ViewBag.ReturnUrl = HttpContext.Session.GetString("returnUrl");
        //    ViewBag.EmployeeFiterModel = new EmployeeFiterModel
        //    {
        //        FIO = fio,
        //        VaccineId = Convert.ToInt32(vaccineId),
        //        GotFirstComponent = Convert.ToBoolean(got1comp),
        //        GotFullCourse = Convert.ToBoolean(gotFullCourse)
        //    };

        //    IEnumerable<Employee> employees = repository.Employees
        //        .Include(e => e.Subdivision)
        //        .Include(e => e.Rank)
        //        .Include(e => e.Position)
        //        .Where(e => e.FIO.Contains(fio ?? ""))
        //        .ToList();

        //    IEnumerable<Employee> empFiltered = null;
        //    if (got1comp != false && gotFullCourse == false)
        //    {
        //        IEnumerable<EmployeeVaccineJunction> empVacJunc = context.EmployeeVaccineJunctions.ToList();
        //        empFiltered = from emp in employees
        //                      join evj in empVacJunc on emp.Id equals evj.EmployeeId
        //                      where evj.DateFirstComponent.HasValue
        //                      select emp;
        //    }
        //    else if (gotFullCourse != false)
        //    {
        //        IEnumerable<EmployeeVaccineJunction> empVacJunc = context.EmployeeVaccineJunctions.ToList();
        //        empFiltered = from emp in employees
        //                      join evj in empVacJunc on emp.Id equals evj.EmployeeId
        //                      where evj.DateSecondComponent.HasValue
        //                      select emp;
        //    }
        //    else if (vaccineId != 0)
        //    {
        //        IEnumerable<EmployeeVaccineJunction> empVacJunc = context.EmployeeVaccineJunctions.ToList();
        //        empFiltered = from emp in employees
        //                      join evj in empVacJunc on emp.Id equals evj.EmployeeId
        //                      where evj.VaccineId == vaccineId
        //                      select emp;
        //    }
        //    else
        //    {
        //        empFiltered = employees;
        //    }
        //    return View("IndexTablePartial", empFiltered?.Distinct().ToList());
        //}

        public IActionResult ClearFilters()
        {
            HttpContext.Session.Remove("returnUrl");
            return RedirectToAction("Index");
        }

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
