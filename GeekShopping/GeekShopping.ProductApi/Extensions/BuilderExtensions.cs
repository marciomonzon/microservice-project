using AutoMapper;
using GeekShopping.ProductApi.Config;
using GeekShopping.ProductApi.Data.Context;
using GeekShopping.ProductApi.Data.Repositories;
using GeekShopping.ProductApi.Data.Repositories.Interfaces;
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

        public static void AddAutoMapper(this WebApplicationBuilder builder)
        {
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddInterfacesServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
