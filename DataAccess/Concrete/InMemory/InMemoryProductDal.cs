using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;
        public InMemoryProductDal()
        {
            //oracle,sql server dan geliyor gibi simüle edicez
            _products = new List<Product>
            {
                new Product{ProductId=1, ProductName="bardak",UnitPrice=15,UnitsInStock=15 },
                new Product{ProductId=2, ProductName="kamera",UnitPrice=500,UnitsInStock=3 },
                new Product{ProductId=3, ProductName="telefon",UnitPrice=1500,UnitsInStock=2 },
                new Product{ProductId=4, ProductName="klavye",UnitPrice=150,UnitsInStock=65 },
                new Product{ProductId=5, ProductName="fare",UnitPrice=85,UnitsInStock=1},

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //p=> lambda anlamına geliyor
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Add(productUpdate);
        }
    }
}
