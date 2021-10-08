using CQR.Aplication.Queries;
using CQR.DBContext;
using CQR.Entities.Exceptions;
using CQR.Entities.POCOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQR.Aplication.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductContext context;

        public GetProductByIdQueryHandler(IProductContext context)
        {
            this.context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await context.GetById(request.Id);

            if (product is null)
            {
                throw new EntityNotFoundException("Prouducto", request.Id);
            }

            return product;
        }
    }
}
