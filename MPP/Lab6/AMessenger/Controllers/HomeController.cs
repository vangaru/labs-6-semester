using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AMessenger.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AMessenger.Models;
using AMessenger.Models.ValidationModels;
using AMessenger.Models.ViewModels;
using AMessenger.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AMessenger.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private const int ChatRoomsPerPage = 20;
        
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int currentPageNumber = 1)
        {
            var roomsCount = _dbContext.ChatRooms.CountAsync();
            var chatRoomsToDisplay = await _dbContext.ChatRooms
                .Skip((currentPageNumber - 1) * ChatRoomsPerPage)
                .Take(ChatRoomsPerPage)
                .ToListAsync();
            var viewModel = new IndexViewModel
            {
                PaginationInfo = new PaginationInfo(currentPageNumber, await roomsCount, ChatRoomsPerPage),
                ChatRooms = chatRoomsToDisplay
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult CreateRoom()
        {
            return RedirectToAction("Index", "CreateRoom");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}