using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQR.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuantityPerUnit { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int Reporderlevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
