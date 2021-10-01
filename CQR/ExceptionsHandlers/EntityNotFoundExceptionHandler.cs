using CQR.Entities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace CQR.ExceptionsHandlers
{
    public class EntityNotFoundExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handler(ExceptionContext context)
        {

            EntityNotFoundException exception = context.Exception as EntityNotFoundException;

            return SetResult(context, StatusCodes.Status404NotFound, "El recurso especificado no fue encontrado", exception.Message);
        }
    }
}
