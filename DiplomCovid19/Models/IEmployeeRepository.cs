using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomCovid19.Models
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> Employees { get; }
        Employee Get(long id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
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

        public void UpdateEmployee(Employee employee)
        {
            context.Employees.Update(employee);
            context.SaveChanges();
        }
        public void DeleteEmployee(Employee employee)
        {
            context.Employees.Remove(employee);
            context.SaveChanges();
        }
    }
}
