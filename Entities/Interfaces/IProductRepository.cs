using Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        void SetDiscontinued(int id);

        IEnumerable<Product> GetDiscontinuedProducts();

        void AddToCategoryFromProductNames(Category category, IEnumerable<string> products);
    }
}
