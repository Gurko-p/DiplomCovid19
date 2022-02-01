using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DiplomCovid19.Models
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> Employees { get; }
        Employee Get(long id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee, Employee employeeOriginal = null);
        void DeleteEmployee(Employee employee);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeContext context;
        public EmployeeRepository(EmployeeContext ctx) => context = ctx;
        public IQueryable<Employee> Employees => context.Employees;

        public Employee Get(long id) => context.Employees.Find(id);

        public void AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee, Employee employeeOriginal = null)
        {
            if(employeeOriginal == null)
            {
                employeeOriginal = context.Employees.Find(employee.Id);
            }
            else
            {
                context.Employees.Attach(employeeOriginal);
            }
            employeeOriginal.Id = employee.Id;
            employeeOriginal.FIO = employee.FIO;
            employeeOriginal.SubdivisionId = employee.SubdivisionId;
            employeeOriginal.RankId = employee.RankId;
            employeeOriginal.PositionId = employee.PositionId;
            
            context.SaveChanges();
        }
        public void DeleteEmployee(Employee employee)
        {
            context.Employees.Remove(employee);
            context.SaveChanges();
        }
    }
}
