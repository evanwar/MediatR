using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MadiatRDemo
{
    public class CreateProductHandler : AsyncRequestHandler<CreateProduct>
    {
        protected override Task Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            int productId = 7;

            request.OutputPort.Handle(productId);

            return Task.CompletedTask;
        }
    }
}
