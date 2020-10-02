using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messanger.Data.Models
{
    public class ApplicationUser : IdentityUser
    {

        public int Year { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Town { get; set; }

        public string Img { get; set; }
    }

}
