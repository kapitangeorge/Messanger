using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messanger.Data.Models
{
    public class Chat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Creator { get; set; }
        
        public List<ApplicationUser>  Members { get; set; }
    }
}
