using Ardalis.Result;

namespace Ollix.SharedKernel.Extensions
{
    public static class ResultExtensions
    {
        public static ErrorResponseModel ToErrorModel(this Result result)
        {
            return new ErrorResponseModel
            {
                Errors = result.Errors,
                ValidationErrors = result.ValidationErrors
            };
        }

        public static ErrorResponseModel ToErrorModel<T>(this Result<T> result) where T : class
        {
            return new ErrorResponseModel
            {
                Errors = result.Errors,
                ValidationErrors = result.ValidationErrors
            };
        }
    }
}
