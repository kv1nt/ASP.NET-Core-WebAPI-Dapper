using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repo.Repositories;

namespace TestCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerRepository _customerRepository;
        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("/GetAllCustomers")]
        public string GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            var json = JsonConvert.SerializeObject(customers);
            return json;
        }

        [HttpGet("/FindCustomers")]
        public string FindCustomers(string lastName, string city)
        {
            var customers = _customerRepository.FindCustomers(lastName, city);
            var json = JsonConvert.SerializeObject(customers);
            return json;
        }
    }
}