﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomCovid19.Models
{
    public class EmployeeVaccineJunction
    {
        public long Id { get; set; }
        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int? VaccineId { get; set; }
        public Vaccine Vaccine { get; set; }

        [Display(Name = "Дата получения первого компонента")]
        [DataType(DataType.Date)]
        public DateTime? DateFirstComponent { get; set; }

        [Display(Name = "Дата получения второго компонента")]
        [DataType(DataType.Date)]
        public DateTime? DateSecondComponent { get; set; }
    }
}
