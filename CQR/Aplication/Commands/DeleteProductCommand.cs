using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQR.Aplication.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
