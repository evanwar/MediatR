using CQR.Aplication.Commands;
using CQR.DBContext;
using CQR.Entities.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQR.Aplication.Handlers
{
    public class UpdateProductCommandHandler : AsyncRequestHandler<UpdateProductCommand>
    {

        private readonly IProductContext context;

        public UpdateProductCommandHandler(IProductContext context)
        {
            this.context = context;
        }



        protected async override Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.GetById(request.Id);

            if (product is null)
            {
                throw new EntityNotFoundException("Producto", request.Id);
            }

            product.Name = request.Name;
            product.QuantityPerUnit = request.QuantityPerUnit;
            product.Description = request.Description;
            product.UnitPrice = request.UnitePrice;

            if (await context.Update(product))
                throw new GeneralException($"El producto {request.Id} no pudo ser modificado.");

        }
    }
}
