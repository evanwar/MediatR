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
        public int UnitInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReporderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
