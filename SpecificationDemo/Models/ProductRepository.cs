using SpecificationDemo.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpecificationDemo.Models
{
    public class ProductRepository
    {
        IReadOnlyList<Product> Products = new List<Product>
        {
            new Product{Id=1,Name="Chai",UnitsInStock=1,Discontinued=false},
            new Product{Id=2,Name="Chang",UnitsInStock = 0,Discontinued=true},
            new Product{Id=3,Name="Tofu",UnitsInStock=1,Discontinued=true},
            new Product{Id=4,Name="Pavlova,",UnitsInStock=2,Discontinued=false}
        };


        public Product GetProductById(int id) =>
            Products.FirstOrDefault(p => p.Id == id);


        public IReadOnlyList<Product> GetByCreateDate(DateTime minCreateDate) =>
             Products.Where(p => p.CreateDate >= minCreateDate).ToList();


        public IReadOnlyList<Product> GetByUnitPrice(decimal minPrice) =>
            Products.Where(p => p.UnitPrice >= minPrice).ToList();


        public IReadOnlyList<Product> GetByCategoryId(int categoryId) =>
            Products.Where(p => p.CategoryId == categoryId).ToList();


        public IReadOnlyList<Product> Find(DateTime? minCreateDate = null,
                                           decimal minPrice = 0,
                                           int categoryId = 0)
        {
            var query = Products.Where(p => p.CreateDate >= minCreateDate.Value);

            return query.ToList();
        }


        public IReadOnlyList<Product> FindAvailableForSale()
        {
            return Products.Where(p => new ProductAvailableSpecification().IsSatifieBy(p)).ToList();
        }


        public IReadOnlyList<Product> Find(Expression<Func<Product, bool>> query)
        {
            return Products.Where(query.Compile()).ToList();
        }


        public IReadOnlyList<Product> Find(GenericSpecification<Product> specification)
        {
            var expressionDelegate = specification.Expression.Compile();

            return Products.Where(expressionDelegate).ToList();
        }


        public IReadOnlyList<Product> Find(Specification<Product>specification)
        {
            var expressionDelegate = specification.Expression.Compile();

            return Products.Where(expressionDelegate).ToList();
        }



    }
}
