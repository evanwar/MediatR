using Mediator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsAndHandlers
{
    public class CreateHandlerProduct : IRequestHandler<CreateProduct, int>
    {
        public Task<int> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Crear el producto; {request.Product}");

            return Task.FromResult(new Random().Next(1, 1000));
        }
    }
}
