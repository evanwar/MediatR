using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQR.Aplication.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string QuiantityPerUnit { get; set; }
        public string Description { get; set; }
        public decimal UnitePrice { get; set; }
        public int UnitInStock { get; set; }
    }
}
