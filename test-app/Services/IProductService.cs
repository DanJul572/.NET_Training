using test_app.DTOs;

namespace test_app.Services;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> GetAllProductsAsync();
    Task<ProductModel> GetProductByIdAsync(int id);
    Task AddProductAsync(ProductModel productDto);
    Task UpdateProductAsync(int id, ProductModel productDto);
    Task DeleteProductAsync(int id);
}