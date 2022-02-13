using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DiplomCovid19.Models
{

    public class CreateModel
    {
        [Display(Name="Имя пользователя")]
        [Required(ErrorMessage = "Пожалуйста, введите имя!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите email!")]
        [RegularExpression("^[-a-z0-9!#$%&'*+/=?^_`{|}~]+(\\.[-a-z0-9!#$%&'*+/=?^_`{|}~]+)*@([a-z0-9]([-a-z0-9]{0,61}[a-z0-9])?\\.)*(aero|arpa|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|[a-z][a-z])$", ErrorMessage = "Невалидный email")]
        public string Email { get; set; }
        [Display(Name = "Пароль")]
        [UIHint("Password")]
        [Required(ErrorMessage = "Пожалуйста, введите пароль!")]
        public string Password { get; set; }
    }
    public class LoginModel
    {
        [Required(ErrorMessage = "Пожалуйста, введите email!")]
        [UIHint("email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите пароль!")]
        [UIHint("password")]
        public string Password { get; set; }
    }

    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }
    }

    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}
