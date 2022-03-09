namespace General.DataAccess.Business
{
    public class Pager
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public Pager()
        {

        }
        public Pager(int totalItems, int pageNumber, int pageSize = 10)
        {
            int totalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize);
            int currentPage = pageNumber;
            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if (startPage <= 0)
            {
                startPage = 1;
                endPage = endPage - (startPage - 1);
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }
    }
}
