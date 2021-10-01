using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Behaviors
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, int>
    {
        public Task<int> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Creando el producto " + request.Name);
            return Task.FromResult(new Random().Next(1, 100));
        }
    }
}
