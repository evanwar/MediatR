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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductContext context;

        public CreateProductCommandHandler(IProductContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                QuantityPerUnit = request.QuiantityPerUnit,
                Description = request.Description,
                UnitPrice = request.UnitePrice,
                UnitsInStock = request.UnitInStock,
                Reporderlevel = 0,
                UnitsOnOrder = 0,
                Discontinued = false
            };

            return await context.Add(product);
        }
    }
}
