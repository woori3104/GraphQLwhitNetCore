using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQlProject.Interfaces;
using GraphQlProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GraphQlProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct _productService;

        public ProductController(IProduct productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productService.GetProductById(id);
        }

        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            _productService.AddProduct(product);
            return product;
        }

        [HttpPut("{id}")]
        public Product Put(int id, [FromBody] Product product)
        {
            _productService.UpdateProduct(id, product);
            return product;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
