using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsAndHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct>
    {
        public Task Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Eliminar el producto: {request.Id}");

            return Task.CompletedTask;
        }
    }
}
