using System.ComponentModel.DataAnnotations;

namespace Shop.Entities.Entities;

public class ProductType
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}