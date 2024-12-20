using AutoMapper;
using GeekShopping.ProductApi.Data.Context;
using GeekShopping.ProductApi.Data.Repositories.Interfaces;
using GeekShopping.ProductApi.Dtos;
using GeekShopping.ProductApi.Model;
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

        public async Task<ProductDto> GetByIdAsync(long id)
        {
            var product = await _context.Products
                                        .FirstOrDefaultAsync(p => p.Id == id);

            return product == null ? new ProductDto() :
                   _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateAsync(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Update(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            var product = await _context.Products
                                        .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return false;

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
