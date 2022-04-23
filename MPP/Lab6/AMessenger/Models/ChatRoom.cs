using System;
using System.Collections.Generic;

namespace AMessenger.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTimeCreated { get; set; } = DateTime.Now;
        public ApplicationUser Owner { get; set; }
        public List<Message> Messages { get; set; } = new();
    }
}