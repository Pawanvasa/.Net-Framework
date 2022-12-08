
using System.ComponentModel.DataAnnotations;

public partial class Product
{
    public int ProductUniqueId { get; set; }
    [Required(ErrorMessage = "Product name is required")]
    public string ProductId { get; set; } = null!;
    [Required(ErrorMessage = "Product name is required")]
    public string ProductName { get; set; } = null!;
    [Required(ErrorMessage = "Product description is required")]
    public string Description { get; set; } = null!;
    [Required(ErrorMessage = "Product price is required")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "category id is required")]
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "Product manufacturer is required")]
    public string Manufacturer { get; set; } = null!;
    public virtual Category? Category { get; set; } = null;
}

