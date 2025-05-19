using test_app.Entities;
using test_app.DTOs;
using test_app.Repositories;

namespace test_app.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository; 
    }
    
    public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(p => new ProductModel 
        { 
            Id = p.Id, 
            Name = p.Name, 
            Price = p.Price 
        });
    }
    
    public async Task<ProductModel> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        
        return new ProductModel 
        { 
            Id = product.Id, 
            Name = product.Name, 
            Price = product.Price 
        };
    }
    
    public async Task AddProductAsync(ProductModel productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price
        };
        await _productRepository.AddAsync(product);
    }
    
    public async Task UpdateProductAsync(int id, ProductModel productDto)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        
        product.Name = productDto.Name;
        product.Price = productDto.Price;
        await _productRepository.UpdateAsync(product);
    }
    
    public async Task DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        await _productRepository.DeleteAsync(id);
    }
}
