using HousesPapon.Communication.Responses;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace HousesPapon.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is HousesPaponException)
        {
            HandleProjectExceptions(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private void HandleProjectExceptions(ExceptionContext context)
    {
        var exception = (HousesPaponException)context.Exception;
        var response = new ResponseError(exception.GetErrors());

        context.HttpContext.Response.StatusCode = exception.StatusCodes;
        context.Result = new ObjectResult(response);
    }
    private void ThrowUnknownError(ExceptionContext context)
    {
        var response = new ResponseError(ResourceErrorMessages.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(response);
    }
}
