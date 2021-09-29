using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadiatRDemo.Ports
{
    public interface ICreateProductOutputPort
    {
        void Handle(int productId);
    }
}
