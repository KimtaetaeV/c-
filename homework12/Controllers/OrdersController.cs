using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderApi.Models;

namespace homework12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderContext _context;
        private OrderService orderService = new OrderService();

        public OrdersController(OrderContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        //ID查询
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
             Order res =  orderService.SelectByOrderID(id, _context);

            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return res;
        }

        // GET: api/Orders/小明
        //姓名查询
        [HttpGet("{customer}")]
        public async Task<ActionResult<List< Order>>> GetOrder(String customer)
        {
            List<Order> reslist =  orderService.SelectByCustomer(customer, _context);

            var order = await _context.Orders.FindAsync(customer);

            if (order == null|| reslist.Count == 0)
            {
                return NotFound();
            }

            return reslist;
        }

        // GET: api/Orders/100
        //金额查询
        [HttpGet("{customer}")]
        public async Task<ActionResult<List<Order>>> GetOrder(double money)
        {
            List<Order> reslist = orderService.SelectByMoney(money, _context);

            var order = await _context.Orders.FindAsync(money);

            if (order == null || reslist.Count == 0)
            {
                return NotFound();
            }

            return reslist;
        }

        //修改
        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public Order PutOrder(int id, Order order)
        {
            Order res = new Order(order.OrderID, order.OrderDate, order.Customer);

            try
            {
                try
                {
                    orderService.ModifyOrder(res, _context);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return res;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    Console.WriteLine($"id={id}的订单不存在");
                }
                else
                {
                    throw;
                }
            }

            return res;
        }

        //添加订单

        [HttpPost]
        public Order PostOrder2([FromBody]Order order)
        {
            Order res = new Order(order.OrderID,order.OrderDate,order.Customer);
            try
            {
                orderService.AddOrder(res, _context);
                
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return res;
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            orderService.DeleteOrder(id, _context);
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
