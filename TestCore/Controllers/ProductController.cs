using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repo.Repositories;
using Newtonsoft.Json;


namespace TestCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductRepository _productRepository;
        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET api/GetProductsByKeyWords
        [HttpGet("/GetProductsByKeyWords")]
        public string GetProductsByKeyWords(string keyword)
        {
            var products = _productRepository.GetProducsInfoByKeywords(keyword);
            var json = JsonConvert.SerializeObject(products);
            return json;
        }

        //POST /AddProduct
        [HttpPost("/AddProduct")]
        public void AddProduct(Products product)
        {
            _productRepository.AddProduct(product);
        }
        
        //UPDATE /UpdateProduct
        [HttpPut("/UpdateProduct")]
        public void UpdateProduct(Products product)
        {
            _productRepository.EditProduct(product);
        }

        //DELETE /DeleteProduct
        [HttpDelete("/DeleteProduct")]
        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }
    }
}