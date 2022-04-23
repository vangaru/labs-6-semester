using System;

namespace AMessenger.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTimeSent { get; set; } = DateTime.Now;
        public ChatRoom ChatRoom { get; set; }
        public ApplicationUser Author { get; set; }
    }
}