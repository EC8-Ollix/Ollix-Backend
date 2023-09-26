using Ardalis.Result;
using Ollix.SharedKernel;
using System.Text.Json.Serialization;

namespace Ollix.API.Shared.Response
{
    public class SuccessModel<T> : IApiResponse<T> where T : class
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SuccessMessage { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Data { get; set; }

        public static SuccessModel<T> GetResponse(Result<T> result)
        {
            return new SuccessModel<T>()
            {
                Data = result.Value,
                SuccessMessage = !string.IsNullOrEmpty(result.SuccessMessage) ? result.SuccessMessage : null
            };
        }
    }
}
