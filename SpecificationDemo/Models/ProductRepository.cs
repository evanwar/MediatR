using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationDemo.Models
{
    public class ProductRepository
    {
        IReadOnlyList<Product> Products = new List<Product>
        {

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



    }
}
