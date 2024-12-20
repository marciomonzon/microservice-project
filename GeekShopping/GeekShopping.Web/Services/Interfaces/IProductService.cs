using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetProductByIdAsync(long id);
        Task<ProductModel> CreateProductAsync(ProductModel product);
        Task<ProductModel> UpdateProduct(ProductModel product);
        Task<bool> DeleteProductByIdAsync(long id);
    }
}
