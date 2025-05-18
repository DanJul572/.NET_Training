using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test_app.Constants;
using test_app.Services;
using test_app.DTOs;

namespace test_app.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        try
        {
            var product = await _productService.GetProductByIdAsync(Convert.ToInt32(id));
            return Ok(product);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductModel productDto)
    {
        await _productService.AddProductAsync(productDto);
        return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto); 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductModel productDto)
    {
        try
        {
            await _productService.UpdateProductAsync(id, productDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _productService.DeleteProductAsync(Convert.ToInt32(id));
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}