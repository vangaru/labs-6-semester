using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace AMessenger.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<ChatRoom> ChatRooms { get; set; } = new();
        public List<Message> Messages { get; set; }
    }
}