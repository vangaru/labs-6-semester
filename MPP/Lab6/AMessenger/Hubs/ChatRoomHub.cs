using System;
using System.Threading.Tasks;
using AMessenger.Data;
using AMessenger.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AMessenger.Hubs
{
    public class ChatRoomHub : Hub
    {
        private readonly ApplicationDbContext _dbContext;

        public ChatRoomHub(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SendMessage(string text, int chatRoomId, string url)
        {
            Console.WriteLine($"{text} {chatRoomId}");
            await Clients.All.SendAsync("SendMessage", text, url);
            var chatRoom = await _dbContext.ChatRooms.FirstOrDefaultAsync(c => c.Id == chatRoomId);
            var message = new Message
            {
                Text = text,
                ChatRoom = chatRoom
            };
            await _dbContext.Messages.AddAsync(message);
            await _dbContext.SaveChangesAsync();
        }
    }
}