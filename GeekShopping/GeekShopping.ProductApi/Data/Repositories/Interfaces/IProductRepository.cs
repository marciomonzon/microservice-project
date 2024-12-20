using GeekShopping.ProductApi.Dtos;

namespace GeekShopping.ProductApi.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<ProductDto> CreateAsync(ProductDto product);
        Task<ProductDto> Update(ProductDto product);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
