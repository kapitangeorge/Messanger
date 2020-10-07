using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messanger.Data.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }

        public int ChatId { get; set; }

        public string TextMessage { get; set; }

        public string Author { get; set; }

        public DateTime PostDate { get; set; }
    }
}
