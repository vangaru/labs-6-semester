using System;

namespace AMessenger.Pagination
{
    public class PaginationInfo
    {
        public int CurrentPageNumber { get; }
        public int TotalPagesCount { get; }

        public bool HasPreviousPage => CurrentPageNumber > 1;

        public bool HasNextPage => CurrentPageNumber < TotalPagesCount;
        
        public PaginationInfo(int currentPageNumber, int totalItemsCount, int itemsCountPerPage)
        {
            CurrentPageNumber = currentPageNumber;
            TotalPagesCount = (int)Math.Ceiling(totalItemsCount / (double) itemsCountPerPage);
        }
    }
}