using GeekShopping.ProductApi.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Data.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
