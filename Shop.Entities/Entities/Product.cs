using System.ComponentModel.DataAnnotations;

namespace Shop.Entities.Entities;

public class Product
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int ProductTypeId { get; set; }

    
    public ProductType? ProductType { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; }
    = new List<ProductCategory>();
}