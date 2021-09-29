using Mediator;
using System;

namespace CommandsAndHandlers
{
    public class CreateProduct : IRequest<int>
    {
        public string Product { get; set; }
    }
}
