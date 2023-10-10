namespace Ollix.Domain.Models
{
    public class PaginationRequest
    {
        private int _maxPageSize = 50;

        public int Page { get; set; }
        public int PageSize { get; set; }

        public PaginationRequest() { }

        public void NormalizePager()
        {
            Page = Page < 1 ? 1 : Page;
            PageSize = (PageSize < 1 ? 10 : PageSize <= _maxPageSize ? PageSize : _maxPageSize);
        }

        public int GetSkip()
        {
            return (Page - 1) * PageSize;
        }
    }
}
