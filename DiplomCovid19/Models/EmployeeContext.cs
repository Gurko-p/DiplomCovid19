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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rank>().HasData(
                new Rank[]
                {
                new Rank { Id=1, RankName="рядовой милиции"},
                new Rank { Id=2, RankName="младший сержант милиции"},
                new Rank { Id=3, RankName="сержант милиции"},
                new Rank { Id=4, RankName="старший сержант милиции"},
                new Rank { Id=5, RankName="старшина милиции"},
                new Rank { Id=6, RankName="лейтенант милиции"},
                new Rank { Id=7, RankName="старший лейтенант милиции"},
                new Rank { Id=8, RankName="капитан милиции"},
                new Rank { Id=9, RankName="майор милиции"},
                new Rank { Id=10, RankName="подполковник милиции"},
                new Rank { Id=11, RankName="полковник милиции"}
                });

            modelBuilder.Entity<Position>().HasData(
                new Position[]
                {
                    new Position{ Id = 1, PositionName = "начальник академии" },
                    new Position{ Id = 2, PositionName = "заместитель начальника академии" },
                    new Position{ Id = 3, PositionName = "начальник курса" },
                    new Position{ Id = 4, PositionName = "заместитель начальника курса" },
                    new Position{ Id = 5, PositionName = "начальник кафедры" },
                    new Position{ Id = 6, PositionName = "заместитель начальника кафедры" },
                    new Position{ Id = 7, PositionName = "преподаватель" },
                    new Position{ Id = 8, PositionName = "преподаватель-методист" },
                    new Position{ Id = 9, PositionName = "старший преподаватель" },
                    new Position{ Id = 10, PositionName = "старший преподаватель-методист" },
                    new Position{ Id = 11, PositionName = "старший инспектор" },
                    new Position{ Id = 12, PositionName = "старший инспектор по особым поручениям" },
                    new Position{ Id = 13, PositionName = "доцент" },
                    new Position{ Id = 14, PositionName = "профессор" },
                    new Position{ Id = 15, PositionName = "курсант" }
                });
            modelBuilder.Entity<Subdivision>().HasData(
                new Subdivision[]
                {
                    new Subdivision{ Id = 1, SubdivisionName = "отдел кадров"},
                    new Subdivision{ Id = 2, SubdivisionName = "отдел образовательных информационных технологий"},
                    new Subdivision{ Id = 3, SubdivisionName = "учебно-методическое управление"}
                });

            modelBuilder.Entity<Vaccine>().HasData(
                new Vaccine[]
                {
                    new Vaccine { Id = 1, VaccineName = "Спутник V - Росия"},
                    new Vaccine { Id = 2, VaccineName = "SARS-CoV-2 - Китай"},
                    new Vaccine { Id = 3, VaccineName = "Спутник Лайт - Росия"}
                }
                );
            modelBuilder.Entity<Employee>().HasData(
                    new Employee[]
                    {
                        new Employee{ Id = 1, FIO = "Гурко Павел Михайлович", SubdivisionId = 2, PositionId = 8, RankId = 9 },
                        new Employee{ Id = 2, FIO = "Левенко Евгений Юрьевич", SubdivisionId = 2, PositionId = 10, RankId = 10 },
                        new Employee{ Id = 3, FIO = "Гуркский Вадим Михайлович", SubdivisionId = 2, PositionId = 10, RankId = 10 },
                        new Employee{ Id = 4, FIO = "Гейц Людмила Николаевна", SubdivisionId = 1, PositionId = 11, RankId = 8 },
                        new Employee{ Id = 5, FIO = "Костян Елена Григорьевна", SubdivisionId = 1, PositionId = 11, RankId = 8 },
                        new Employee{ Id = 6, FIO = "Бедункевич Марина Александровна", SubdivisionId = 1, PositionId = 12, RankId = 10 },
                        new Employee{ Id = 7, FIO = "Райкова Екатерина Александровна", SubdivisionId = 3, PositionId = 10, RankId = 10 }
                    });

            modelBuilder.Entity<EmployeeVaccineJunction>()
                .HasOne(e => e.Employee)
                .WithMany(e => e.EmployeeVaccines)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
