using System.Threading.Tasks;
using AMessenger.Data;
using AMessenger.Models;
using AMessenger.Models.ValidationModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMessenger.Controllers
{
    [Authorize]
    public class CreateRoomController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateRoomController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateRoom(CreateRoomValidationModel model)
        {
            // var room = _dbContext.ChatRooms.FirstOrDefaultAsync(c => c.Text == model.Text);
            // if (room != null)
            // {
            //     ModelState.AddModelError("", "Room with this name already exists.");
            //     return RedirectToAction("Index", "Home");
            // }

            var chatRoom = new ChatRoom()
            {
                Owner = await _userManager.GetUserAsync(HttpContext.User),
                Text = model.Text
            };

            await _dbContext.ChatRooms.AddAsync(chatRoom);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "ChatRoom", new { id = chatRoom.Id });
        }
    }
}