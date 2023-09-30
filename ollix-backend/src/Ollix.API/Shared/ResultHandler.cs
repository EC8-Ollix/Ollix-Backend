using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;

namespace Ollix.API.Shared
{
    public class ResultHandler<TCommandResult>
    {
        private readonly Result<TCommandResult> _result;

        public ResultHandler(Result<TCommandResult> result) => _result = result ?? throw new ArgumentNullException(nameof(result));

        public ResultHandler<TCommandResult> OnSuccess(Func<TCommandResult, ActionResult> onSuccess)
        {
            if (_result.Status == ResultStatus.Ok)
            {
                _actionResult = onSuccess(_result.Value);
            }

            return this;
        }

        public ResultHandler<TCommandResult> OnError(Func<IEnumerable<string>, ActionResult> onError)
        {
            if (_result.Status == ResultStatus.Error)
            {
                _actionResult = onError(_result.Errors);
            }

            return this;
        }

        public ResultHandler<TCommandResult> OnInvalid(Func<IEnumerable<ValidationError>, ActionResult> onInvalid)
        {
            if (_result.Status == ResultStatus.Invalid)
            {
                _actionResult = onInvalid(_result.ValidationErrors);
            }

            return this;
        }
        public ResultHandler<TCommandResult> OnConflict(Func<IEnumerable<string>, ActionResult> onError)
        {
            if (_result.Status == ResultStatus.Conflict)
            {
                _actionResult = onError(_result.Errors);
            }

            return this;
        }

        public ResultHandler<TCommandResult> OnNotFound(Func<IEnumerable<string>, ActionResult> onNotFound)
        {
            if (_result.Status == ResultStatus.NotFound)
            {
                _actionResult = onNotFound(_result.Errors);
            }

            return this;
        }

        public ActionResult Return() => _actionResult ?? throw new ArgumentNullException("Erro");

        private ActionResult? _actionResult;
    }
}