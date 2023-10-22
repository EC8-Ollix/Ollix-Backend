namespace Ollix.Domain.Models
{
    public class PaginationResponse<T> where T : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T>? Data { get; set; }

        public PaginationResponse(IEnumerable<T>? data, int totalRecords, PaginationRequest paginationRequest)
        {
            Data = data;
            TotalRecords = totalRecords;
            Page = paginationRequest.Page;
            PageSize = paginationRequest.PageSize;

            TotalPages = Convert.ToInt32(Math.Ceiling((TotalRecords / (double)paginationRequest.PageSize)));
        }

        public PaginationResponse(IEnumerable<T>? data)
        {
            Data = data;
        }
        public PaginationResponse(PaginationRequest paginationRequest)
        {
            Page = paginationRequest.Page;
            PageSize = paginationRequest.PageSize;
        }
    }
}
