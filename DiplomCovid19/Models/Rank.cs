using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DiplomCovid19.Models
{
    public class Rank
    {
        public int Id { get; set; }

        [Display(Name = "Звание")]
        public string RankName { get; set; }
    }
}
