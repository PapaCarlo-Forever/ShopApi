using Microsoft.EntityFrameworkCore;

namespace ShopApi.Models
{
    public class ApplicationOrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;
        public ApplicationOrderContext(DbContextOptions<ApplicationOrderContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
