using ORMProducts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMProduct.Controller
{
    public class ProductController
    {
        public ProductContext _productDbContext = new ProductContext();
        public Product Get(int id)
        {
            Product findProduct = _productDbContext.Products.Find(id);
            if (findProduct != null)
            {
                _productDbContext.Entry(findProduct).Reference(x => x.ProductTypes).Load();
            }
            return findProduct;
        }

        public List<Product> GetAll()
        {
            return _productDbContext.Products.Include("Product").ToList();
        }


        public void Create(Product product)
        {
            _productDbContext.Products.Add(product);
            _productDbContext.SaveChanges();
        }

        public void Update(int id, Product product)
        {
            Product findProduct = _productDbContext.Products.Find(id);
            if (findProduct == null) 
            {
                return;
            }
            findProduct.Name = product.Name;
            findProduct.Description = product.Name;
            findProduct.Gender = product.Gender;
            _productDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Product foundProduct = _productDbContext.Products.Find(id);
            _productDbContext.Products.Remove(foundProduct);
            _productDbContext.SaveChanges();
        }
    }
}
