using CQR.ExceptionsHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQR.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, IExceptionHandler> exceptionHandlers;

        public ApiExceptionFilterAttribute(IDictionary<Type, IExceptionHandler> ExceptionHandlers)
        {
            exceptionHandlers = ExceptionHandlers;
        }


        public override void OnException(ExceptionContext context)
        {
            Type ExceptionType = context.Exception.GetType();

            if (exceptionHandlers.ContainsKey(ExceptionType))
            {
                exceptionHandlers[ExceptionType].Handler(context);
            }
            else
            {
                new ExceptionHandlerBase().SetResult(context, StatusCodes.Status500InternalServerError, "Ha ocurrido un error al procesar la respuesta.", string.Empty);
            }

            base.OnException(context);

        }

    }
}
