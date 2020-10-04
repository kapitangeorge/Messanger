using Messanger.Data;
using Messanger.Data.Interfaces;
using Messanger.Data.Models;
using Messanger.Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messanger.Controllers
{
    public class ChatController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private AppDBContext _appDBContext;
        private IAllChats chats;

        public ChatController(UserManager<ApplicationUser> userManager, AppDBContext appDBContext, IAllChats chats)
        {
            _userManager = userManager;
            _appDBContext = appDBContext;
            this.chats = chats;
        }
       
        public async Task<IActionResult> Chats(string userName)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(userName);
            List<Chat> chats = new List<Chat>();
            if (user.ChatId == null)
            {
                return View();
            }

            foreach (var chat in user.ChatId)
            {
                chats.Add(await _appDBContext.Chats.FirstOrDefaultAsync(c => c.Id == chat));
            }

            if (chats == null)
            {
                return View();
            }
            else
            {
                return View(chats);
            }
            
            
        }

        public IActionResult Create()
        {
            ViewBag.Users = _userManager.Users.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateChatViewModel model)
        {
            if (ModelState.IsValid)
            {
                var creator = await _userManager.FindByNameAsync(model.UserName);

                Chat chat = new Chat { Name = model.Name, Creator = creator };
                List<ApplicationUser> users = new List<ApplicationUser>();
                
                foreach(var memberName in model.Members)
                {
                    users.Add(await _userManager.FindByNameAsync(memberName));
                }
                chat.Members = users;
                chats.CreateChat(chat);

                AddChatId(chat, creator);
                await _userManager.UpdateAsync(creator);

                foreach (var user in chat.Members)
                {
                    AddChatId(chat, user);
                    await _userManager.UpdateAsync(user);
                }

                return RedirectToAction();
            }
            return View(model);
        }

        private static void AddChatId(Chat chat, ApplicationUser user)
        {
            if (user.ChatId == null)
            {
                var chatsId = new List<int> { chat.Id };
                user.ChatId = chatsId;
            }
            else user.ChatId.Add(chat.Id);
            
        }

        public IActionResult Index(int id)
        {
            List<ChatMessage> messages = _appDBContext.ChatMessages.Where(c => c.ChatId == id).OrderBy(c=> c.PostDate).ToList();
            ChatMessagesViewModel model = new ChatMessagesViewModel { ChatId = id, ChatMessages = messages };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index (ChatMessagesViewModel model)
        {
            ChatMessage message = new ChatMessage { TextMessage = model.TextMessage, PostDate = DateTime.Now, Author = await _userManager.FindByNameAsync(model.UserName) };
            _appDBContext.ChatMessages.Add(message);
            _appDBContext.SaveChanges();
            return RedirectToAction($"/Index/{model.ChatId}");
        }
    }
}
