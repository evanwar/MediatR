using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Behaviors
{
    public class CreateProduct : IRequest<int>
    {
        public string Name { get; set; }
    }
}
