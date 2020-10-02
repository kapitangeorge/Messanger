using Messanger.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messanger.Data.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }

    }
}
