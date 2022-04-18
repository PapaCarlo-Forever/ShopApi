using Microsoft.AspNetCore.Mvc;


namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationContext _context;
        private AuthorController authorController;
        public BookController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            return Ok(await _context.Books.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetID(int id)
        {
            var book = _context.Books.FindAsync(id);
            if (book == null)
                return BadRequest("Книг нет");
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Book book)
        {
            var author = _context.Authors.FindAsync(book.AuthorId);
            if (author.Result == null)
                return BadRequest("Атора нет");
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Book>>> Update(Book request)
        {
            var book = await _context.Books.FindAsync(request.Id);
            if (book == null)
                return BadRequest("Книга нет");
            book.Id = request.Id;
            book.Description = request.Description;
            book.Price = request.Price;
            book.Pages = request.Pages;
            book.AuthorId = request.AuthorId;
            book.Title = request.Title;
            await _context.SaveChangesAsync();
            return Ok(await _context.Books.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult<List<Book>>> Delete(int id)
        {
            var author = await _context.Books.FindAsync(id);
            if (author == null)
                return BadRequest("Книг нет");
            _context.Books.Remove(author);
            await _context.SaveChangesAsync();
            return Ok(await _context.Books.ToListAsync());
        }
    }
}
