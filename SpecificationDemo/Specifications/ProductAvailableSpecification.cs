using SpecificationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationDemo.Specifications
{
    public class ProductAvailableSpecification
    {
        public bool IsSatifieBy(Product product)
        {
            return !product.Discontinued && product.UnitsInStock > 0;
        }
    }
}
