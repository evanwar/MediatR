using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MadiatRDemo
{
    public class OneWayHandler : AsyncRequestHandler<CreateProduct>
    {
        protected async override Task Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Mensaje OneWay");
            await Task.CompletedTask;
        }
    }
}
