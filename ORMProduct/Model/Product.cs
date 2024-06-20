
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMProducts.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }

        public string Gender { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
        public ProductType ProductTypes { get; set; }

    }
}
