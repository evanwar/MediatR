using CQR.Aplication.Commands;
using CQR.DBContext;
using CQR.Entities.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQR.Aplication.Handlers
{
    public class DeleteProductCommandHandler : AsyncRequestHandler<DeleteProductCommand>
    {
        private readonly IProductContext context;

        public DeleteProductCommandHandler(IProductContext context)
        {
            this.context = context;
        }



        protected async override Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (!await context.Remove(request.Id))
                throw new GeneralException($"El producto {request.Id} no pudo ser eliminado.");
        }
    }
}
