using test_app.DTOs;

namespace test_app.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync();
        Task<ProductResponseDto> GetProductByIdAsync(int id);
        Task AddProductAsync(ProductRequestDto productDto);
        Task UpdateProductAsync(int id, ProductRequestDto productDto);
        Task DeleteProductAsync(int id);
    }
}