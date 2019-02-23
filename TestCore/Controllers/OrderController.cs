using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repo.Repositories;

namespace TestCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderRepository _orderRepository;
        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        // GET api/GetOrdersByDate
        [HttpGet("/GetOrdersByDate")]
        public ActionResult<IEnumerable<Orders>> GetOrdersByDate(DateTime dateTime)
        {

            var orders = _orderRepository.GetOrderInfoByDate(dateTime);

            return orders.ToArray();
        }
    }
}