using Messanger.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messanger.Data
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync (UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "goshankap@gmail.com";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                ApplicationUser user = new ApplicationUser { Email = adminEmail, FirstName = "Георгий", LastName = "Титов", Town = "Озерск", UserName = adminEmail, Year = 1999 };
                IdentityResult result = await userManager.CreateAsync(user, "glatorian99");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "admin");
                }
            }
        }
    }
}
