using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DiplomCovid19.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<EmployeeVaccineJunction> EmployeeVaccineJunctions { get; set; }
    }
}
