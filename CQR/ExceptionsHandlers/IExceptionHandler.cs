using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQR.ExceptionsHandlers
{
    public interface IExceptionHandler
    {
        Task Handler(ExceptionContext context);
    }
}
