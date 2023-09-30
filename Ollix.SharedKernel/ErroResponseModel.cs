using Ardalis.Result;

namespace Ollix.SharedKernel
{
    public class ErrorResponseModel
    {
        public IEnumerable<string>? Errors { get; set; }
        public List<ValidationError>? ValidationErrors { get; set; }
    }
}
