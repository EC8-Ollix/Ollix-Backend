using Ardalis.Result;
using System.Text.Json.Serialization;

namespace Ollix.API.Shared.Response
{
    public class ErrorModel<T> : IApiResponse<T> where T : class
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Code { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? Errors { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? ValidationErrors { get; set; }

        public static ErrorModel<T> GetResponse(Result<T> result)
        {
            return new ErrorModel<T>()
            {
                Code = result.Status.ToString(),
                Errors = result.Errors.Any() ? result.Errors.ToArray() : null,
                ValidationErrors = result.ValidationErrors.Any() ? result.ValidationErrors.Select(v => v.ErrorMessage).ToArray() : null
            };
        }
    }
}
