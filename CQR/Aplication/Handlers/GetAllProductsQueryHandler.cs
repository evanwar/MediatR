using CQR.Aplication.Queries;
using CQR.DBContext;
using CQR.Entities.Exceptions;
using CQR.Entities.POCOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQR.Aplication.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private readonly IProductContext context;

        public GetAllProductsQueryHandler(IProductContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await context.GetAll();

            if (products is null)
                throw new GeneralException("Error al obtener la lista de productos.");

            return products;
        }
    }
}
