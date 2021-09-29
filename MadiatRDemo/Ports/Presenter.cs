using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadiatRDemo.Ports
{
    public class Presenter : ICreateProductOutputPort
    {

        public string Content { get; private set; }

        public void Handle(int productId)
        {
            Content = $"Id de producto creado: {productId}";
        }
    }
}
