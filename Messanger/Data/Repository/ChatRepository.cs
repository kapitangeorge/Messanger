using Messanger.Data.Interfaces;
using Messanger.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messanger.Data.Repository
{
    public class ChatRepository :IAllChats
    {
        private readonly AppDBContext appDBContext;
       

        public ChatRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public void CreateChat(Chat chat)
        {
            appDBContext.Chats.Add(chat);
            appDBContext.SaveChanges();
        }
    }
}
