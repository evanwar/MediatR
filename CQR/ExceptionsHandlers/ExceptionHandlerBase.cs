using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQR.ExceptionsHandlers
{
    public class ExceptionHandlerBase
    {
        readonly Dictionary<int, string> RFC7231 =
               new Dictionary<int, string>
               {
                   {StatusCodes.Status500InternalServerError,"https://datatracker.ietf.org/doc/html/draft-ietf-httpbis-p2-semantics-26#section-6.6.1" },
                   {StatusCodes.Status404NotFound, "https://datatracker.ietf.org/doc/html/draft-ietf-httpbis-p2-semantics-26#section-6.5.4"}
               };


        public Task SetResult(ExceptionContext context, int? status, string title, string detail)
        {
            ProblemDetails details = new ProblemDetails
            {
                Status = status,
                Title = title,
                Type = RFC7231.ContainsKey(status.Value) ? RFC7231[status.Value] : string.Empty,
                Detail = detail,
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = status
            };

            context.ExceptionHandled = true;

            return Task.CompletedTask;

        }
    }
}
