using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMProducts.Model
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("ProductContext")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType>ProducTypes { get; set; }





    
    }
}
