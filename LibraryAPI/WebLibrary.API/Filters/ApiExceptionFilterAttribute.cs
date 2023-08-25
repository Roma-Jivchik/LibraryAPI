using Microsoft.AspNetCore.Mvc;
using WebLibrary.BLL.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using BadRequestResult = WebLibrary.API.Models.BadRequestResult;

namespace WebLibrary.API.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilterAttribute()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            { typeof(ValidationExceptionResult), HandleValidationException },
        };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            var type = context.Exception.GetType();

            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var exception = (ValidationExceptionResult)context.Exception;

            var exceptions = exception.ExceptionMessage;

            var badRequest = new BadRequestResult
            {
                Title = "Validation exception, please check the exception list for more details",
                StatusCode = StatusCodes.Status400BadRequest,
                Exceptions = exceptions,
            };

            context.Result = new ObjectResult(badRequest)
            {
                StatusCode = StatusCodes.Status400BadRequest,
            };

            context.ExceptionHandled = true;
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var badRequest = new BadRequestResult
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Title = "Internal Server exception",
                Exceptions = "There was a problem handling your request. Please try again.",
            };

            context.Result = new ObjectResult(badRequest)
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };

            context.ExceptionHandled = true;
        }
    }
}

