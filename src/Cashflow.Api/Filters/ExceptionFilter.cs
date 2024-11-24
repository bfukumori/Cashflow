using Cashflow.Communication.Responses;
using Cashflow.Exception;
using Cashflow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Cashflow.Api.Filters;
public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CashflowException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private static void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException ex)
        {
            var errorResponse = new ResponseErrorsJson(ex.Errors);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new ObjectResult(errorResponse);
        }
        else
        {
            var errorResponse = new ResponseErrorsJson(context.Exception.Message);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new ObjectResult(errorResponse);
        }
    }

    private static void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorsJson(ResourceErrorMessages.UNKNOWN_ERROR);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
