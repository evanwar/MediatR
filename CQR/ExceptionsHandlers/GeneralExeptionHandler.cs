using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQR.ExceptionsHandlers
{
    public class GeneralExeptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handler(ExceptionContext context)
        {
            return SetResult(context, StatusCodes.Status500InternalServerError, "Ha ocurrido un error al procesar la peticion", context.Exception.Message);
        }
    }
}
