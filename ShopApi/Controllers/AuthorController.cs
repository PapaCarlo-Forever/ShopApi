using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Models;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public AuthorController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Author>>> Get()
        {
            return Ok(await _context.Authors.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetID(int id)
        {
            var author = _context.Authors.FindAsync(id);
            if (author.Result == null)
                return BadRequest("Автора нет");
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return Ok(await _context.Authors.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Author>>> Update(Author request)
        {
            var author = await _context.Authors.FindAsync(request.Id);
            if (author == null)
                return BadRequest("Автора нет");
            author.Surname = request.Surname;
            author.Name = request.Name;
            author.Patronymic = request.Patronymic;
            await _context.SaveChangesAsync();
            return Ok(await _context.Authors.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult<List<Author>>> Delete(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return BadRequest("Автора нет");
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return Ok(await _context.Authors.ToListAsync());
        }
    }
}
