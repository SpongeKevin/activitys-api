using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("/api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly DbContext _db;
        public OrderController(DbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            var orders = await _db.Orders.ToListAsync();

            return orders;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(long id)
        {
            var order = await _db.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        public async Task Post(Order order)
        {
            _db.Orders.Add(order);
            order.OrderTime = DateTime.Now;
            await _db.SaveChangesAsync();
        }

        [HttpPost("{id}")]
        public async Task Post(Order order, long id)
        {
            var orders = await _db.Orders.FindAsync(id);
            orders.IsComplete = order.IsComplete;
            await _db.SaveChangesAsync();
        }
    }
}

