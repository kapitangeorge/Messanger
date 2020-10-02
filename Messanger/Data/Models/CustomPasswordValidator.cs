﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Messanger.Data.Models
{
    public class CustomPasswordValidator : IPasswordValidator<ApplicationUser>
    {
        public int RequiredLength { get; set; }

        public CustomPasswordValidator(int length)
        {
            RequiredLength = length;
        }
        public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();
            if (String.IsNullOrEmpty(password) || password.Length < RequiredLength)
            {
                errors.Add(new IdentityError
                {
                    Description = $"Минимальная длина пароля равна {RequiredLength}"
                });
            }
            string pattern = "^[0-9a-z]+$";

            if (!Regex.IsMatch(password, pattern))
            {
                errors.Add(new IdentityError
                {
                    Description = "Пароль должен состоять только из цифр или букв английского алфавита в нижнем регистре"
                });
            }
            return Task.FromResult(errors.Count == 0 ?
                IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
