using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomCovid19.Models
{
    public class Employee
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Фамилия, имя, отчество - обязательное поле!")]
        [Display(Name = "Фамилия, имя, отчество")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Значение по умолчанию не допускается!")]
        public int? SubdivisionId { get; set; }
        public Subdivision Subdivision { get; set; }

        [Required(ErrorMessage = "Значение по умолчанию не допускается!")]
        public int? RankId { get; set; }
        public Rank Rank { get; set; }

        [Required(ErrorMessage = "Значение по умолчанию не допускается!")]
        public int? PositionId { get; set; }
        public Position Position { get; set; }

        public long CountCourseVaccination { get; set; } = 0;
        public IEnumerable<EmployeeVaccineJunction> EmployeeVaccines { get; set; }

    }
}
