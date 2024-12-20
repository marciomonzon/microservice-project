using GeekShopping.ProductApi.Data.Repositories.Interfaces;
using GeekShopping.ProductApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? 
                                 throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet("get-all-products")]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            if (products.Count() == 0) { return NotFound(); }

            return Ok(products);
        }

        [HttpGet("get-product")]
        public async Task<IActionResult> GetByIdAsync(long id) 
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product.Name == string.Empty) { return NotFound(); }

            return Ok(product);
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> CreateAsync(ProductDto dto)
        {
            if (dto is null) return BadRequest();

            var productCreated = await _productRepository.CreateAsync(dto);

            return Ok(productCreated);
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateAsync(ProductDto dto)
        {
            if (dto is null) return BadRequest();

            var productUpdated = await _productRepository.Update(dto);

            return Ok(productUpdated);
        }

        [HttpPost("delete-product")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var status = await _productRepository.DeleteByIdAsync(id);

            return status ? Ok() : BadRequest();
        }
    }
}
