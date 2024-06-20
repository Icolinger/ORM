using ORMProducts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ORMProduct.Controller
{
    public class ProductTypeController
    {
        ProductContext _productDbContext = new ProductContext();

        public List<ProductType> GetAll()
        {
            return _productDbContext.ProducTypes.ToList();
        }
        public string ProductType(int id)
        {
            return _productDbContext.Products.Find(id).Name;
        }
    }
}
