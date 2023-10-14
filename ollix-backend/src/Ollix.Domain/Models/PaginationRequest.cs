using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Ollix.Domain.Models
{
    public class PaginationRequest
    {
        private int _maxPageSize = 50;

        [FromQuery(Name = "page")]
        public int Page { get; set; }

        [FromQuery(Name = "pageSize")]
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
