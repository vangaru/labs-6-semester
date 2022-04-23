using System;
using System.Linq;
using System.Threading.Tasks;
using AMessenger.Data;
using AMessenger.Models;
using AMessenger.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMessenger.Controllers
{
    [Authorize]
    public class ChatRoomController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatRoomController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var chatRoom = await _dbContext.ChatRooms
                .Include(c => c.Messages)
                .ThenInclude(m => m.Author).FirstOrDefaultAsync(c => c.Id == id);
            var viewModel = new ChatRoomViewModel
            {
                ChatRoom = chatRoom
            };
            var messages = await _dbContext.Messages.Where(m => m.ChatRoom.Id == chatRoom.Id)
                .ToListAsync();
            Console.WriteLine(messages.Count);
            return View(viewModel);
        }

        [HttpPost]
        public async Task AddMessage(int? id, string text)
        {
            var chatRoom = await _dbContext.ChatRooms.FirstOrDefaultAsync(c => c.Id == id);
            var message = new Message
            {
                Author = await _userManager.GetUserAsync(HttpContext.User),
                ChatRoom = chatRoom,
                Text = text
            };
            await _dbContext.Messages.AddAsync(message);
            await _dbContext.SaveChangesAsync();
        }
    }
}