
namespace ShopApi.Models
{
    public class ApplicationBookContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public ApplicationBookContext(DbContextOptions<ApplicationBookContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
