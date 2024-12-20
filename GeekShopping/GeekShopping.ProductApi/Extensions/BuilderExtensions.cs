using GeekShopping.ProductApi.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            builder.Services.AddDbContext<ApiDbContext>(options => options
                            .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
