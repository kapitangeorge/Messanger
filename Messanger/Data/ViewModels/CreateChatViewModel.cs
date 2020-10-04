using Messanger.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Messanger.Data.ViewModels
{
    public class CreateChatViewModel
    {
        [Required(ErrorMessage = "{0} обязательно для заполнения.")]
        [StringLength(30, ErrorMessage = "{0} не может быть короче {2} и длиннее {1} символов.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        public List<string> Members { get; set; }

        public string UserName { get; set; }

    }
}
