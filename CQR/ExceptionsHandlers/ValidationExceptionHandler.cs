using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Threading.Tasks;

namespace CQR.ExceptionsHandlers
{
    public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handler(ExceptionContext context)
        {
            ValidationException exception =
                 context.Exception as ValidationException;

            var builder = new StringBuilder();

            foreach (var failure in exception.Errors)
            {
                builder.AppendLine(string.Format("Propiedad: {0}, Error: {1}", failure.PropertyName, failure.ErrorMessage));
            }

            return SetResult(context, StatusCodes.Status400BadRequest, "Error en la entrada de datos.", builder.ToString());

        }
    }
}
