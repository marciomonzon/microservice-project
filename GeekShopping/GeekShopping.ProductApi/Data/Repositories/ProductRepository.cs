using AutoMapper;
using GeekShopping.ProductApi.Data.Context;
using GeekShopping.ProductApi.Data.Repositories.Interfaces;
using GeekShopping.ProductApi.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _context.Products
                                         .AsNoTracking()
                                         .ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await _context.Products
                                        .FirstOrDefaultAsync(p => p.Id == id);

            return product == null ? new ProductDto() : 
                   _mapper.Map<ProductDto>(product);
        }

        public Task<ProductDto> CreateAsync(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> Update(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
