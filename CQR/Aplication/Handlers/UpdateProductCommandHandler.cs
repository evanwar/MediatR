using CQR.Aplication.Commands;
using CQR.DBContext;
using CQR.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQR.Aplication.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {

        private readonly IProductContext context;

        public UpdateProductCommandHandler(IProductContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.GetById(request.Id);

            if (product is null) return false;

            product.Name = request.Name;
            product.QuantityPerUnit = request.QuantityPerUnit;
            product.Description = request.Description;
            product.UnitPrice = request.UnitePrice;

            return await context.Update(product);
        }
    }
}
