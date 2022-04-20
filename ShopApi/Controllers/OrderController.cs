using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Models;

namespace ShopApi.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ApplicationContext _context;
        public OrderController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Add(Order order)
        {
            var book = _context.Books.FindAsync(order.BookId);
            if (book.Result == null)
                return BadRequest("Книги нет");
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return Ok(await _context.Orders.ToListAsync());
        }
    }
}
