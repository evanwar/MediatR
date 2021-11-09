using SpecificationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpecificationDemo.Specifications
{
    public class ProductActiveSpecification : Specification<Product>
    {
        public override Expression<Func<Product, bool>> Expression => product => !product.Discontinued;
    }
}
