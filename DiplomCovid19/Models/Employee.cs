using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomCovid19.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string FIO { get; set; }

        public int? SubdivisionId { get; set; }
        public Subdivision Subdivision { get; set; }
        public int? RankId { get; set; }
        public Rank Rank { get; set; }

        public int? PositionId { get; set; }
        public Position Position { get; set; }
        public IEnumerable<EmployeeVaccineJunction> EmployeeVaccines { get; set; }

    }
}
