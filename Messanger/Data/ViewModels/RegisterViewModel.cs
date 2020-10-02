using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Messanger.Data.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} обязательно для заполнения.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Почтовый адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} обязательно для заполнения.")]
        [Display(Name = "Год рождения")]
        public int Year { get; set; }

        [Required(ErrorMessage = "{0} обязательно для заполнения.")]
        [DataType(DataType.Password)]
        [StringLength(100,ErrorMessage = "Поле {0} должно иметь минимум {2} и масксимум {1} символов", MinimumLength = 5)]
        [Display(Name = "Пароль" )]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} обязательно для заполнения.")]
        [Compare ("Password", ErrorMessage="Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name="Подтвердить пароль")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "{0} обязательно для заполнения.")]
        [StringLength(30, ErrorMessage = "{0} не может быть короче {2} и длиннее {1} символов.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name="Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} обязательно для заполнения.")]
        [StringLength(30, ErrorMessage = "{0} не может быть короче {2} и длиннее {1} символов.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display (Name="Фамилия")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "{0} обязательно для заполнения.")]
        [StringLength(30, ErrorMessage = "{0} не может быть короче {2} и длиннее {1} символов.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Город")]
        public string Town { get; set; }
    }
}
