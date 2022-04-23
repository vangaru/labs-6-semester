using System.Collections.Generic;
using AMessenger.Pagination;

namespace AMessenger.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ChatRoom> ChatRooms { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}