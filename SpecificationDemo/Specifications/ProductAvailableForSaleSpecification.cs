using SpecificationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpecificationDemo.Specifications
{
    public class ProductAvailableForSaleSpecification : Specification<Product>
    {
        //public override Expression<Func<Product, bool>> Expression =>
        //    product => !product.Discontinued && product.UnitsInStock > 0;
        public override Expression<Func<Product, bool>> Expression
        {
            get
            {
                var InStock = new ProductWithStockSpecification();

                var NotDiscontinued = new ProductActiveSpecification();

                return InStock.And(NotDiscontinued).Expression;

            }
        }
    }
}
