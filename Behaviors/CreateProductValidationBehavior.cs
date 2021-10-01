using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Behaviors
{
    public class CreateProductValidationBehavior : IPipelineBehavior<CreateProduct, int>
    {
        public Task<int> Handle(CreateProduct request, CancellationToken cancellationToken, RequestHandlerDelegate<int> next)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentNullException(nameof(request.Name), "El nombre del producto debe ser especificado.");
            }

            return next();
        }
    }
}
