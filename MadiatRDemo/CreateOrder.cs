using MadiatRDemo.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadiatRDemo
{
    public class CreateProduct : IRequest
    {
        public CreateProduct(string productName,ICreateProductOutputPort outputPort)
        {
            this.Name = Name;
            this.OutputPort = outputPort;
        }

        public string Name { get; set; }

        public ICreateProductOutputPort OutputPort { get; }
    }
}
