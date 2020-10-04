using Messanger.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messanger.Data.ViewModels
{
    public class ChatMessagesViewModel
    {
        public int ChatId { get; set; }

        public string TextMessage { get; set; }

        public string UserName { get; set; }

        public List<ChatMessage> ChatMessages { get; set; }
    }
}
