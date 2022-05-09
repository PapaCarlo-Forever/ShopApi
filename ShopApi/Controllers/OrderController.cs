using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Models;

namespace ShopApi.Controllers
{
    [EnableCors()]
    [Route("api/Order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ApplicationContext _context;
        public OrderController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            return Ok(await _context.Orders.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Add(Order request)
        {
            var order = await _context.Orders.FindAsync(request.Id);
            if (order != null)
            {
                var book = await _context.Books.FindAsync(request.Items[0]);
                if (book == null)
                    return BadRequest("Книги нет");
                order.Items.Add(request.Items[0]);
            }
            else
            {
                var book = await _context.Books.FindAsync(request.Items[0]);
                if (book == null)
                    return BadRequest("Книги нет");
                _context.Orders.Add(request);
            }
            await _context.SaveChangesAsync();
            return Ok(await _context.Orders.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult<List<Order>>> Delete(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return BadRequest("Заказа нет");
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return Ok(await _context.Orders.ToListAsync());
        }
    }
}
