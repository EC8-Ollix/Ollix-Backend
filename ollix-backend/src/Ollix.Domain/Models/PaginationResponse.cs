namespace Ollix.Domain.Models
{
    public class PaginationResponse<T> where T : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public IEnumerable<T>? Data { get; set; }

        public PaginationResponse(IEnumerable<T>? data, int totalRecords, int currentPage, int pageSize)
        {
            Data = data;
            TotalRecords = totalRecords;
            Page = currentPage;
            PageSize = pageSize;

            TotalPages = Convert.ToInt32(Math.Ceiling((TotalRecords / (double)pageSize)));

            HasNextPage = Page < TotalPages;
            HasPreviousPage = Page > 1;
        }

        public PaginationResponse(IEnumerable<T>? data)
        {
            Data = data;
        }
        public PaginationResponse() { }
    }
}
