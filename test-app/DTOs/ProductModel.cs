using System.ComponentModel.DataAnnotations;

namespace test_app.DTOs;

public class ProductModel
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public decimal Price { get; set; }
}
