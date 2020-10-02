 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Messanger.Data.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} обязательно для заполнения.")]
        [Display(Name = "Почтовый адрес")]
        [StringLength(30,MinimumLength = 1)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} обязательно для заполнения.")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 1)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name="Запомнить меня?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
