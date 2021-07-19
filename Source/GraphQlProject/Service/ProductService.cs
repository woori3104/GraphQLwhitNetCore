using System;
using System.Collections.Generic;
using System.Linq;
using GraphQlProject.Data;
using GraphQlProject.Interfaces;
using GraphQlProject.Models;

namespace GraphQlProject.Service
{
    public class ProductService : IProduct
    {
        private GraphQLDbContext _dbContext;

        public ProductService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var projectObj = _dbContext.Products.Find(id);
            _dbContext.Products.Remove(projectObj);
            _dbContext.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            var projectObj = _dbContext.Products.Find(id);
            projectObj.Name = product.Name;
            projectObj.Price = product.Price;
            _dbContext.SaveChanges();
            return product;
        }
    }
}
