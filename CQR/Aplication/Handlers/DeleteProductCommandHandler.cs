using CQR.Aplication.Commands;
using CQR.DBContext;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQR.Aplication.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductContext context;

        public DeleteProductCommandHandler(IProductContext context)
        {
            this.context = context;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await context.Remove(request.Id);
        }
    }
}
