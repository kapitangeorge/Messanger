using Messanger.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messanger.Data.Interfaces
{
    public interface IAllChats
    {
        public void CreateChat(Chat chat);
    }
}
